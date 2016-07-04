using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRCDS_Server_Monitor
{
    public partial class optionsWindow : Form
    {
        public optionsWindow()
        {
            InitializeComponent();
        }
        
        public string interval
        {
            get { return intervalText.Text; }
            set { intervalText.Text = value; }
        }

        public string threshold
        {
            get { return thresholdText.Text; }
            set { thresholdText.Text = value; }
        }
        private void intervalText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(intervalText.Text, out n);
            if ( !isNumeric || (n < 1 ) )
            {
                intervalText.Text = "4";
            }
        }

        private void thresholdText_Leave(object sender, EventArgs e)
        {
            int n;
            bool isNumeric = int.TryParse(thresholdText.Text, out n);
            if ( !isNumeric || (n < 1 ) )
            {
                thresholdText.Text = "5";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
