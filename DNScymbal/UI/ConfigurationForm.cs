using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;

namespace DNScymbal
{
    public partial class ConfigurationForm : Form
    {
        const string Str_PwordUnchanged = "PASSWORD_UNCHANGED";

        DNScymbalSettings _config = DNScymbalSettings.Load();

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            try
            {
                _chkAutoStartApp.Checked = _config.AutoStartApplication;

                // Show the config we currently have...
                if (_config.RecordUpdateRequests.Count > 0)
                {
                    RecordUpdateRequest theRur = _config.RecordUpdateRequests[0];
                    _chkEnableDNSimple.Checked = theRur.Enabled;
                    _txtEmailAddr.Text = theRur.EmailAddress;
                    _txtPassword.Text = Str_PwordUnchanged;
                    _txtDomain.Text = theRur.Domain;
                    _txtRecordId.Text = theRur.RecordId.ToString();
                    _txtRecordName.Text = theRur.RecordName;
                    _txtUpdateFreq.Text = theRur.UpdateFrequencyMinutes.ToString();

                    LoadIpAddressCb(theRur);
                    EnableDNSimpleControls(theRur.Enabled);
                }
                else
                {
                    LoadIpAddressCb(null);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void LoadIpAddressCb(RecordUpdateRequest theRur)
        {
            string strJsonIp = string.Format("Dynamic/Public (JSONIP.com) / {0}", DnsCymbalUpdater.GetPublicIP());
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface nic in nics)
            {
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                {
                    // Skip
                }
                else if(nic.OperationalStatus == OperationalStatus.Up && nic.Speed > 0)
                {
                    _cbIpAddress.Items.Add(new IpAddressOption(nic));
                }
            }

            // Add JSONIP dynamic option
            _cbIpAddress.Items.Add(strJsonIp);

            // JSONIP.com option selected?
            if (null != theRur && theRur.IpAddressType == RecordUpdateRequest.IpAddressTypes.JsonIp)
            {
                _cbIpAddress.SelectedItem = strJsonIp;
                _toolTip.SetToolTip(_cbIpAddress, strJsonIp);
            }
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            try
            {

                RecordUpdateRequest theRur;
                if (0 < _config.RecordUpdateRequests.Count)
                {
                    theRur = _config.RecordUpdateRequests[0];
                }
                else
                {
                    theRur = new RecordUpdateRequest();
                    _config.RecordUpdateRequests.Add(theRur);
                }

                theRur.Enabled = _chkEnableDNSimple.Checked;
                theRur.EmailAddress = _txtEmailAddr.Text;
                if (_txtPassword.Text != Str_PwordUnchanged)
                {
                    theRur.Password = _txtPassword.Text;
                }
                theRur.Domain = _txtDomain.Text;
                theRur.RecordId = Convert.ToInt32(_txtRecordId.Text);
                theRur.RecordName = _txtRecordName.Text;
                theRur.UpdateFrequencyMinutes = Convert.ToInt32(_txtUpdateFreq.Text);

                _config.AutoStartApplication = _chkAutoStartApp.Checked;

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

        class IpAddressOption
        {
            public NetworkInterface Nic {get; private set;}

            internal IpAddressOption(NetworkInterface nic)
            {
                Nic = nic;
            }

            public override string ToString()
            {
                string strIp = string.Empty;
                foreach(UnicastIPAddressInformation ip in Nic.GetIPProperties().UnicastAddresses)
                {
                    if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        strIp = ip.Address.ToString();
                    }
                }

                return string.Format("{0} / {1}", Nic.Name, strIp);
            }

        }

        private void _chkEnableDNSimple_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                EnableDNSimpleControls(_chkEnableDNSimple.Checked);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private void EnableDNSimpleControls(bool bEnable)
        {
            _cbIpAddress.Enabled = false;
            _txtDomain.Enabled = bEnable;
            _txtEmailAddr.Enabled = bEnable;
            _txtPassword.Enabled = bEnable;
            _txtRecordId.Enabled = bEnable;
            _txtRecordName.Enabled = bEnable;
            _txtUpdateFreq.Enabled = bEnable;
        }

    }
}
