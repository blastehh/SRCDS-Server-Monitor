namespace SRCDS_Server_Monitor
{
    partial class AddServerDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.serverNameLabel = new System.Windows.Forms.Label();
            this.CommandLineLabel = new System.Windows.Forms.Label();
            this.serverNameText = new System.Windows.Forms.TextBox();
            this.finalCommandsText = new System.Windows.Forms.TextBox();
            this.mapLabel = new System.Windows.Forms.Label();
            this.ipLabel = new System.Windows.Forms.Label();
            this.extraCommandsLabel = new System.Windows.Forms.Label();
            this.extraCommandsText = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ipText = new System.Windows.Forms.TextBox();
            this.mapText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.srcdsPathLabel = new System.Windows.Forms.Label();
            this.srcdsPathText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.maxPlayersLabel = new System.Windows.Forms.Label();
            this.maxPlayersText = new System.Windows.Forms.TextBox();
            this.ipCheckBox = new System.Windows.Forms.CheckBox();
            this.delayLabel = new System.Windows.Forms.Label();
            this.addServerToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.delayText = new System.Windows.Forms.TextBox();
            this.pidCheckBox = new System.Windows.Forms.CheckBox();
            this.pidText = new System.Windows.Forms.TextBox();
            this.pidLabel = new System.Windows.Forms.Label();
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.timePickerLabel = new System.Windows.Forms.Label();
            this.autoRestartCheckbox = new System.Windows.Forms.CheckBox();
            this.affBox1 = new System.Windows.Forms.CheckBox();
            this.affBox2 = new System.Windows.Forms.CheckBox();
            this.affBox3 = new System.Windows.Forms.CheckBox();
            this.affBox4 = new System.Windows.Forms.CheckBox();
            this.affBox8 = new System.Windows.Forms.CheckBox();
            this.affBox7 = new System.Windows.Forms.CheckBox();
            this.affBox6 = new System.Windows.Forms.CheckBox();
            this.affBox5 = new System.Windows.Forms.CheckBox();
            this.affLabel1 = new System.Windows.Forms.Label();
            this.affLabel8 = new System.Windows.Forms.Label();
            this.affinityGroup = new System.Windows.Forms.GroupBox();
            this.affLabel9 = new System.Windows.Forms.Label();
            this.affLabel16 = new System.Windows.Forms.Label();
            this.affBox9 = new System.Windows.Forms.CheckBox();
            this.affBox10 = new System.Windows.Forms.CheckBox();
            this.affBox16 = new System.Windows.Forms.CheckBox();
            this.affBox11 = new System.Windows.Forms.CheckBox();
            this.affBox15 = new System.Windows.Forms.CheckBox();
            this.affBox12 = new System.Windows.Forms.CheckBox();
            this.affBox14 = new System.Windows.Forms.CheckBox();
            this.affBox13 = new System.Windows.Forms.CheckBox();
            this.priorityPickerLabel = new System.Windows.Forms.Label();
            this.priorityComboBox = new System.Windows.Forms.ComboBox();
            this.autoStartCheckBox = new System.Windows.Forms.CheckBox();
            this.affinityGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverNameLabel
            // 
            this.serverNameLabel.AutoSize = true;
            this.serverNameLabel.Location = new System.Drawing.Point(12, 15);
            this.serverNameLabel.Name = "serverNameLabel";
            this.serverNameLabel.Size = new System.Drawing.Size(72, 13);
            this.serverNameLabel.TabIndex = 20;
            this.serverNameLabel.Text = "Server Name:";
            // 
            // CommandLineLabel
            // 
            this.CommandLineLabel.AutoSize = true;
            this.CommandLineLabel.Location = new System.Drawing.Point(13, 295);
            this.CommandLineLabel.Name = "CommandLineLabel";
            this.CommandLineLabel.Size = new System.Drawing.Size(80, 13);
            this.CommandLineLabel.TabIndex = 20;
            this.CommandLineLabel.Text = "Command Line:";
            // 
            // serverNameText
            // 
            this.serverNameText.Location = new System.Drawing.Point(87, 12);
            this.serverNameText.MaxLength = 100;
            this.serverNameText.Name = "serverNameText";
            this.serverNameText.Size = new System.Drawing.Size(358, 20);
            this.serverNameText.TabIndex = 0;
            this.addServerToolTip.SetToolTip(this.serverNameText, "(Required) Enter a name to display for this server. This does not affect the actu" +
        "al name of the server");
            // 
            // finalCommandsText
            // 
            this.finalCommandsText.Location = new System.Drawing.Point(12, 311);
            this.finalCommandsText.MaxLength = 1500;
            this.finalCommandsText.Multiline = true;
            this.finalCommandsText.Name = "finalCommandsText";
            this.finalCommandsText.ReadOnly = true;
            this.finalCommandsText.Size = new System.Drawing.Size(446, 61);
            this.finalCommandsText.TabIndex = 20;
            this.finalCommandsText.TabStop = false;
            // 
            // mapLabel
            // 
            this.mapLabel.AutoSize = true;
            this.mapLabel.Location = new System.Drawing.Point(53, 67);
            this.mapLabel.Name = "mapLabel";
            this.mapLabel.Size = new System.Drawing.Size(31, 13);
            this.mapLabel.TabIndex = 20;
            this.mapLabel.Text = "Map:";
            this.addServerToolTip.SetToolTip(this.mapLabel, "(Required) Specify a map that the server will start on");
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(64, 41);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(20, 13);
            this.ipLabel.TabIndex = 20;
            this.ipLabel.Text = "IP:";
            // 
            // extraCommandsLabel
            // 
            this.extraCommandsLabel.AutoSize = true;
            this.extraCommandsLabel.Location = new System.Drawing.Point(12, 247);
            this.extraCommandsLabel.Name = "extraCommandsLabel";
            this.extraCommandsLabel.Size = new System.Drawing.Size(89, 13);
            this.extraCommandsLabel.TabIndex = 20;
            this.extraCommandsLabel.Text = "Extra Commands:";
            // 
            // extraCommandsText
            // 
            this.extraCommandsText.Location = new System.Drawing.Point(12, 263);
            this.extraCommandsText.MaxLength = 500;
            this.extraCommandsText.Name = "extraCommandsText";
            this.extraCommandsText.Size = new System.Drawing.Size(446, 20);
            this.extraCommandsText.TabIndex = 13;
            this.extraCommandsText.Text = "-nocrashdialog +gamemode prop_hunt";
            this.addServerToolTip.SetToolTip(this.extraCommandsText, "(Optional) You may add additional commands that you want to start the server with" +
        " here. You may need to add a game mode ( -game <game name> )");
            this.extraCommandsText.TextChanged += new System.EventHandler(this.extraCommandsText_TextChanged);
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(244, 41);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(29, 13);
            this.portLabel.TabIndex = 20;
            this.portLabel.Text = "Port:";
            // 
            // ipText
            // 
            this.ipText.Location = new System.Drawing.Point(87, 38);
            this.ipText.MaxLength = 32;
            this.ipText.Name = "ipText";
            this.ipText.Size = new System.Drawing.Size(92, 20);
            this.ipText.TabIndex = 1;
            this.ipText.Text = "127.0.0.1";
            this.ipText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addServerToolTip.SetToolTip(this.ipText, "(Required) Only IP addresses are supported. If you try to enter a domain name, it" +
        " will be resolved to an IP");
            this.ipText.TextChanged += new System.EventHandler(this.ipText_TextChanged);
            this.ipText.Leave += new System.EventHandler(this.ipText_Leave);
            // 
            // mapText
            // 
            this.mapText.Location = new System.Drawing.Point(87, 64);
            this.mapText.MaxLength = 100;
            this.mapText.Name = "mapText";
            this.mapText.Size = new System.Drawing.Size(193, 20);
            this.mapText.TabIndex = 4;
            this.addServerToolTip.SetToolTip(this.mapText, "(Required) Specify a map that the server will start on");
            this.mapText.TextChanged += new System.EventHandler(this.mapText_TextChanged);
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(279, 38);
            this.portText.MaxLength = 5;
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(58, 20);
            this.portText.TabIndex = 3;
            this.portText.Text = "27015";
            this.portText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addServerToolTip.SetToolTip(this.portText, "(Required) The port the server will run on");
            this.portText.TextChanged += new System.EventHandler(this.portText_TextChanged);
            this.portText.Leave += new System.EventHandler(this.portText_Leave);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(298, 67);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(64, 46);
            this.saveButton.TabIndex = 14;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(368, 67);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(64, 46);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // srcdsPathLabel
            // 
            this.srcdsPathLabel.AutoSize = true;
            this.srcdsPathLabel.Location = new System.Drawing.Point(12, 199);
            this.srcdsPathLabel.Name = "srcdsPathLabel";
            this.srcdsPathLabel.Size = new System.Drawing.Size(91, 13);
            this.srcdsPathLabel.TabIndex = 20;
            this.srcdsPathLabel.Text = "SRCDS Location:";
            // 
            // srcdsPathText
            // 
            this.srcdsPathText.Location = new System.Drawing.Point(12, 215);
            this.srcdsPathText.MaxLength = 500;
            this.srcdsPathText.Name = "srcdsPathText";
            this.srcdsPathText.Size = new System.Drawing.Size(347, 20);
            this.srcdsPathText.TabIndex = 11;
            this.addServerToolTip.SetToolTip(this.srcdsPathText, "(Required) The location of srcds.exe");
            this.srcdsPathText.TextChanged += new System.EventHandler(this.srcdsLocationText_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "srcds.exe|srcds.exe";
            this.openFileDialog1.Title = "Select srcds.exe";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "&Browse...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // maxPlayersLabel
            // 
            this.maxPlayersLabel.AutoSize = true;
            this.maxPlayersLabel.Location = new System.Drawing.Point(144, 93);
            this.maxPlayersLabel.Name = "maxPlayersLabel";
            this.maxPlayersLabel.Size = new System.Drawing.Size(67, 13);
            this.maxPlayersLabel.TabIndex = 15;
            this.maxPlayersLabel.Text = "Max Players:";
            this.addServerToolTip.SetToolTip(this.maxPlayersLabel, "(Required) Maximum players allowed on the server");
            // 
            // maxPlayersText
            // 
            this.maxPlayersText.Location = new System.Drawing.Point(214, 90);
            this.maxPlayersText.MaxLength = 3;
            this.maxPlayersText.Name = "maxPlayersText";
            this.maxPlayersText.Size = new System.Drawing.Size(51, 20);
            this.maxPlayersText.TabIndex = 6;
            this.maxPlayersText.Text = "12";
            this.maxPlayersText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addServerToolTip.SetToolTip(this.maxPlayersText, "(Required) Maximum players allowed on the server");
            this.maxPlayersText.TextChanged += new System.EventHandler(this.maxPlayersText_TextChanged);
            this.maxPlayersText.Leave += new System.EventHandler(this.maxPlayersText_Leave);
            // 
            // ipCheckBox
            // 
            this.ipCheckBox.AutoSize = true;
            this.ipCheckBox.Location = new System.Drawing.Point(185, 40);
            this.ipCheckBox.Name = "ipCheckBox";
            this.ipCheckBox.Size = new System.Drawing.Size(59, 17);
            this.ipCheckBox.TabIndex = 2;
            this.ipCheckBox.Text = "Force?";
            this.addServerToolTip.SetToolTip(this.ipCheckBox, "(Optional) Selecting this option will add the IP address to the command line");
            this.ipCheckBox.UseVisualStyleBackColor = true;
            this.ipCheckBox.CheckedChanged += new System.EventHandler(this.ipCheckBox_CheckedChanged);
            // 
            // delayLabel
            // 
            this.delayLabel.AutoSize = true;
            this.delayLabel.Location = new System.Drawing.Point(27, 93);
            this.delayLabel.Name = "delayLabel";
            this.delayLabel.Size = new System.Drawing.Size(54, 13);
            this.delayLabel.TabIndex = 20;
            this.delayLabel.Text = "Wait time:";
            this.addServerToolTip.SetToolTip(this.delayLabel, "(Required) Seconds to wait when starting the server before checking");
            // 
            // addServerToolTip
            // 
            this.addServerToolTip.AutoPopDelay = 10000;
            this.addServerToolTip.InitialDelay = 500;
            this.addServerToolTip.ReshowDelay = 100;
            // 
            // delayText
            // 
            this.delayText.Location = new System.Drawing.Point(87, 90);
            this.delayText.MaxLength = 3;
            this.delayText.Name = "delayText";
            this.delayText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.delayText.Size = new System.Drawing.Size(51, 20);
            this.delayText.TabIndex = 5;
            this.delayText.Text = "120";
            this.delayText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.addServerToolTip.SetToolTip(this.delayText, "(Required) Seconds to wait when starting the server before checking");
            this.delayText.Leave += new System.EventHandler(this.delayText_Leave);
            // 
            // pidCheckBox
            // 
            this.pidCheckBox.AutoSize = true;
            this.pidCheckBox.Location = new System.Drawing.Point(445, 41);
            this.pidCheckBox.Name = "pidCheckBox";
            this.pidCheckBox.Size = new System.Drawing.Size(15, 14);
            this.pidCheckBox.TabIndex = 20;
            this.pidCheckBox.TabStop = false;
            this.addServerToolTip.SetToolTip(this.pidCheckBox, "ONLY CHANGE IF YOU HAVE AN EXISTING PROCESS RUNNING!");
            this.pidCheckBox.UseVisualStyleBackColor = true;
            this.pidCheckBox.CheckedChanged += new System.EventHandler(this.pidCheckBox_CheckedChanged);
            // 
            // pidText
            // 
            this.pidText.Enabled = false;
            this.pidText.Location = new System.Drawing.Point(387, 38);
            this.pidText.MaxLength = 10;
            this.pidText.Name = "pidText";
            this.pidText.Size = new System.Drawing.Size(52, 20);
            this.pidText.TabIndex = 20;
            this.pidText.TabStop = false;
            this.pidText.Text = "0";
            this.addServerToolTip.SetToolTip(this.pidText, "ONLY CHANGE IF YOU HAVE AN EXISTING PROCESS RUNNING!");
            this.pidText.Leave += new System.EventHandler(this.pidText_Leave);
            // 
            // pidLabel
            // 
            this.pidLabel.AutoSize = true;
            this.pidLabel.Location = new System.Drawing.Point(350, 41);
            this.pidLabel.Name = "pidLabel";
            this.pidLabel.Size = new System.Drawing.Size(31, 13);
            this.pidLabel.TabIndex = 20;
            this.pidLabel.Text = "PID: ";
            this.addServerToolTip.SetToolTip(this.pidLabel, "ONLY CHANGE IF YOU HAVE AN EXISTING PROCESS RUNNING!");
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "HH:mm";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(87, 116);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(51, 20);
            this.timePicker.TabIndex = 7;
            this.timePicker.Value = new System.DateTime(2014, 8, 20, 0, 0, 0, 0);
            // 
            // timePickerLabel
            // 
            this.timePickerLabel.AutoSize = true;
            this.timePickerLabel.Location = new System.Drawing.Point(13, 119);
            this.timePickerLabel.Name = "timePickerLabel";
            this.timePickerLabel.Size = new System.Drawing.Size(72, 13);
            this.timePickerLabel.TabIndex = 20;
            this.timePickerLabel.Text = "Auto Restart: ";
            // 
            // autoRestartCheckbox
            // 
            this.autoRestartCheckbox.AutoSize = true;
            this.autoRestartCheckbox.Location = new System.Drawing.Point(144, 119);
            this.autoRestartCheckbox.Name = "autoRestartCheckbox";
            this.autoRestartCheckbox.Size = new System.Drawing.Size(15, 14);
            this.autoRestartCheckbox.TabIndex = 8;
            this.autoRestartCheckbox.UseVisualStyleBackColor = true;
            // 
            // affBox1
            // 
            this.affBox1.AutoSize = true;
            this.affBox1.Checked = true;
            this.affBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox1.Location = new System.Drawing.Point(33, 16);
            this.affBox1.Name = "affBox1";
            this.affBox1.Size = new System.Drawing.Size(15, 14);
            this.affBox1.TabIndex = 20;
            this.affBox1.TabStop = false;
            this.affBox1.UseVisualStyleBackColor = true;
            // 
            // affBox2
            // 
            this.affBox2.AutoSize = true;
            this.affBox2.Checked = true;
            this.affBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox2.Location = new System.Drawing.Point(54, 16);
            this.affBox2.Name = "affBox2";
            this.affBox2.Size = new System.Drawing.Size(15, 14);
            this.affBox2.TabIndex = 20;
            this.affBox2.TabStop = false;
            this.affBox2.UseVisualStyleBackColor = true;
            // 
            // affBox3
            // 
            this.affBox3.AutoSize = true;
            this.affBox3.Checked = true;
            this.affBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox3.Location = new System.Drawing.Point(75, 16);
            this.affBox3.Name = "affBox3";
            this.affBox3.Size = new System.Drawing.Size(15, 14);
            this.affBox3.TabIndex = 20;
            this.affBox3.TabStop = false;
            this.affBox3.UseVisualStyleBackColor = true;
            // 
            // affBox4
            // 
            this.affBox4.AutoSize = true;
            this.affBox4.Checked = true;
            this.affBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox4.Location = new System.Drawing.Point(96, 16);
            this.affBox4.Name = "affBox4";
            this.affBox4.Size = new System.Drawing.Size(15, 14);
            this.affBox4.TabIndex = 20;
            this.affBox4.TabStop = false;
            this.affBox4.UseVisualStyleBackColor = true;
            // 
            // affBox8
            // 
            this.affBox8.AutoSize = true;
            this.affBox8.Checked = true;
            this.affBox8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox8.Location = new System.Drawing.Point(180, 16);
            this.affBox8.Name = "affBox8";
            this.affBox8.Size = new System.Drawing.Size(15, 14);
            this.affBox8.TabIndex = 20;
            this.affBox8.TabStop = false;
            this.affBox8.UseVisualStyleBackColor = true;
            // 
            // affBox7
            // 
            this.affBox7.AutoSize = true;
            this.affBox7.Checked = true;
            this.affBox7.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox7.Location = new System.Drawing.Point(159, 16);
            this.affBox7.Name = "affBox7";
            this.affBox7.Size = new System.Drawing.Size(15, 14);
            this.affBox7.TabIndex = 20;
            this.affBox7.TabStop = false;
            this.affBox7.UseVisualStyleBackColor = true;
            // 
            // affBox6
            // 
            this.affBox6.AutoSize = true;
            this.affBox6.Checked = true;
            this.affBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox6.Location = new System.Drawing.Point(138, 16);
            this.affBox6.Name = "affBox6";
            this.affBox6.Size = new System.Drawing.Size(15, 14);
            this.affBox6.TabIndex = 20;
            this.affBox6.TabStop = false;
            this.affBox6.UseVisualStyleBackColor = true;
            // 
            // affBox5
            // 
            this.affBox5.AutoSize = true;
            this.affBox5.Checked = true;
            this.affBox5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox5.Location = new System.Drawing.Point(117, 16);
            this.affBox5.Name = "affBox5";
            this.affBox5.Size = new System.Drawing.Size(15, 14);
            this.affBox5.TabIndex = 20;
            this.affBox5.TabStop = false;
            this.affBox5.UseVisualStyleBackColor = true;
            // 
            // affLabel1
            // 
            this.affLabel1.AutoSize = true;
            this.affLabel1.Location = new System.Drawing.Point(14, 16);
            this.affLabel1.Name = "affLabel1";
            this.affLabel1.Size = new System.Drawing.Size(13, 13);
            this.affLabel1.TabIndex = 20;
            this.affLabel1.Text = "1";
            // 
            // affLabel8
            // 
            this.affLabel8.AutoSize = true;
            this.affLabel8.Location = new System.Drawing.Point(198, 16);
            this.affLabel8.Name = "affLabel8";
            this.affLabel8.Size = new System.Drawing.Size(13, 13);
            this.affLabel8.TabIndex = 20;
            this.affLabel8.Text = "8";
            // 
            // affinityGroup
            // 
            this.affinityGroup.Controls.Add(this.affLabel9);
            this.affinityGroup.Controls.Add(this.affLabel16);
            this.affinityGroup.Controls.Add(this.affLabel1);
            this.affinityGroup.Controls.Add(this.affBox9);
            this.affinityGroup.Controls.Add(this.affLabel8);
            this.affinityGroup.Controls.Add(this.affBox10);
            this.affinityGroup.Controls.Add(this.affBox1);
            this.affinityGroup.Controls.Add(this.affBox16);
            this.affinityGroup.Controls.Add(this.affBox2);
            this.affinityGroup.Controls.Add(this.affBox11);
            this.affinityGroup.Controls.Add(this.affBox8);
            this.affinityGroup.Controls.Add(this.affBox15);
            this.affinityGroup.Controls.Add(this.affBox3);
            this.affinityGroup.Controls.Add(this.affBox12);
            this.affinityGroup.Controls.Add(this.affBox7);
            this.affinityGroup.Controls.Add(this.affBox14);
            this.affinityGroup.Controls.Add(this.affBox4);
            this.affinityGroup.Controls.Add(this.affBox13);
            this.affinityGroup.Controls.Add(this.affBox6);
            this.affinityGroup.Controls.Add(this.affBox5);
            this.affinityGroup.Location = new System.Drawing.Point(238, 119);
            this.affinityGroup.Name = "affinityGroup";
            this.affinityGroup.Size = new System.Drawing.Size(219, 56);
            this.affinityGroup.TabIndex = 20;
            this.affinityGroup.TabStop = false;
            this.affinityGroup.Text = "Processor Affinity";
            // 
            // affLabel9
            // 
            this.affLabel9.AutoSize = true;
            this.affLabel9.Location = new System.Drawing.Point(14, 36);
            this.affLabel9.Name = "affLabel9";
            this.affLabel9.Size = new System.Drawing.Size(13, 13);
            this.affLabel9.TabIndex = 20;
            this.affLabel9.Text = "9";
            // 
            // affLabel16
            // 
            this.affLabel16.AutoSize = true;
            this.affLabel16.Location = new System.Drawing.Point(198, 36);
            this.affLabel16.Name = "affLabel16";
            this.affLabel16.Size = new System.Drawing.Size(19, 13);
            this.affLabel16.TabIndex = 14;
            this.affLabel16.Text = "16";
            // 
            // affBox9
            // 
            this.affBox9.AutoSize = true;
            this.affBox9.Checked = true;
            this.affBox9.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox9.Location = new System.Drawing.Point(33, 36);
            this.affBox9.Name = "affBox9";
            this.affBox9.Size = new System.Drawing.Size(15, 14);
            this.affBox9.TabIndex = 20;
            this.affBox9.TabStop = false;
            this.affBox9.UseVisualStyleBackColor = true;
            // 
            // affBox10
            // 
            this.affBox10.AutoSize = true;
            this.affBox10.Checked = true;
            this.affBox10.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox10.Location = new System.Drawing.Point(54, 36);
            this.affBox10.Name = "affBox10";
            this.affBox10.Size = new System.Drawing.Size(15, 14);
            this.affBox10.TabIndex = 20;
            this.affBox10.TabStop = false;
            this.affBox10.UseVisualStyleBackColor = true;
            // 
            // affBox16
            // 
            this.affBox16.AutoSize = true;
            this.affBox16.Checked = true;
            this.affBox16.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox16.Location = new System.Drawing.Point(180, 36);
            this.affBox16.Name = "affBox16";
            this.affBox16.Size = new System.Drawing.Size(15, 14);
            this.affBox16.TabIndex = 20;
            this.affBox16.TabStop = false;
            this.affBox16.UseVisualStyleBackColor = true;
            // 
            // affBox11
            // 
            this.affBox11.AutoSize = true;
            this.affBox11.Checked = true;
            this.affBox11.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox11.Location = new System.Drawing.Point(75, 36);
            this.affBox11.Name = "affBox11";
            this.affBox11.Size = new System.Drawing.Size(15, 14);
            this.affBox11.TabIndex = 20;
            this.affBox11.TabStop = false;
            this.affBox11.UseVisualStyleBackColor = true;
            // 
            // affBox15
            // 
            this.affBox15.AutoSize = true;
            this.affBox15.Checked = true;
            this.affBox15.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox15.Location = new System.Drawing.Point(159, 36);
            this.affBox15.Name = "affBox15";
            this.affBox15.Size = new System.Drawing.Size(15, 14);
            this.affBox15.TabIndex = 20;
            this.affBox15.TabStop = false;
            this.affBox15.UseVisualStyleBackColor = true;
            // 
            // affBox12
            // 
            this.affBox12.AutoSize = true;
            this.affBox12.Checked = true;
            this.affBox12.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox12.Location = new System.Drawing.Point(96, 36);
            this.affBox12.Name = "affBox12";
            this.affBox12.Size = new System.Drawing.Size(15, 14);
            this.affBox12.TabIndex = 20;
            this.affBox12.TabStop = false;
            this.affBox12.UseVisualStyleBackColor = true;
            // 
            // affBox14
            // 
            this.affBox14.AutoSize = true;
            this.affBox14.Checked = true;
            this.affBox14.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox14.Location = new System.Drawing.Point(138, 36);
            this.affBox14.Name = "affBox14";
            this.affBox14.Size = new System.Drawing.Size(15, 14);
            this.affBox14.TabIndex = 20;
            this.affBox14.TabStop = false;
            this.affBox14.UseVisualStyleBackColor = true;
            // 
            // affBox13
            // 
            this.affBox13.AutoSize = true;
            this.affBox13.Checked = true;
            this.affBox13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.affBox13.Location = new System.Drawing.Point(117, 36);
            this.affBox13.Name = "affBox13";
            this.affBox13.Size = new System.Drawing.Size(15, 14);
            this.affBox13.TabIndex = 20;
            this.affBox13.TabStop = false;
            this.affBox13.UseVisualStyleBackColor = true;
            // 
            // priorityPickerLabel
            // 
            this.priorityPickerLabel.AutoSize = true;
            this.priorityPickerLabel.Location = new System.Drawing.Point(40, 145);
            this.priorityPickerLabel.Name = "priorityPickerLabel";
            this.priorityPickerLabel.Size = new System.Drawing.Size(41, 13);
            this.priorityPickerLabel.TabIndex = 20;
            this.priorityPickerLabel.Text = "Priority:";
            // 
            // priorityComboBox
            // 
            this.priorityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.priorityComboBox.FormattingEnabled = true;
            this.priorityComboBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.priorityComboBox.Items.AddRange(new object[] {
            "Real Time",
            "High",
            "Above Normal",
            "Normal",
            "Below Normal",
            "Idle"});
            this.priorityComboBox.Location = new System.Drawing.Point(87, 142);
            this.priorityComboBox.Name = "priorityComboBox";
            this.priorityComboBox.Size = new System.Drawing.Size(121, 21);
            this.priorityComboBox.TabIndex = 9;
            // 
            // autoStartCheckBox
            // 
            this.autoStartCheckBox.AutoSize = true;
            this.autoStartCheckBox.Location = new System.Drawing.Point(87, 169);
            this.autoStartCheckBox.Name = "autoStartCheckBox";
            this.autoStartCheckBox.Size = new System.Drawing.Size(79, 17);
            this.autoStartCheckBox.TabIndex = 10;
            this.autoStartCheckBox.Text = "Auto Start?";
            this.addServerToolTip.SetToolTip(this.autoStartCheckBox, "Launch this server when SRCDS Monitor starts.");
            this.autoStartCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddServerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(469, 386);
            this.ControlBox = false;
            this.Controls.Add(this.autoStartCheckBox);
            this.Controls.Add(this.priorityComboBox);
            this.Controls.Add(this.priorityPickerLabel);
            this.Controls.Add(this.affinityGroup);
            this.Controls.Add(this.autoRestartCheckbox);
            this.Controls.Add(this.timePickerLabel);
            this.Controls.Add(this.timePicker);
            this.Controls.Add(this.pidLabel);
            this.Controls.Add(this.pidText);
            this.Controls.Add(this.pidCheckBox);
            this.Controls.Add(this.delayText);
            this.Controls.Add(this.delayLabel);
            this.Controls.Add(this.ipCheckBox);
            this.Controls.Add(this.maxPlayersText);
            this.Controls.Add(this.maxPlayersLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.srcdsPathText);
            this.Controls.Add(this.srcdsPathLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.mapText);
            this.Controls.Add(this.ipText);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.extraCommandsText);
            this.Controls.Add(this.extraCommandsLabel);
            this.Controls.Add(this.ipLabel);
            this.Controls.Add(this.mapLabel);
            this.Controls.Add(this.finalCommandsText);
            this.Controls.Add(this.serverNameText);
            this.Controls.Add(this.CommandLineLabel);
            this.Controls.Add(this.serverNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddServerDialog";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Server Details";
            this.Load += new System.EventHandler(this.addServerDialog_Load);
            this.Shown += new System.EventHandler(this.AddServerDialog_Shown);
            this.affinityGroup.ResumeLayout(false);
            this.affinityGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label serverNameLabel;
        private System.Windows.Forms.Label CommandLineLabel;
        private System.Windows.Forms.TextBox serverNameText;
        private System.Windows.Forms.TextBox finalCommandsText;
        private System.Windows.Forms.Label mapLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label extraCommandsLabel;
        private System.Windows.Forms.TextBox extraCommandsText;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ipText;
        private System.Windows.Forms.TextBox mapText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label srcdsPathLabel;
        private System.Windows.Forms.TextBox srcdsPathText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label maxPlayersLabel;
        private System.Windows.Forms.TextBox maxPlayersText;
        private System.Windows.Forms.CheckBox ipCheckBox;
        private System.Windows.Forms.Label delayLabel;
        private System.Windows.Forms.ToolTip addServerToolTip;
        private System.Windows.Forms.TextBox delayText;
        private System.Windows.Forms.CheckBox pidCheckBox;
        private System.Windows.Forms.TextBox pidText;
        private System.Windows.Forms.Label pidLabel;
        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Label timePickerLabel;
        private System.Windows.Forms.CheckBox autoRestartCheckbox;
        private System.Windows.Forms.CheckBox affBox1;
        private System.Windows.Forms.CheckBox affBox2;
        private System.Windows.Forms.CheckBox affBox3;
        private System.Windows.Forms.CheckBox affBox4;
        private System.Windows.Forms.CheckBox affBox8;
        private System.Windows.Forms.CheckBox affBox7;
        private System.Windows.Forms.CheckBox affBox6;
        private System.Windows.Forms.CheckBox affBox5;
        private System.Windows.Forms.Label affLabel1;
        private System.Windows.Forms.Label affLabel8;
        private System.Windows.Forms.GroupBox affinityGroup;
        private System.Windows.Forms.Label affLabel9;
        private System.Windows.Forms.Label affLabel16;
        private System.Windows.Forms.CheckBox affBox9;
        private System.Windows.Forms.CheckBox affBox10;
        private System.Windows.Forms.CheckBox affBox16;
        private System.Windows.Forms.CheckBox affBox11;
        private System.Windows.Forms.CheckBox affBox15;
        private System.Windows.Forms.CheckBox affBox12;
        private System.Windows.Forms.CheckBox affBox14;
        private System.Windows.Forms.CheckBox affBox13;
        private System.Windows.Forms.Label priorityPickerLabel;
        private System.Windows.Forms.ComboBox priorityComboBox;
        private System.Windows.Forms.CheckBox autoStartCheckBox;
    }
}