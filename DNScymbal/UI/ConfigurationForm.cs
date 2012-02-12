using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DNScymbal
{
    public partial class ConfigurationForm : Form
    {
        const string Str_PwordUnchanged = "PASSWORD_UNCHANGED";

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigSettings config = new ConfigSettings();

                // Show the config we currently have...
                if (config.RecordUpdateRequests.Count > 0)
                {
                    _txtEmailAddr.Text = config.RecordUpdateRequests[0].EmailAddress;
                    _txtPassword.Text = Str_PwordUnchanged;
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void HandleException(Exception ex)
        {
            MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
