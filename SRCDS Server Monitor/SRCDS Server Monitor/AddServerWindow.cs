using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace SRCDS_Server_Monitor
{
    public enum affEnum
    {
        c1 = 1,
        c2 = 2,
        c3 = 4,
        c4 = 8,
        c5 = 16,
        c6 = 32,
        c7 = 64,
        c8 = 128,
        c9 = 256,
        c10 = 512,
        c11 = 1024,
        c12 = 2048,
        c13 = 4096,
        c14 = 8192,
        c15 = 16384,
        c16 = 32768
    }

    public partial class AddServerDialog : Form
    {
        private affEnum aMask;
        private affEnum affMask = (affEnum)(Math.Pow(2, Environment.ProcessorCount) - 1);
        public string windowTitle
        {
            set { this.Text = value; }
        }
        public string serverName
        {
            get { return serverNameText.Text; }
            set { serverNameText.Text = value; }
        }
        public string ip
        {
            get { return ipText.Text; }
            set { ipText.Text = value; }
        }
        public string pid
        {
            get { return pidText.Text; }
            set { pidText.Text = value; }
        }
        public bool forceip
        {
            get { return ipCheckBox.Checked; }
            set { ipCheckBox.Checked = value; }
        }
        public string delay
        {
            get { return delayText.Text; }
            set { delayText.Text = value; }
        }
        public string maxPlayers
        {
            get { return maxPlayersText.Text; }
            set { maxPlayersText.Text = value; }
        }
        public string port
        {
            get { return portText.Text; }
            set { portText.Text = value; }
        }
        public string map
        {
            get { return mapText.Text; }
            set { mapText.Text = value; }
        }
        public string srcdsPath
        {
            get { return srcdsPathText.Text; }
            set { srcdsPathText.Text = value; }
        }
        public string extraCommands
        {
            get { return extraCommandsText.Text; }
            set { extraCommandsText.Text = value; }
        }
        public DateTime autoRestartTime
        {
            get { return timePicker.Value; }
            set { timePicker.Value = value; }
        }
        public bool autoRestartEnabled
        {
            get { return autoRestartCheckbox.Checked; }
            set { autoRestartCheckbox.Checked = value; }
        }
        public int cpuMask
        {
            get { return (int)aMask; }
            set { aMask = (affEnum)value; }
        }

        public int priority
        {
            get { return priorityComboBox.SelectedIndex; }
            set { priorityComboBox.SelectedIndex = value;}
        }

        public bool autoStartEnabled
        {
            get { return autoStartCheckBox.Checked; }
            set { autoStartCheckBox.Checked = value; }
        }
        

        public AddServerDialog()
        {
            InitializeComponent();
            
            
            affBox1.Enabled = ((affMask & affEnum.c1) == affEnum.c1) ? true : false;
            affBox2.Enabled = ((affMask & affEnum.c2) == affEnum.c2) ? true : false;
            affBox3.Enabled = ((affMask & affEnum.c3) == affEnum.c3) ? true : false;
            affBox4.Enabled = ((affMask & affEnum.c4) == affEnum.c4) ? true : false;
            affBox5.Enabled = ((affMask & affEnum.c5) == affEnum.c5) ? true : false;
            affBox6.Enabled = ((affMask & affEnum.c6) == affEnum.c6) ? true : false;
            affBox7.Enabled = ((affMask & affEnum.c7) == affEnum.c7) ? true : false;
            affBox8.Enabled = ((affMask & affEnum.c8) == affEnum.c8) ? true : false;
            affBox9.Enabled = ((affMask & affEnum.c9) == affEnum.c9) ? true : false;
            affBox10.Enabled = ((affMask & affEnum.c10) == affEnum.c10) ? true : false;
            affBox11.Enabled = ((affMask & affEnum.c11) == affEnum.c11) ? true : false;
            affBox12.Enabled = ((affMask & affEnum.c12) == affEnum.c12) ? true : false;
            affBox13.Enabled = ((affMask & affEnum.c13) == affEnum.c13) ? true : false;
            affBox14.Enabled = ((affMask & affEnum.c14) == affEnum.c14) ? true : false;
            affBox15.Enabled = ((affMask & affEnum.c15) == affEnum.c15) ? true : false;
            affBox16.Enabled = ((affMask & affEnum.c16) == affEnum.c16) ? true : false;

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (serverNameText.TextLength < 1)
            {
                serverNameText.Text = "Unnamed Server";
            }

            if (mapText.TextLength < 1 || ipText.TextLength < 7)
            {
                MessageBox.Show("Please fill in the required information!", "Error!");
            }
            else
            {
                updateLaunchCommand();
                aMask = 0;
                aMask += (affBox1.Checked) ? 1 : 0;
                aMask += (affBox2.Checked) ? 2 : 0;
                aMask += (affBox3.Checked) ? 4 : 0;
                aMask += (affBox4.Checked) ? 8 : 0;
                aMask += (affBox5.Checked) ? 16 : 0;
                aMask += (affBox6.Checked) ? 32: 0;
                aMask += (affBox7.Checked) ? 64 : 0;
                aMask += (affBox8.Checked) ? 128 : 0;
                aMask += (affBox9.Checked) ? 256 : 0;
                aMask += (affBox10.Checked) ? 512 : 0;
                aMask += (affBox11.Checked) ? 1024 : 0;
                aMask += (affBox12.Checked) ? 2048 : 0;
                aMask += (affBox13.Checked) ? 4096 : 0;
                aMask += (affBox14.Checked) ? 8192 : 0;
                aMask += (affBox15.Checked) ? 16384 : 0;
                aMask += (affBox16.Checked) ? 32768 : 0;

                this.DialogResult = DialogResult.OK;
                this.Close();

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                srcdsPathText.Text = path;

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addServerDialog_Load(object sender, EventArgs e)
        {

        }
        private void updateLaunchCommand()
        {
            var maxp = " +maxplayers " + maxPlayersText.Text;
            var map = "+map " + mapText.Text;
            var port = " -port " + portText.Text;
            var extraCMD = extraCommandsText.Text + " ";
            var ip = " ";
            if (ipCheckBox.Checked)
            {
                ip = " +ip " + ipText.Text + " ";
            }
            
            finalCommandsText.Text = srcdsPathText.Text + ip + maxp + port + " -console " + extraCMD + map;
        }
        private void maxPlayersText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void ipText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void portText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void mapText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void srcdsLocationText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void extraCommandsText_TextChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void ipCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            updateLaunchCommand();
        }

        private void ipText_Leave(object sender, EventArgs e)
        {
            IPAddress address;
            if (! IPAddress.TryParse(ipText.Text, out address) && ipText.Text != "")
            {
                try
                {
                    var addresses = Dns.GetHostAddresses(ipText.Text);
                    if (addresses.Length > 0)
                    {
                        string pickIP = "";
                        foreach (var ip in addresses)
                        {
                            if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                pickIP = ip.ToString();
                                break;
                            }
                        }
                        if (pickIP == "")
                        {
                            ipText.Text = "127.0.0.1";
                        }
                        else
                        {
                            ipText.Text = pickIP;
                        }
                    }
                }
                catch
                {
                    ipText.Text = "127.0.0.1";
                }
            }
            else if (IPAddress.TryParse(ipText.Text, out address) )
            {
                if (address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                {
                    ipText.Text = "127.0.0.1";
                    return;
                }
            }
        }

        private void delayText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(delayText.Text, out n);
            if (!isNumeric || n < 10)
            {
                delayText.Text = "120";
            }

        }

        private void pidCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            pidText.Enabled = pidCheckBox.Checked;

        }

        private void maxPlayersText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(maxPlayersText.Text, out n);
            if (!isNumeric || (n<1 || n>128))
            {
                maxPlayersText.Text = "12";
            }
        }

        private void pidText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(pidText.Text, out n);
            if (!isNumeric || (n < 0 ))
            {
                pidText.Text = "0";
            }
        }

        private void portText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(portText.Text, out n);
            if (!isNumeric || (n < 1 || n > 65535))
            {
                portText.Text = "27015";
            }
        }

        private void AddServerDialog_Shown(object sender, EventArgs e)
        {
            if ((int)aMask < 1 || (int)aMask > (int)affMask) { aMask = affMask; }
            affBox1.Checked = ((aMask & affEnum.c1) == affEnum.c1) ? true : false;
            affBox2.Checked = ((aMask & affEnum.c2) == affEnum.c2) ? true : false;
            affBox3.Checked = ((aMask & affEnum.c3) == affEnum.c3) ? true : false;
            affBox4.Checked = ((aMask & affEnum.c4) == affEnum.c4) ? true : false;
            affBox5.Checked = ((aMask & affEnum.c5) == affEnum.c5) ? true : false;
            affBox6.Checked = ((aMask & affEnum.c6) == affEnum.c6) ? true : false;
            affBox7.Checked = ((aMask & affEnum.c7) == affEnum.c7) ? true : false;
            affBox8.Checked = ((aMask & affEnum.c8) == affEnum.c8) ? true : false;
            affBox9.Checked = ((aMask & affEnum.c9) == affEnum.c9) ? true : false;
            affBox10.Checked = ((aMask & affEnum.c10) == affEnum.c10) ? true : false;
            affBox11.Checked = ((aMask & affEnum.c11) == affEnum.c11) ? true : false;
            affBox12.Checked = ((aMask & affEnum.c12) == affEnum.c12) ? true : false;
            affBox13.Checked = ((aMask & affEnum.c13) == affEnum.c13) ? true : false;
            affBox14.Checked = ((aMask & affEnum.c14) == affEnum.c14) ? true : false;
            affBox15.Checked = ((aMask & affEnum.c15) == affEnum.c15) ? true : false;
            affBox16.Checked = ((aMask & affEnum.c16) == affEnum.c16) ? true : false;

        }

    }
}
