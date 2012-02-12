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

        public List<RecordUpdateRequest> RecordUpdateRequests
        {
            get
            {
                // Local Variables
                List<RecordUpdateRequest> Rurs = new List<RecordUpdateRequest>();
                RecordUpdateRequest rur = new RecordUpdateRequest();

                // Load the settings so we know what to udpate...
                rur.EmailAddress = _config.AppSettings.Settings["EmailAddress"].Value;
                rur.Password = _config.AppSettings.Settings["Password"].Value;
                rur.Domain = _config.AppSettings.Settings["Domain"].Value;
                rur.RecordId = Convert.ToInt32(_config.AppSettings.Settings["RecordId"].Value);
                rur.RecordName = _config.AppSettings.Settings["RecordName"].Value;
                rur.UpdateFrequencyMinutes = Convert.ToInt32(_config.AppSettings.Settings["UpdateFrequencyMinutes"].Value);
                rur.LastUpdated = null;

                // Add to list.
                Rurs.Add(rur);

                // Return
                return Rurs;
            }
        }

        public void Save()
        {
            Debugger.Log(0, "", _config.FilePath);
        }
    }
}
