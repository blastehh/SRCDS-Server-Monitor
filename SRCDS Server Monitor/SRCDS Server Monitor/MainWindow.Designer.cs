namespace SRCDS_Server_Monitor
{
    partial class MainWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversGroupBox = new System.Windows.Forms.GroupBox();
            this.serversList = new System.Windows.Forms.ListView();
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.playerCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.crashesCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addServerButton = new System.Windows.Forms.Button();
            this.editServerButton = new System.Windows.Forms.Button();
            this.deleteServerButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.aboutLink = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1.SuspendLayout();
            this.serversGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.serversToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(625, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.importSettingsToolStripMenuItem,
            this.exportSettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionsToolStripMenuItem.Text = "&Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // importSettingsToolStripMenuItem
            // 
            this.importSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.importSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.importSettingsToolStripMenuItem.Name = "importSettingsToolStripMenuItem";
            this.importSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importSettingsToolStripMenuItem.Text = "&Import...";
            this.importSettingsToolStripMenuItem.Click += new System.EventHandler(this.importSettingsToolStripMenuItem_Click);
            // 
            // exportSettingsToolStripMenuItem
            // 
            this.exportSettingsToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.exportSettingsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exportSettingsToolStripMenuItem.Name = "exportSettingsToolStripMenuItem";
            this.exportSettingsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportSettingsToolStripMenuItem.Text = "&Export...";
            this.exportSettingsToolStripMenuItem.Click += new System.EventHandler(this.exportSettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.exitToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startAllToolStripMenuItem,
            this.restartAllToolStripMenuItem,
            this.stopAllToolStripMenuItem});
            this.serversToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.serversToolStripMenuItem.Text = "Servers";
            // 
            // startAllToolStripMenuItem
            // 
            this.startAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.startAllToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.startAllToolStripMenuItem.Name = "startAllToolStripMenuItem";
            this.startAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.startAllToolStripMenuItem.Text = "Start all servers";
            this.startAllToolStripMenuItem.Click += new System.EventHandler(this.startAllToolStripMenuItem_Click);
            // 
            // restartAllToolStripMenuItem
            // 
            this.restartAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.restartAllToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.restartAllToolStripMenuItem.Name = "restartAllToolStripMenuItem";
            this.restartAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.restartAllToolStripMenuItem.Text = "Restart all servers";
            this.restartAllToolStripMenuItem.Click += new System.EventHandler(this.restartAllToolStripMenuItem_Click);
            // 
            // stopAllToolStripMenuItem
            // 
            this.stopAllToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.stopAllToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.stopAllToolStripMenuItem.Name = "stopAllToolStripMenuItem";
            this.stopAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.stopAllToolStripMenuItem.Text = "Stop all servers";
            this.stopAllToolStripMenuItem.Click += new System.EventHandler(this.stopAllToolStripMenuItem_Click);
            // 
            // serversGroupBox
            // 
            this.serversGroupBox.Controls.Add(this.serversList);
            this.serversGroupBox.ForeColor = System.Drawing.Color.White;
            this.serversGroupBox.Location = new System.Drawing.Point(12, 61);
            this.serversGroupBox.Name = "serversGroupBox";
            this.serversGroupBox.Size = new System.Drawing.Size(601, 410);
            this.serversGroupBox.TabIndex = 7;
            this.serversGroupBox.TabStop = false;
            this.serversGroupBox.Text = "Servers";
            // 
            // serversList
            // 
            this.serversList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.serversList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(205)))), ((int)(((byte)(205)))));
            this.serversList.BackgroundImageTiled = true;
            this.serversList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameCol,
            this.statusCol,
            this.ipCol,
            this.portCol,
            this.playerCol,
            this.crashesCol});
            this.serversList.ForeColor = System.Drawing.Color.Black;
            this.serversList.FullRowSelect = true;
            this.serversList.GridLines = true;
            this.serversList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.serversList.HideSelection = false;
            this.serversList.Location = new System.Drawing.Point(6, 19);
            this.serversList.Name = "serversList";
            this.serversList.Size = new System.Drawing.Size(589, 385);
            this.serversList.TabIndex = 7;
            this.serversList.TabStop = false;
            this.serversList.UseCompatibleStateImageBehavior = false;
            this.serversList.View = System.Windows.Forms.View.Details;
            this.serversList.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // nameCol
            // 
            this.nameCol.DisplayIndex = 1;
            this.nameCol.Text = "Name";
            this.nameCol.Width = 250;
            // 
            // statusCol
            // 
            this.statusCol.DisplayIndex = 0;
            this.statusCol.Text = "Status";
            this.statusCol.Width = 105;
            // 
            // ipCol
            // 
            this.ipCol.Text = "IP";
            this.ipCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ipCol.Width = 94;
            // 
            // portCol
            // 
            this.portCol.Text = "Port";
            this.portCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.portCol.Width = 48;
            // 
            // playerCol
            // 
            this.playerCol.Text = "Slots";
            this.playerCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.playerCol.Width = 38;
            // 
            // crashesCol
            // 
            this.crashesCol.Text = "Crashes";
            this.crashesCol.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.crashesCol.Width = 50;
            // 
            // addServerButton
            // 
            this.addServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.addServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.addServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addServerButton.ForeColor = System.Drawing.Color.White;
            this.addServerButton.Location = new System.Drawing.Point(18, 32);
            this.addServerButton.Name = "addServerButton";
            this.addServerButton.Size = new System.Drawing.Size(80, 23);
            this.addServerButton.TabIndex = 0;
            this.addServerButton.Text = "&Add Server...";
            this.addServerButton.UseVisualStyleBackColor = true;
            this.addServerButton.EnabledChanged += new System.EventHandler(this.addServerButton_EnabledChanged);
            this.addServerButton.Click += new System.EventHandler(this.addServerButton_Click);
            // 
            // editServerButton
            // 
            this.editServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.editServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.editServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editServerButton.ForeColor = System.Drawing.Color.Black;
            this.editServerButton.Location = new System.Drawing.Point(104, 32);
            this.editServerButton.Name = "editServerButton";
            this.editServerButton.Size = new System.Drawing.Size(80, 23);
            this.editServerButton.TabIndex = 1;
            this.editServerButton.Text = "&Edit Server...";
            this.editServerButton.UseVisualStyleBackColor = true;
            this.editServerButton.EnabledChanged += new System.EventHandler(this.editServerButton_EnabledChanged);
            this.editServerButton.Click += new System.EventHandler(this.editServerButton_Click);
            // 
            // deleteServerButton
            // 
            this.deleteServerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.deleteServerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteServerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.deleteServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteServerButton.ForeColor = System.Drawing.Color.Black;
            this.deleteServerButton.Location = new System.Drawing.Point(527, 32);
            this.deleteServerButton.Name = "deleteServerButton";
            this.deleteServerButton.Size = new System.Drawing.Size(80, 23);
            this.deleteServerButton.TabIndex = 5;
            this.deleteServerButton.Text = "&Delete Server";
            this.deleteServerButton.UseVisualStyleBackColor = true;
            this.deleteServerButton.EnabledChanged += new System.EventHandler(this.deleteServerButton_EnabledChanged);
            this.deleteServerButton.Click += new System.EventHandler(this.deleteServerButton_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(289, 32);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(70, 23);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "&Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.EnabledChanged += new System.EventHandler(this.startButton_EnabledChanged);
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.stopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.ForeColor = System.Drawing.Color.Black;
            this.stopButton.Location = new System.Drawing.Point(453, 32);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(40, 23);
            this.stopButton.TabIndex = 4;
            this.stopButton.Text = "Sto&p";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.EnabledChanged += new System.EventHandler(this.stopButton_EnabledChanged);
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.restartButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.restartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.ForeColor = System.Drawing.Color.Black;
            this.restartButton.Location = new System.Drawing.Point(395, 32);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(52, 23);
            this.restartButton.TabIndex = 3;
            this.restartButton.Text = "&Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.EnabledChanged += new System.EventHandler(this.restartButton_EnabledChanged);
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // aboutLink
            // 
            this.aboutLink.ActiveLinkColor = System.Drawing.Color.Coral;
            this.aboutLink.AutoSize = true;
            this.aboutLink.LinkColor = System.Drawing.Color.Black;
            this.aboutLink.Location = new System.Drawing.Point(517, 9);
            this.aboutLink.Name = "aboutLink";
            this.aboutLink.Size = new System.Drawing.Size(96, 13);
            this.aboutLink.TabIndex = 6;
            this.aboutLink.TabStop = true;
            this.aboutLink.Text = "Created by Blasteh";
            this.toolTip1.SetToolTip(this.aboutLink, "http://banana-ph.com");
            this.aboutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.aboutLink_LinkClicked);
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 10000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ClientSize = new System.Drawing.Size(625, 478);
            this.Controls.Add(this.aboutLink);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.deleteServerButton);
            this.Controls.Add(this.editServerButton);
            this.Controls.Add(this.addServerButton);
            this.Controls.Add(this.serversGroupBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "SRCDS Server Monitor 0.12.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.serversGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox serversGroupBox;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAllToolStripMenuItem;
        private System.Windows.Forms.Button addServerButton;
        private System.Windows.Forms.Button editServerButton;
        private System.Windows.Forms.Button deleteServerButton;
        private System.Windows.Forms.ToolStripMenuItem restartAllToolStripMenuItem;
        private System.Windows.Forms.ListView serversList;
        private System.Windows.Forms.ColumnHeader statusCol;
        private System.Windows.Forms.ColumnHeader nameCol;
        private System.Windows.Forms.ColumnHeader ipCol;
        private System.Windows.Forms.ColumnHeader playerCol;
        private System.Windows.Forms.ColumnHeader portCol;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.LinkLabel aboutLink;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ColumnHeader crashesCol;
        private System.Windows.Forms.ToolStripMenuItem importSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSettingsToolStripMenuItem;
    }
}

