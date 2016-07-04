using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SRCDS_Server_Monitor
   {
    public class estatus
    {
        public static readonly string starting = "Starting...";
        public static readonly string waiting = "Waiting...";
        public static readonly string running = "Running";
        public static readonly string stopping = "Stopping...";
        public static readonly string restarting = "Restarting...";
        public static readonly string stopped = "Stopped";
        public static readonly string noresponse = "No Response...";
        public static readonly string failed = "Failed!";
        
    }
    public class srcdsMonitor
    {
        private bool keepAlive = true;
        private bool isRunning = false;
        private bool doRestart = false;
        private bool started = false;
        private bool prepped = false;

        private string srcdsPath;
        private string launchArgs;
        private string launchMap;
        private string status;
        private string lastMap;

        private int startPort;
        private int PID;
        private int delay;
        private int interval;
        private int threshold;
        private int noResponseCount = 0;
        private int crashCount = 0;
        private int priority;
        private IPAddress startIP;
        private IPEndPoint ipPort;

        private DateTime autoRestartTime;
        private bool autoRestarted = true;
        private bool autoRestartEnabled = false;

        private int affMask;
        private const int maxPacket = 1400;

        public Thread runThread;
        

        public int crashes
        {
            get { return this.crashCount; }
        }
        public int pid
        {
            get { return this.PID; }
            set { this.PID = value; }
        }
        public string getStatus
        {
            get { return this.status; }
        }

        public srcdsMonitor()
        {
            // Used for creating object
        }

        private ProcessPriorityClass GetPriority(int priorityNum)
        {
            ProcessPriorityClass[] pArray = new ProcessPriorityClass[6];
            pArray[0] = ProcessPriorityClass.RealTime;
            pArray[1] = ProcessPriorityClass.High;
            pArray[2] = ProcessPriorityClass.AboveNormal;
            pArray[3] = ProcessPriorityClass.Normal;
            pArray[4] = ProcessPriorityClass.BelowNormal;
            pArray[5] = ProcessPriorityClass.Idle;
            return pArray[priorityNum];
        }

        private static Dictionary<string,string> DecodePacket(byte[] packetContents, int pktLen)
        {
            List<int> splitPositions = new List<int>();
            var returnDict = new Dictionary<string, string>();
            for (int i = 0; i < pktLen; i++)
			{
                if (packetContents[i] == 0x00){
                    if (splitPositions.Count == 4 && i < splitPositions[3]+10){continue;}
                    splitPositions.Add(i);
                }
			 
			}
            returnDict.Add("protocol", packetContents[5].ToString("#"));
            returnDict.Add("name", System.Text.Encoding.UTF8.GetString(packetContents, 6, splitPositions[0] - 6));
            returnDict.Add("map", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[0] + 1, splitPositions[1] - (splitPositions[0] + 1)));
            returnDict.Add("game", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[1] + 1, splitPositions[2] - (splitPositions[1] + 1)));
            returnDict.Add("mod", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[2] + 1, splitPositions[3] - (splitPositions[2] + 1)));
            returnDict.Add("players", packetContents[splitPositions[3] + 3].ToString());
            returnDict.Add("maxplayers", packetContents[splitPositions[3] + 4].ToString());
            returnDict.Add("bots", packetContents[splitPositions[3] + 5].ToString());
            returnDict.Add("type", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[3] + 6, 1));
            returnDict.Add("os", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[3] + 7, 1));
            returnDict.Add("password", packetContents[splitPositions[3] + 8].ToString());
            returnDict.Add("vac", packetContents[splitPositions[3] + 9].ToString());
            returnDict.Add("version", System.Text.Encoding.UTF8.GetString(packetContents, splitPositions[3] + 10, splitPositions[4] - (splitPositions[3] + 10)));

            return returnDict;
        }

        // Initialise this instance with the parameters needed to start the process.
        public void Prep(string srcdspath, string launchmap, string launchcmd, IPAddress ipaddr, int launchport, int delay, int pid, int interval, int threshold, DateTime autoRestartTime, bool autoRestartEnabled, int affMask, int priorityNum)
        {
            this.srcdsPath = srcdspath;
            this.launchMap = launchmap;
            this.lastMap = launchmap;
            this.launchArgs = launchcmd;
            this.startIP = ipaddr;
            this.startPort = launchport;
            this.delay = delay;
            this.PID = pid;
            this.interval = interval;
            this.threshold = threshold;
            this.ipPort = new IPEndPoint(startIP, startPort);
            this.autoRestartTime = autoRestartTime;
            this.autoRestartEnabled = autoRestartEnabled;
            this.priority = priorityNum;
            if (affMask < 1 || affMask > (int)(Math.Pow(2,Environment.ProcessorCount) - 1))
            {
                this.affMask = (int)(Math.Pow(2, Environment.ProcessorCount) - 1);
            }
            else
            {
                this.affMask = affMask;
            }
            
            this.prepped = true;
        }
        public void Stop()
        {

            if (this.doRestart)
            {
                this.status = estatus.restarting;
            }
            else
            {
                this.status = estatus.stopping;
                this.keepAlive = false;
            }
            
            Process p = null;
            try
            {
                if (this.PID > 0) { p = Process.GetProcessById(PID); }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            if (p != null)
            {
                Console.WriteLine("Got a process...");
                Console.WriteLine("Process name: " + p.ProcessName);
                if (p.ProcessName == "srcds")
                {

                    Console.WriteLine("Killing process...");
                    try
                    {
                        p.Kill();
                        Console.WriteLine("Success");
                    }
                    catch (Exception ex) { Console.WriteLine("Error trying to kill: " + ex.Message); }

                    if (!this.doRestart)
                    {
                        this.status = estatus.stopped;
                    }

                }
                else 
                { 
                    //uh oh, that wasn't srcds
                }
            }
            if (!this.doRestart)
            {
                this.isRunning = false;
                this.status = estatus.stopped;
            }
            this.started = false;
            this.PID = 0;
            this.doRestart = false;
        }

        public void Start()
        {
            if (!this.prepped) { throw new Exception("Tried to start a server without parameters!"); }
            this.keepAlive = true;
            this.isRunning = true;
            if (!this.autoRestartEnabled) { this.autoRestarted = false; }

            while (this.keepAlive)
            {
                this.keepAlive = this.Monitor();
                if (!this.autoRestarted) { this.crashCount++; }
            }
            this.isRunning = false;
            this.crashCount = 0;

        }
        private bool Monitor()
        {

            this.doRestart = false;
            this.status = estatus.starting;
            Process srcds = new Process();

            if (this.PID > 0)
            {
                try
                {
                    Console.WriteLine("Starting with existing PID!");
                    srcds = null;
                    srcds = Process.GetProcessById(this.PID);
                    if (srcds != null && srcds.ProcessName == "srcds") { this.started = true; }
                }
                catch (Exception ex)
                {
                    // Not running, or bad PID
                    Console.WriteLine(ex.Message);
                    this.started = false;
                }
            }
            if (!this.started)
            {
                srcds = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = this.srcdsPath;
                startInfo.Arguments = this.launchArgs + " +map " + this.lastMap;
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                srcds.StartInfo = startInfo;
                
                try
                {
                    this.started = srcds.Start();
                }
                catch
                {
                    Console.WriteLine("Error launching...");
                    this.status = estatus.failed;
                    MessageBox.Show("Unable to launch server!\nCheck that the file path is correct and that you have the correct permissions to run it.", "Launch Failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Thread.Sleep(2000);

                if (this.started)
                {
                    this.isRunning = true;
                    this.keepAlive = true;
                    this.PID = srcds.Id;
                    srcds.ProcessorAffinity = (IntPtr)this.affMask;
                    srcds.PriorityClass = GetPriority(this.priority);
                    Console.WriteLine("PID: " + this.PID.ToString());
                    Console.WriteLine("Affity: " + srcds.ProcessorAffinity.ToString());
                    this.status = estatus.waiting;

                    for (int i = 0; i < this.delay; i++) // Upate status then wait 1 second, for reps specified in cfg
                    {
                        if (!this.keepAlive) { return false; }
                        this.status = estatus.waiting + " (" + (this.delay - i).ToString() + ")";

                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    Console.WriteLine("Failed to start");
                    this.isRunning = false;
                    this.status = estatus.failed;
                    return false;

                }
            }

            
            int returnCode = 0;
            while (true)
            {
                returnCode = Check();
                if (returnCode == 0) { this.doRestart = false; return false; }
                if (returnCode == 1) { this.autoRestarted = true; this.doRestart = true; this.Stop(); Thread.Sleep(1000); return true; }
                if (returnCode == 2) { this.doRestart = true; this.Stop(); Thread.Sleep(1000); return true; }
                if (returnCode > 2) { this.noResponseCount++; }
                this.status = estatus.noresponse + "(" + this.noResponseCount.ToString() + ")";
                if (this.noResponseCount >= this.threshold) { this.doRestart = true; this.Stop(); Thread.Sleep(1000); return true; }
                if (!this.keepAlive) { this.doRestart = false; return false; }

                Thread.Sleep(this.interval * 1000);
            }

        }
        private int Check()
        {
            Process p = null;
            bool responding = false;
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            mySocket.SendTimeout = 1500;
            mySocket.ReceiveTimeout = 1000;
            
            string queryString = "Source Engine Query";
            byte[] myPayload = new byte[6 + queryString.Length];
            byte[] returnedPayload = new byte[maxPacket];
            int packetLen;
            EndPoint targetServer = (EndPoint)ipPort;

            myPayload[0] = 0xFF;
            myPayload[1] = 0xFF;
            myPayload[2] = 0xFF;
            myPayload[3] = 0xFF;
            myPayload[4] = 0x54;
            myPayload[myPayload.Length - 1] = 0x00;
            System.Buffer.BlockCopy(Encoding.Default.GetBytes(queryString), 0, myPayload, 5, queryString.Length);

            while (true)
            {
                if (!this.keepAlive) { return 0; }

                if (this.autoRestartEnabled && (this.autoRestartTime.ToShortTimeString() == DateTime.Now.ToShortTimeString()) && !this.autoRestarted)
                {
                    
                    return 1;
                }
                else if (this.autoRestartEnabled && (this.autoRestartTime.ToShortTimeString() != DateTime.Now.ToShortTimeString()) && this.autoRestarted)
                {
                    this.autoRestarted = false;
                }

                try
                {
                    p = Process.GetProcessById(this.PID);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return 2;
                }

                try
                {
                    mySocket.SendTo(myPayload, this.ipPort);
                }
                catch(SocketException ex)
                {
                    mySocket.Close();
                    Console.WriteLine(ex.Message);
                    return 40;
                }

                try
                {
                    packetLen = mySocket.ReceiveFrom(returnedPayload, ref targetServer);
                }
                catch(SocketException ex)
                {
                    mySocket.Close();
                    Console.WriteLine(ex.Message);
                    return 40;
                }

                //Console.WriteLine(BitConverter.ToString(returnedPayload));
                responding = (returnedPayload[4] == 0x49) ? true : false;

                if (responding)
                {
                    this.status = estatus.running;
                    byte[] infoCache = new byte[packetLen];
					System.Buffer.BlockCopy (returnedPayload, 0, infoCache, 0, packetLen);
                    if (!DecodePacket(infoCache, packetLen).TryGetValue("map", out this.lastMap))
                    {
                        this.lastMap = this.launchMap;
                    }

                    this.noResponseCount = 0;
                }
                else
                {
                    return 50;
                }
                Thread.Sleep(interval * 1000);
                
            }
        }
        public bool IsRunning()
        {
            return this.isRunning;
        }
    }
}