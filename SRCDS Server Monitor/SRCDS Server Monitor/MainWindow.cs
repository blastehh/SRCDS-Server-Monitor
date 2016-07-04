using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using SRCDS_Server_Monitor.Properties;
using System.Diagnostics;
using System.Drawing;
using System.Xml;

namespace SRCDS_Server_Monitor
{

    public partial class MainWindow : Form
    {
        private int cpuCores = Environment.ProcessorCount;
        private bool autoStarted = false;
        private const int CP_NOCLOSE_BUTTON = 0x200; // Used to disable the close button
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private List<srcdsMonitor> allServers = new List<srcdsMonitor>();
        private System.Timers.Timer timerObject;
        private bool closingProgram = false;

        public MainWindow()
        {
            InitializeComponent();

            System.Timers.Timer statusTimer = new System.Timers.Timer();
            statusTimer.Elapsed += statusTimer_Elapsed;
            statusTimer.Interval = 1000;
            statusTimer.Enabled = false;
            statusTimer.SynchronizingObject = this;
            this.timerObject = statusTimer;
            if (Settings.Default.firstrun)
            {
                Settings.Default.Upgrade();
                Settings.Default.firstrun = false;
                Settings.Default.Save();
            }

            Settings.Default.name = Settings.Default.name ?? new StringCollection();
            Settings.Default.ip = Settings.Default.ip ?? new StringCollection();
            Settings.Default.forceip = Settings.Default.forceip ?? new StringCollection();
            Settings.Default.port = Settings.Default.port ?? new StringCollection();
            Settings.Default.maxplayers = Settings.Default.maxplayers ?? new StringCollection();
            Settings.Default.map = Settings.Default.map ?? new StringCollection();
            Settings.Default.srcdspath = Settings.Default.srcdspath ?? new StringCollection();
            Settings.Default.extracommands = Settings.Default.extracommands ?? new StringCollection();
            Settings.Default.pid = Settings.Default.pid ?? new StringCollection();
            Settings.Default.delay = Settings.Default.delay ?? new StringCollection();
            Settings.Default.autorestartenabled = Settings.Default.autorestartenabled ?? new StringCollection();
            Settings.Default.autorestarttime = Settings.Default.autorestarttime ?? new StringCollection();
            Settings.Default.affmask = Settings.Default.affmask ?? new StringCollection();
            Settings.Default.priority = Settings.Default.priority ?? new StringCollection();
            Settings.Default.autostart = Settings.Default.autostart ?? new StringCollection();

            if (Settings.Default.configvermaj == 0 && Settings.Default.configvermin == 0)
            {
                // Initial config
                Settings.Default.configvermaj = Program.versionMaj;
                Settings.Default.configvermin = Program.versionMin;
            } else
            {
                if (Settings.Default.configvermaj < Program.versionMaj || (Settings.Default.configvermaj == Program.versionMaj && Settings.Default.configvermin < Program.versionMin))
                {
                    // Out of date
                    Settings.Default.configvermaj = Program.versionMaj;
                    Settings.Default.configvermin = Program.versionMin;
                    ValidateAllSettings(true);

                }
            }

            // Load items from settings file in to the display
            PopulateServerList();

            ValidateAllSettings(false);
            ValidateButtons();
            AutoStartBegin();

        }

        private void AutoStartBegin()
        {
            if (autoStarted) { return; }
            autoStarted = true;
            for (int i = 0; i < allServers.Count; i++)
            {
                if (!allServers[i].IsRunning() && Boolean.Parse(Settings.Default.autostart[i]))
                {
                    StartServer(i);
                    Thread.Sleep(500);
                }

            }
        }

        private void ValidateAllSettings(bool forceSave)
        {
            bool needToSave = forceSave ? true : false;
            
            needToSave = ValidateSetting("ip", "127.0.0.1");
            needToSave = ValidateSetting("maxplayers", "12");
            needToSave = ValidateSetting("port", "27015");
            needToSave = ValidateSetting("map", "gm_flatgrass");
            needToSave = ValidateSetting("srcdspath", "");
            needToSave = ValidateSetting("extracommands", "-console");
            needToSave = ValidateSetting("forceip", "False");
            needToSave = ValidateSetting("pid", "0");
            needToSave = ValidateSetting("delay", "120");
            needToSave = ValidateSetting("autorestartenabled", "False");
            needToSave = ValidateSetting("autorestarttime", "00:00");
            needToSave = ValidateSetting("affmask", (Math.Pow(2, cpuCores) - 1).ToString());
            needToSave = ValidateSetting("priority", "3");
            needToSave = ValidateSetting("autostart", "False");
            if (needToSave) { Settings.Default.Save(); }
        }
        private bool ValidateSetting(string targetSetting, string defaultValue)
        {
            StringCollection targetToCheck = (StringCollection) Settings.Default[targetSetting];
            
            int targetCount = targetToCheck.Count;
            bool needToSave = false;

            if (targetCount < Settings.Default.name.Count)
            {
                for (int i = targetCount; i < Settings.Default.name.Count; i++)
                {
                    targetToCheck.Add(defaultValue);
                }
                needToSave = true;
            }
            return needToSave;
        }

        void statusTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) // Timer tick event
        {
            var items = serversList.Items;
            //int serversStarted = 0;
            int changed = 0;
            for (int i = 0; i < allServers.Count; i++)
            {
                try
                {
                    if (items[i].SubItems[5].Text != allServers[i].crashes.ToString()) { items[i].SubItems[5].Text = allServers[i].crashes.ToString(); }
                    if (items[i].SubItems[1].Text != allServers[i].getStatus)
                    {
                        items[i].SubItems[1].Text = allServers[i].getStatus ?? "Unknown";
                        if (items[i].SubItems[1].Text != "Unknown")
                        {
                            if (items[i].SubItems[1].Text == estatus.running) { items[i].BackColor = Color.LightGreen; }
                            else if (items[i].SubItems[1].Text == estatus.starting || items[i].SubItems[1].Text.StartsWith(estatus.waiting)) { items[i].BackColor = Color.NavajoWhite; }
                            else { items[i].BackColor = Color.IndianRed; }
                        }


                    }

                    if (Settings.Default.pid[i] != allServers[i].pid.ToString())
                    {
                        Settings.Default.pid[i] = allServers[i].pid.ToString();
                        changed++;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("I brokesies");
                    Console.WriteLine(ex.Message);
                    timerObject.Stop();
                }
            }
            if (changed > 0)
            {
                Settings.Default.Save();
            }

            ValidateButtons(); // Putting this here is hacky, because I don't know how to update the buttons after it gets pressed.

            // Code below causes issues if server crashes; the timer never returns :(      
            /*    if (allServers[i].started)
                      {
                          serversStarted++;
                      }
                  }
            
                  if (serversStarted < 1) // If there are no servers started, disable the timer.
                  {
                      timerObject.Enabled = false;
                  }
                   */
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //confirmation for exit?
            bool running = false;
            foreach (var item in allServers)
            {
                if (item.IsRunning())
                {
                    running = true;
                    break;
                }
            }
            if (running)
            {
                var confirmResult = MessageBox.Show("You still have servers running!\nPress OK to exit anyway, but leave the servers running.",
                        "Servers are running!",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
                if (confirmResult == DialogResult.OK)
                {
                    foreach (var server in allServers)
                    {
                        if (server.IsRunning())
                        {
                            server.runThread.Abort(); // Kill the monitoring thread
                        }

                    }
                    closingProgram = true;
                    Settings.Default.Save();
                    Application.Exit();
                }
                else { return; }

            }
            else
            {
                closingProgram = true;
                Settings.Default.Save();
                Application.Exit();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateButtons();
        }

        private void ValidateButtons()
        {
            try
            {
                bool canStart = false;
                bool canStop = false;
                bool canRestart = false;
                bool canDelete = false;
                bool canEdit = false;
                bool multiSelect = false;
                int running = 0;
                int stopped = 0;

                if (serversList.SelectedItems.Count > 0)
                {
                    var itemIDX = serversList.SelectedIndices[0];
                    if (serversList.SelectedItems.Count > 1)
                    {
                        multiSelect = true;
                        canDelete = false;
                        canEdit = false;
                    }


                    for (int i = 0; i < serversList.SelectedIndices.Count; i++)
                    {
                        var idx = serversList.SelectedItems[i].Index;

                        if (allServers[idx].IsRunning())
                        {
                            running++;
                        }
                    }


                    for (int i = 0; i < serversList.SelectedIndices.Count; i++)
                    {
                        var idx = serversList.SelectedItems[i].Index;

                        if (!allServers[idx].IsRunning())
                        {
                            stopped++;
                        }
                    }

                }
                else
                {
                    canEdit = false;
                    canDelete = false;
                    canStart = false;
                    canStop = false;
                    canRestart = false;
                }
                if (running > 0) { canStop = true; canRestart = true; }
                if (stopped > 0) { canStart = true; }
                if (stopped > 0 && !multiSelect) { canEdit = true; canDelete = true; }

                if (canEdit) { editServerButton.Enabled = true; } else { editServerButton.Enabled = false; }
                if (canStart) { startButton.Enabled = true; } else { startButton.Enabled = false; }
                if (canStop) { stopButton.Enabled = true; } else { stopButton.Enabled = false; }
                if (canDelete) { deleteServerButton.Enabled = true; } else { deleteServerButton.Enabled = false; }
                if (canRestart) { restartButton.Enabled = true; } else { restartButton.Enabled = false; }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void addServerButton_Click(object sender, EventArgs e) // Add Server button
        {
            //var selectItem = serversList.SelectedIndices[0];
            AddServerDialog addServerForm = new AddServerDialog();
            addServerForm.priority = 3;
            DialogResult addServerRes = addServerForm.ShowDialog();
            if (addServerRes == DialogResult.OK)
            {
                ListViewItem newListEntry = new ListViewItem(addServerForm.serverName); //0
                newListEntry.SubItems.Add("Unknown");                          //1 Status
                newListEntry.SubItems.Add(addServerForm.ip);                   //2 IP Address
                newListEntry.SubItems.Add(addServerForm.port);                 //3 Port
                newListEntry.SubItems.Add(addServerForm.maxPlayers);           //4 Max Players
                newListEntry.SubItems.Add("0");                                //5 Crash count

                /*
                item1.SubItems.Add(addServerForm.map);                  //5 Map
                item1.SubItems.Add(addServerForm.srcdsPath);            //6 SRCDS Path
                item1.SubItems.Add(addServerForm.extraCommands);        //7 Extra Commands
                item1.SubItems.Add(addServerForm.forceip.ToString());   //8 Force IP Option
                item1.SubItems.Add(addServerForm.pid);                  //9 PID
                item1.SubItems.Add(addServerForm.delay);                //10 Delay time
                 */

                serversList.Items.AddRange(new ListViewItem[] { newListEntry });

                srcdsMonitor newServer = new srcdsMonitor();
                allServers.Add(newServer);

                Settings.Default.name.Add(addServerForm.serverName);
                Settings.Default.ip.Add(addServerForm.ip);
                Settings.Default.maxplayers.Add(addServerForm.maxPlayers);
                Settings.Default.port.Add(addServerForm.port);
                Settings.Default.map.Add(addServerForm.map);
                Settings.Default.srcdspath.Add(addServerForm.srcdsPath);
                Settings.Default.extracommands.Add(addServerForm.extraCommands);
                Settings.Default.forceip.Add(addServerForm.forceip.ToString());
                Settings.Default.pid.Add(addServerForm.pid);
                Settings.Default.delay.Add(addServerForm.delay);
                Settings.Default.autorestartenabled.Add(addServerForm.autoRestartEnabled.ToString());
                Settings.Default.autorestarttime.Add(addServerForm.autoRestartTime.ToShortTimeString());
                Settings.Default.affmask.Add(((int)addServerForm.cpuMask).ToString());
                Settings.Default.priority.Add(addServerForm.priority.ToString());
                Settings.Default.autostart.Add(addServerForm.autoStartEnabled.ToString());
                Settings.Default.Save();

            }
        }

        private void deleteServerButton_Click(object sender, EventArgs e)
        {
            if (serversList.SelectedItems.Count > 0 && serversList.SelectedItems.Count < 2)
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete this server?",
                        "Delete server?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirmResult == DialogResult.Yes)
                {
                    var itemIDX = serversList.SelectedIndices[0];
                    foreach (ListViewItem eachItem in serversList.SelectedItems)
                    {
                        serversList.Items.Remove(eachItem);
                    }
                    allServers.RemoveAt(itemIDX);
                    Settings.Default.name.RemoveAt(itemIDX);
                    Settings.Default.ip.RemoveAt(itemIDX);
                    Settings.Default.forceip.RemoveAt(itemIDX);
                    Settings.Default.maxplayers.RemoveAt(itemIDX);
                    Settings.Default.port.RemoveAt(itemIDX);
                    Settings.Default.map.RemoveAt(itemIDX);
                    Settings.Default.srcdspath.RemoveAt(itemIDX);
                    Settings.Default.extracommands.RemoveAt(itemIDX);
                    Settings.Default.pid.RemoveAt(itemIDX);
                    Settings.Default.delay.RemoveAt(itemIDX);
                    Settings.Default.autorestartenabled.RemoveAt(itemIDX);
                    Settings.Default.autorestarttime.RemoveAt(itemIDX);
                    Settings.Default.affmask.RemoveAt(itemIDX);
                    Settings.Default.priority.RemoveAt(itemIDX);
                    Settings.Default.autostart.RemoveAt(itemIDX);
                    Settings.Default.Save();
                }

            }
        }

        private void editServerButton_Click(object sender, EventArgs e) // Edit Server button
        {
            if (serversList.SelectedItems.Count == 1)
            {

                var itemIDX = serversList.SelectedIndices[0];
                if (allServers[itemIDX].IsRunning()) { return; }
                ListViewItem item = serversList.SelectedItems[0];

                AddServerDialog addServerForm = new AddServerDialog();
                addServerForm.Text = "Edit Server";
                addServerForm.serverName = item.SubItems[0].Text;
                addServerForm.ip = Settings.Default.ip[itemIDX]; //item.SubItems[2].Text;
                addServerForm.port = Settings.Default.port[itemIDX]; //item.SubItems[3].Text;
                addServerForm.maxPlayers = Settings.Default.maxplayers[itemIDX]; //item.SubItems[4].Text;
                addServerForm.map = Settings.Default.map[itemIDX]; // item.SubItems[5].Text;
                addServerForm.srcdsPath = Settings.Default.srcdspath[itemIDX]; //item.SubItems[6].Text;
                addServerForm.extraCommands = Settings.Default.extracommands[itemIDX]; //item.SubItems[7].Text;
                addServerForm.forceip = Boolean.Parse(Settings.Default.forceip[itemIDX]); //Boolean.Parse(item.SubItems[8].Text);
                addServerForm.pid = Settings.Default.pid[itemIDX]; //item.SubItems[9].Text;
                addServerForm.delay = Settings.Default.delay[itemIDX]; //item.SubItems[10].Text;
                addServerForm.priority = Int32.Parse(Settings.Default.priority[itemIDX]);
                addServerForm.autoStartEnabled = Boolean.Parse(Settings.Default.autostart[itemIDX]);
                int priorityNum;
                if (int.TryParse(Settings.Default.priority[itemIDX], out priorityNum))
                { 
                    addServerForm.priority = (priorityNum >= 0 && priorityNum <= 5) ? priorityNum : 3;
                }
                
                int tempMask = 0;
                bool maskOK = Int32.TryParse(Settings.Default.affmask[itemIDX], out tempMask);
                addServerForm.cpuMask = (maskOK) ? tempMask : (int)(Math.Pow(2, Environment.ProcessorCount) - 1);

                DateTime restartTime = new DateTime();
                DateTime.TryParse(Settings.Default.autorestarttime[itemIDX], out restartTime);
                addServerForm.autoRestartTime = restartTime;

                bool autoRestartBool = false;
                addServerForm.autoRestartEnabled = (bool.TryParse(Settings.Default.autorestartenabled[itemIDX], out autoRestartBool)) ? autoRestartBool : false;

                DialogResult addServerRes = addServerForm.ShowDialog();
                if (addServerRes == DialogResult.OK)
                {
                    Settings.Default.name[itemIDX] = item.SubItems[0].Text = addServerForm.serverName;
                    Settings.Default.ip[itemIDX] = item.SubItems[2].Text = addServerForm.ip;
                    Settings.Default.maxplayers[itemIDX] = item.SubItems[4].Text = addServerForm.maxPlayers;
                    Settings.Default.port[itemIDX] = item.SubItems[3].Text = addServerForm.port;
                    Settings.Default.map[itemIDX] = addServerForm.map;
                    Settings.Default.srcdspath[itemIDX] = addServerForm.srcdsPath;
                    Settings.Default.extracommands[itemIDX] = addServerForm.extraCommands;
                    Settings.Default.forceip[itemIDX] = addServerForm.forceip.ToString();
                    Settings.Default.pid[itemIDX] = addServerForm.pid;
                    allServers[itemIDX].pid = Int32.Parse(addServerForm.pid);
                    Settings.Default.delay[itemIDX] = addServerForm.delay;
                    Settings.Default.autorestartenabled[itemIDX] = addServerForm.autoRestartEnabled.ToString();
                    Settings.Default.autorestarttime[itemIDX] = addServerForm.autoRestartTime.ToShortTimeString();
                    Settings.Default.affmask[itemIDX] = addServerForm.cpuMask.ToString();
                    Settings.Default.priority[itemIDX] = addServerForm.priority.ToString();
                    Settings.Default.autostart[itemIDX] = addServerForm.autoStartEnabled.ToString();
                    Settings.Default.Save();

                }

            }
        }

        private void StartServer(int itemIDX)
        {

            Console.WriteLine("Start Button...Running? " + allServers[itemIDX].IsRunning().ToString());
            ListViewItem item = serversList.Items[itemIDX];

            // Grabbing settings and validating values.
            int n;
            string startIP = Settings.Default.ip[itemIDX]; //item.SubItems[1].Text;

            string maxPlayers = Settings.Default.maxplayers[itemIDX]; //item.SubItems[2].Text;
            if (Int32.TryParse(maxPlayers, out n)) { if (n < 1) { maxPlayers = "1"; } } else { MessageBox.Show("Invalid value for max players!\nCheck your configs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string startPort = Settings.Default.port[itemIDX]; //item.SubItems[4].Text;
            if (Int32.TryParse(startPort, out n))
            {
                if ((n < 2) || (n > 65535))
                {
                    MessageBox.Show("Port setting is out of range!\nCheck your settings.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Invalid port setting!\nCheck your configs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string map = Settings.Default.map[itemIDX]; //item.SubItems[5].Text;
            if (map == "") { MessageBox.Show("No starting map was selected!\nThe server will not launch", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            string srcdsPath = Settings.Default.srcdspath[itemIDX]; //item.SubItems[6].Text;
            string extraLaunchCMD = Settings.Default.extracommands[itemIDX]; //item.SubItems[7].Text;

            bool forceip = false;
            Boolean.TryParse(Settings.Default.forceip[itemIDX], out forceip);
            int pid;
            if (Int32.TryParse(Settings.Default.pid[itemIDX], out pid)) { if (pid < 0) { pid = 0; } } else { pid = 0; }

            int delay;
            if (Int32.TryParse(Settings.Default.delay[itemIDX], out delay)) { delay = (delay < 10) ? 10 : delay; }

            int interval = (Settings.Default.interval < 1) ? 4 : Settings.Default.interval; // If interval is less than 1 then set to 4, otherwise keep setting.
            int threshold = (Settings.Default.threshold < 1) ? 5 : Settings.Default.threshold;

            var argMaxP = " +maxplayers " + maxPlayers;
            var argMap = map;
            var argPort = " -port " + startPort;
            var argExtraCMD = extraLaunchCMD;
            var argIP = (forceip) ? "+ip " + startIP + " " : "";

            string startLaunchCMD = argIP + argMaxP + argPort + " -console " + argExtraCMD;

            DateTime autoRestartTime = new DateTime();
            DateTime.TryParse(Settings.Default.autorestarttime[itemIDX], out autoRestartTime);

            bool autoRestartEnabled = false;
            bool.TryParse(Settings.Default.autorestartenabled[itemIDX], out autoRestartEnabled);
            int tempMask;
            int affMask = (Int32.TryParse(Settings.Default.affmask[itemIDX], out tempMask)) ? tempMask : (int)(Math.Pow(2, cpuCores) - 1);
            int priorityNum = 3;
            if (int.TryParse(Settings.Default.priority[itemIDX], out priorityNum))
            {
                priorityNum = (priorityNum >= 0 && priorityNum <= 5) ? priorityNum : 3;
            }
            IPAddress address;
            if (IPAddress.TryParse(startIP, out address))
            {
                switch (address.AddressFamily)
                {
                    case System.Net.Sockets.AddressFamily.InterNetwork: // Only supporting IPv4 atm

                        allServers[itemIDX].Prep(srcdsPath, argMap, startLaunchCMD, address, Int32.Parse(startPort), delay, pid, interval, threshold, autoRestartTime, autoRestartEnabled, affMask, priorityNum); // Prepare the launch args
                        Thread oThread = new Thread(new ThreadStart(allServers[itemIDX].Start));
                        allServers[itemIDX].runThread = oThread;
                        allServers[itemIDX].runThread.Start();
                        timerObject.Enabled = true;
                        break;
                    /*case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        // we have IPv6
                        MessageBox.Show("Only IPv4 Addresses are supported!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;*/
                    default:
                        MessageBox.Show("Only IPv4 Addresses are supported!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            }
            else // Not a valid ip address
            {
                MessageBox.Show("The IP setting for this server is corrupt!\nPlease check your configs.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = false;
            deleteServerButton.Enabled = false;

            if (serversList.SelectedItems.Count > 0)
            {

                for (int i = 0; i < serversList.SelectedIndices.Count; i++)
                {
                    var idx = serversList.SelectedItems[i].Index;
                    if (!allServers[idx].IsRunning())
                    {
                        StartServer(idx);
                    }
                    Thread.Sleep(250);

                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

            if (serversList.SelectedItems.Count > 0)
            {

                bool serversRunning = false;
                foreach (int idx in serversList.SelectedIndices)
                {
                    if (allServers[idx].IsRunning())
                    {
                        serversRunning = true;
                        break;
                    }
                }

                if (serversRunning)
                {
                    var confirmResult = MessageBox.Show("Stop selected servers?",
                        "Stop servers?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        foreach (int idx in serversList.SelectedIndices)
                        {

                            if (allServers[idx].IsRunning())
                            {
                                allServers[idx].Stop();
                                Thread.Sleep(250);
                            }

                        }
                    }
                }

            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (serversList.SelectedItems.Count > 0)
            {
                bool serversRunning = false;

                foreach (int idx in serversList.SelectedIndices)
                {
                    if (allServers[idx].IsRunning())
                    {
                        serversRunning = true;
                        break;
                    }
                }
                if (serversRunning)
                {
                    var confirmResult = MessageBox.Show("Restart selected servers?",
                        "Restart servers?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirmResult == DialogResult.Yes)
                    {
                        for (int i = 0; i < serversList.SelectedIndices.Count; i++)
                        {
                            var idx = serversList.SelectedItems[i].Index;
                            if (allServers[idx].IsRunning())
                            {
                                allServers[idx].Stop();
                                allServers[idx].runThread.Join();
                                StartServer(idx);
                            }
                        }
                    }
                }
            }
        }

        private void startAllToolStripMenuItem_Click(object sender, EventArgs e)
        {                                                                               //start all
            var confirmResult = MessageBox.Show("Start all servers?",
                        "Start all servers?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {

                for (int i = 0; i < allServers.Count; i++)
                {
                    if (!allServers[i].IsRunning())
                    {
                        StartServer(i);
                        Thread.Sleep(500);
                    }

                }
            }
        }

        private void restartAllToolStripMenuItem_Click(object sender, EventArgs e)
        {                                                                              //restart all
            var confirmResult = MessageBox.Show("Restart ALL servers?!",
                        "Restart ALL servers?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {

                for (int i = 0; i < allServers.Count; i++)
                {
                    if (allServers[i].IsRunning())
                    {
                        allServers[i].Stop();
                        allServers[i].runThread.Join();
                        serversList.Items[i].SubItems[5].Text = "0"; //Reset crash counter
                        StartServer(i);
                    }
                }

            }


        }

        private void stopAllToolStripMenuItem_Click(object sender, EventArgs e)
        {                                                                           //stop all servers button
            var confirmResult = MessageBox.Show("Stop ALL servers?!",
                        "Stop ALL servers?",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                for (int i = 0; i < allServers.Count; i++)
                {
                    if (allServers[i].IsRunning())
                    {
                        allServers[i].Stop();
                        allServers[i].runThread.Join();
                        serversList.Items[i].SubItems[5].Text = "0"; //Reset crash counter
                    }
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) // Options
        {
            optionsWindow optionsForm = new optionsWindow();
            optionsForm.interval = Settings.Default.interval.ToString();
            optionsForm.threshold = Settings.Default.threshold.ToString();
            DialogResult isOK = optionsForm.ShowDialog();
            if (isOK == DialogResult.OK)
            {
                Settings.Default.interval = Int32.Parse(optionsForm.interval);
                Settings.Default.threshold = Int32.Parse(optionsForm.threshold);
                Settings.Default.Save();
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingProgram)
            {
                e.Cancel = true;
            }

        }

        private void aboutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://banana-ph.com/index.php/srcds-server-monitor");
        }

        private void addServerButton_EnabledChanged(object sender, EventArgs e)
        {
            addServerButton.ForeColor = (addServerButton.Enabled) ? Color.White : Color.DarkGray;
        }

        private void editServerButton_EnabledChanged(object sender, EventArgs e)
        {
            editServerButton.ForeColor = (editServerButton.Enabled) ? Color.White : Color.DarkGray;
        }

        private void startButton_EnabledChanged(object sender, EventArgs e)
        {
            startButton.ForeColor = (startButton.Enabled) ? Color.White : Color.DarkGray;
        }

        private void restartButton_EnabledChanged(object sender, EventArgs e)
        {
            restartButton.ForeColor = (restartButton.Enabled) ? Color.White : Color.DarkGray;
        }

        private void stopButton_EnabledChanged(object sender, EventArgs e)
        {
            stopButton.ForeColor = (stopButton.Enabled) ? Color.White : Color.DarkGray;
        }

        private void deleteServerButton_EnabledChanged(object sender, EventArgs e)
        {
            deleteServerButton.ForeColor = (deleteServerButton.Enabled) ? Color.White : Color.DarkGray;
        }

        // Import xml settings file
        private void importSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check for running servers first

            bool running = false;
            foreach (var item in allServers)
            {
                if (item.IsRunning())
                {
                    running = true;
                    break;
                }
            }
            if (running)
            {
                var confirmResult = MessageBox.Show("Stop all running servers first!",
                        "Servers are running!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            // Check for existing servers?
            var serverListCount = serversList.Items.Count;
            if (serverListCount > 0)
            {
                var overwriteResult = MessageBox.Show("This will overwrite your existing servers!",
                    "Overwrite?",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (overwriteResult != DialogResult.OK) { return; }
            }

            OpenFileDialog importSelect = new OpenFileDialog();
            importSelect.Multiselect = false;
            importSelect.Filter = "XML|*.xml";
            importSelect.Title = "Import Config";
            importSelect.ShowDialog();
            if (importSelect.FileName != "")
            {
                //Clear current config!
                

                foreach (ListViewItem eachItem in serversList.Items)
                {
                    serversList.Items.Remove(eachItem);
                }
                for (int itemIDX = serverListCount -1 ; itemIDX >= 0; itemIDX--)
                {
			        allServers.RemoveAt(itemIDX);
                    Settings.Default.name.RemoveAt(itemIDX);
                    Settings.Default.ip.RemoveAt(itemIDX);
                    Settings.Default.forceip.RemoveAt(itemIDX);
                    Settings.Default.maxplayers.RemoveAt(itemIDX);
                    Settings.Default.port.RemoveAt(itemIDX);
                    Settings.Default.map.RemoveAt(itemIDX);
                    Settings.Default.srcdspath.RemoveAt(itemIDX);
                    Settings.Default.extracommands.RemoveAt(itemIDX);
                    Settings.Default.pid.RemoveAt(itemIDX);
                    Settings.Default.delay.RemoveAt(itemIDX);
                    Settings.Default.autorestartenabled.RemoveAt(itemIDX);
                    Settings.Default.autorestarttime.RemoveAt(itemIDX);
                    Settings.Default.affmask.RemoveAt(itemIDX);
                    Settings.Default.priority.RemoveAt(itemIDX);
                    Settings.Default.autostart.RemoveAt(itemIDX);
			    }

                // Read file
                using (XmlReader reader = XmlReader.Create(importSelect.FileName))
                {
                    int loadedVerMaj = 0;
                    int loadedVerMin = 0;
                    int serverCount = -1;
                    while (reader.Read())
                    {
                        // Only detect start elements.
                        if (reader.IsStartElement())
                        {
                            // Get element name and switch on it.
                            switch (reader.Name)
                            {
                                case "Interval":
                                    if (reader.Read())
                                    {
                                        int num;
                                        Settings.Default.interval = (int.TryParse(reader.Value.Trim(), out num)) ? num : 4;
                                    }
                                    break;

                                case "Threshold":
                                    if (reader.Read())
                                    {
                                        int num;
                                        Settings.Default.threshold = (int.TryParse(reader.Value.Trim(), out num)) ? num : 5;
                                    }
                                    break;

                                case "ConfigMaj":
                                    if (reader.Read())
                                    {
                                        int num;
                                        loadedVerMaj = (int.TryParse(reader.Value.Trim(), out num)) ? num : 0;
                                    }
                                    break;

                                case "ConfigMin":
                                    if (reader.Read())
                                    {
                                        int num;
                                        loadedVerMin = (int.TryParse(reader.Value.Trim(), out num)) ? num : 12;
                                    }
                                    break;

                                case "Servers":
                                    break;

                                case "Server":
                                    serverCount++;
                                    break;
                                
                                case "Name":
                                    if (reader.Read()) 
                                    { 
                                        Settings.Default.name.Add(reader.Value.Trim()); 
                                        Settings.Default.name[serverCount] = (Settings.Default.name[serverCount] == "") ? "Unnamed" : Settings.Default.name[serverCount];
                                    }
                                    Settings.Default.pid.Add("0");
                                    break;

                                case "IP":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.ip.Add(reader.Value.Trim());
                                        Settings.Default.ip[serverCount] = (Settings.Default.ip[serverCount] == "") ? "127.0.0.1" : Settings.Default.ip[serverCount];
                                    }
                                    break;

                                case "Port":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.port.Add(reader.Value.Trim());
                                        Settings.Default.port[serverCount] = (Settings.Default.port[serverCount] == "") ? "27015" : Settings.Default.port[serverCount];
                                    }
                                    break;

                                case "Maxplayers":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.maxplayers.Add(reader.Value.Trim());
                                        Settings.Default.maxplayers[serverCount] = (Settings.Default.maxplayers[serverCount] == "") ? "12" : Settings.Default.maxplayers[serverCount];
                                    }
                                    break;

                                case "Map":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.map.Add(reader.Value.Trim());
                                        Settings.Default.map[serverCount] = (Settings.Default.map[serverCount] == "") ? "gm_flatgrass" : Settings.Default.map[serverCount];
                                    }
                                    break;

                                case "Srcdspath":
                                    if (reader.Read())
                                    {
                                        Settings.Default.srcdspath.Add(reader.Value.Trim());
                                    }
                                    break;

                                case "Extracommands":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.extracommands.Add(reader.Value.Trim()); 
                                    }
                                    break;

                                case "Forceip":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.forceip.Add(reader.Value.Trim());
                                        Settings.Default.forceip[serverCount] = (Settings.Default.forceip[serverCount] == "") ? "False" : Settings.Default.forceip[serverCount];
                                    }
                                    break;

                                case "Delay":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.delay.Add(reader.Value.Trim());
                                        Settings.Default.delay[serverCount] = (Settings.Default.delay[serverCount] == "") ? "120" : Settings.Default.delay[serverCount];
                                    }
                                    break;

                                case "Autorestartenabled":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.autorestartenabled.Add(reader.Value.Trim());
                                        Settings.Default.autorestartenabled[serverCount] = (Settings.Default.autorestartenabled[serverCount] == "") ? "False" : Settings.Default.autorestartenabled[serverCount];
                                    }
                                    break;

                                case "Autorestarttime":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.autorestarttime.Add(reader.Value.Trim());
                                        Settings.Default.autorestarttime[serverCount] = (Settings.Default.autorestarttime[serverCount] == "") ? "00:00" : Settings.Default.autorestarttime[serverCount];
                                    }
                                    break;

                                case "Affinitymask":
                                    if (reader.Read()) 
                                    {
                                        Settings.Default.affmask.Add(reader.Value.Trim());
                                        Settings.Default.affmask[serverCount] = (Settings.Default.affmask[serverCount] == "") ? (Math.Pow(2, cpuCores) - 1).ToString() : Settings.Default.affmask[serverCount];
                                    }
                                    break;

                                case "Priority":
                                    if (reader.Read())
                                    {
                                        Settings.Default.priority.Add(reader.Value.Trim());
                                        Settings.Default.priority[serverCount] = (Settings.Default.priority[serverCount] == "") ? "3" : Settings.Default.priority[serverCount];
                                    }
                                    break;

                                case "Autostart":
                                    if (reader.Read())
                                    {
                                        Settings.Default.autostart.Add(reader.Value.Trim());
                                        Settings.Default.autostart[serverCount] = (Settings.Default.autostart[serverCount] == "") ? "False" : Settings.Default.autostart[serverCount];
                                    }
                                    break;

                                default:
                                    break;
                            }// End of switch
                        }

                    }// End of while reader.Read()

                    if (loadedVerMaj < Program.versionMaj || (loadedVerMaj == Program.versionMaj && loadedVerMin < Program.versionMin))
                    {
                        // Old config loaded
                    }

                }// End of Using
                

                ValidateAllSettings(true);
                PopulateServerList();
            }
            
        }

        private void PopulateServerList()
        {
            if (Settings.Default.name != null && Settings.Default.name.Count > 0) // Do we have items to load in to the display?
            {
                for (int i = 0; i < Settings.Default.name.Count; i++)
                {
                    ListViewItem item1 = new ListViewItem(Settings.Default.name[i]); //0 Server's display name
                    item1.SubItems.Add("Unknown");                              //1 Status - Always start as unknown
                    item1.SubItems.Add(Settings.Default.ip[i]);                 //2 IP Address
                    item1.SubItems.Add(Settings.Default.port[i]);               //3 Port
                    item1.SubItems.Add(Settings.Default.maxplayers[i]);         //4 Max Players
                    item1.SubItems.Add("0");                                    //5 Crash Counter

                    serversList.Items.AddRange(new ListViewItem[] { item1 });     // Add row to the displayed list of servers
                    srcdsMonitor newServer = new srcdsMonitor();
                    allServers.Add(newServer);                                  // Create a new srcdsMonitor object for this row and add it to our list.

                }
            }
        }

        private void exportSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog exportSelect = new SaveFileDialog();
            exportSelect.Filter = "XML|*.xml";
            exportSelect.Title = "Save Config";
            exportSelect.ShowDialog();
            if (exportSelect.FileName != "")
            {
                string savePath = exportSelect.FileName;
                //do xml save
                XmlWriterSettings xmlSettings = new XmlWriterSettings();
                xmlSettings.Indent = true;
                xmlSettings.NewLineOnAttributes = true;
                using (XmlWriter writer = XmlWriter.Create(savePath, xmlSettings))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("SRCDSMonitor");

                    writer.WriteStartElement("Options");
                    writer.WriteElementString("Interval", Settings.Default.interval.ToString() );
                    writer.WriteElementString("Threshold", Settings.Default.threshold.ToString() );
                    writer.WriteElementString("ConfigMaj", Program.versionMaj.ToString());
                    writer.WriteElementString("ConfigMin", Program.versionMin.ToString());
                    writer.WriteEndElement();

                    writer.WriteStartElement("Servers");

                    var numOfServers = serversList.Items.Count;

                    for (int i = 0; i < numOfServers; i++)
                    {
                        writer.WriteStartElement("Server");
                        
                        writer.WriteElementString("Name", Settings.Default.name[i]);
                        writer.WriteElementString("IP", Settings.Default.ip[i]);
                        writer.WriteElementString("Port", Settings.Default.port[i]);
                        writer.WriteElementString("Maxplayers", Settings.Default.maxplayers[i]);
                        writer.WriteElementString("Map", Settings.Default.map[i]);
                        writer.WriteElementString("Srcdspath", Settings.Default.srcdspath[i]);
                        writer.WriteElementString("Extracommands", Settings.Default.extracommands[i]);
                        writer.WriteElementString("Forceip", Settings.Default.forceip[i]);
                        writer.WriteElementString("Delay", Settings.Default.delay[i]);
                        writer.WriteElementString("Autorestartenabled", Settings.Default.autorestartenabled[i]);
                        writer.WriteElementString("Autorestarttime", Settings.Default.autorestarttime[i]);
                        writer.WriteElementString("Affinitymask", Settings.Default.affmask[i]);
                        writer.WriteElementString("Priority", Settings.Default.priority[i]);
                        writer.WriteElementString("Autostart", Settings.Default.autostart[i]);
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            
        }
    }

}
