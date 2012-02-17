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

        ConfigSettings _config = new ConfigSettings();

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            try
            {

                // Show the config we currently have...
                if (_config.RecordUpdateRequests.Count > 0)
                {
                    RecordUpdateRequest theRur = _config.RecordUpdateRequests[0];
                    _txtEmailAddr.Text = theRur.EmailAddress;
                    _txtPassword.Text = Str_PwordUnchanged;
                    _txtDomain.Text = theRur.Domain;
                    _txtRecordId.Text = theRur.RecordId.ToString();
                    _txtRecordName.Text = theRur.RecordName;
                    _txtUpdateFreq.Text = theRur.UpdateFrequencyMinutes.ToString();
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                RecordUpdateRequest theRur = _config.RecordUpdateRequests[0];

                theRur.EmailAddress = _txtEmailAddr.Text;
                if (_txtPassword.Text != Str_PwordUnchanged)
                {
                    theRur.Password = _txtPassword.Text;
                }
                theRur.Domain = _txtDomain.Text;
                theRur.RecordId = Convert.ToInt32(_txtRecordId.Text);
                theRur.RecordName = _txtRecordName.Text;
                theRur.UpdateFrequencyMinutes = Convert.ToInt32(_txtUpdateFreq.Text);

                // Save the config
                _config.Save();

                // Close the form
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #region Private Metehods

        private void HandleException(Exception ex)
        {
            MessageBox.Show(this, ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        #endregion

    }
}
