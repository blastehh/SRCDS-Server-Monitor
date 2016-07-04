namespace SRCDS_Server_Monitor
{
    partial class optionsWindow
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
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.intervalText = new System.Windows.Forms.TextBox();
            this.thresholdText = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.intervalBox = new System.Windows.Forms.Label();
            this.thresholdBox = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // intervalText
            // 
            this.intervalText.Location = new System.Drawing.Point(146, 24);
            this.intervalText.MaxLength = 4;
            this.intervalText.Name = "intervalText";
            this.intervalText.Size = new System.Drawing.Size(50, 20);
            this.intervalText.TabIndex = 0;
            this.intervalText.Text = "4";
            this.intervalText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.intervalText.Leave += new System.EventHandler(this.intervalText_Leave);
            // 
            // thresholdText
            // 
            this.thresholdText.Location = new System.Drawing.Point(146, 50);
            this.thresholdText.MaxLength = 4;
            this.thresholdText.Name = "thresholdText";
            this.thresholdText.Size = new System.Drawing.Size(50, 20);
            this.thresholdText.TabIndex = 1;
            this.thresholdText.Text = "5";
            this.thresholdText.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.thresholdText.Leave += new System.EventHandler(this.thresholdText_Leave);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(212, 21);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(212, 50);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // intervalBox
            // 
            this.intervalBox.AutoSize = true;
            this.intervalBox.Location = new System.Drawing.Point(21, 27);
            this.intervalBox.Name = "intervalBox";
            this.intervalBox.Size = new System.Drawing.Size(119, 13);
            this.intervalBox.TabIndex = 4;
            this.intervalBox.Text = "Poll Interval (Seconds) :";
            // 
            // thresholdBox
            // 
            this.thresholdBox.AutoSize = true;
            this.thresholdBox.Location = new System.Drawing.Point(12, 53);
            this.thresholdBox.Name = "thresholdBox";
            this.thresholdBox.Size = new System.Drawing.Size(128, 13);
            this.thresholdBox.TabIndex = 4;
            this.thresholdBox.Text = "No Response Threshold :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Servers will need a manual restart before settings take effect.";
            // 
            // optionsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(299, 75);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thresholdBox);
            this.Controls.Add(this.intervalBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.thresholdText);
            this.Controls.Add(this.intervalText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "optionsWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox intervalText;
        private System.Windows.Forms.TextBox thresholdText;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label intervalBox;
        private System.Windows.Forms.Label thresholdBox;
        private System.Windows.Forms.Label label1;
    }
}