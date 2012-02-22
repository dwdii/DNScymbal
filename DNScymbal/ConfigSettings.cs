using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;

namespace DNScymbal
{
    class ConfigSettings
    {
        Configuration _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        List<RecordUpdateRequest> Rurs = null;

        public List<RecordUpdateRequest> RecordUpdateRequests
        {
            get
            {
                if (null == Rurs)
                {
                    // Local Variables
                    RecordUpdateRequest rur = new RecordUpdateRequest();

                    Rurs = new List<RecordUpdateRequest>();

                    // Load the settings so we know what to udpate...
                    rur.EmailAddress = _config.AppSettings.Settings["EmailAddress"].Value;
                    rur.Password = _config.AppSettings.Settings["Password"].Value;
                    rur.Domain = _config.AppSettings.Settings["Domain"].Value;
                    rur.RecordId = Convert.ToInt32(_config.AppSettings.Settings["RecordId"].Value);
                    rur.RecordName = _config.AppSettings.Settings["RecordName"].Value;
                    rur.UpdateFrequencyMinutes = Convert.ToInt32(_config.AppSettings.Settings["UpdateFrequencyMinutes"].Value);
                    rur.IpAddressType = _config.AppSettings.Settings["IpAddressType"].Value;
                    rur.LastUpdated = null;

                    // Add to list.
                    Rurs.Add(rur);
                }

                // Return
                return Rurs;
            }
        }

        public void Save()
        {
            if (this.RecordUpdateRequests.Count > 0)
            {
                RecordUpdateRequest rur = this.RecordUpdateRequests[0];
                _config.AppSettings.Settings["EmailAddress"].Value = rur.EmailAddress;
                _config.AppSettings.Settings["Password"].Value = rur.Password;
                _config.AppSettings.Settings["Domain"].Value = rur.Domain;
                _config.AppSettings.Settings["RecordId"].Value = rur.RecordId.ToString();
                _config.AppSettings.Settings["RecordName"].Value = rur.RecordName;
                _config.AppSettings.Settings["UpdateFrequencyMinutes"].Value = rur.UpdateFrequencyMinutes.ToString();
            }
            
            _config.Save();
        }
    }
}
