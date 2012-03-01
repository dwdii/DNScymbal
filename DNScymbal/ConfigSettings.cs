using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.IO;

namespace DNScymbal
{
    class ConfigSettings
    {
        class Name
        {
            public const string DNSimple_UpdaterEnabled = "DNSimple_UpdaterEnabled";
            public const string DNSimple_Email = "DNSimple_EmailAddr";
            public const string DNSimple_Pword = "DNSimple_Pword";
            public const string DNSimple_Domain = "DNSimple_Domain";
            public const string DNSimple_RecordId = "DNSimple_RecordId";
            public const string DNSimple_RecordName = "DNSimple_RecordName";
            public const string DNSimple_UpdateFreqMinutes = "DNSimple_UpdateFreqMinutes";
            public const string DNSimple_IpAddressType = "DNSimple_IpAddressType";
        }

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
                    rur.Enabled = Convert.ToBoolean(_config.AppSettings.Settings[Name.DNSimple_UpdaterEnabled].Value);
                    rur.EmailAddress = _config.AppSettings.Settings[Name.DNSimple_Email].Value;
                    rur.Password = ConvertFromBase64(_config.AppSettings.Settings[Name.DNSimple_Pword].Value);
                    rur.Domain = _config.AppSettings.Settings[Name.DNSimple_Domain].Value;
                    rur.RecordId = Convert.ToInt32(_config.AppSettings.Settings[Name.DNSimple_RecordId].Value);
                    rur.RecordName = _config.AppSettings.Settings[Name.DNSimple_RecordName].Value;
                    rur.UpdateFrequencyMinutes = Convert.ToInt32(_config.AppSettings.Settings[Name.DNSimple_UpdateFreqMinutes].Value);
                    rur.IpAddressType = _config.AppSettings.Settings[Name.DNSimple_IpAddressType].Value;
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
                _config.AppSettings.Settings[Name.DNSimple_UpdaterEnabled].Value = rur.Enabled.ToString();
                _config.AppSettings.Settings[Name.DNSimple_Email].Value = rur.EmailAddress;
                _config.AppSettings.Settings[Name.DNSimple_Pword].Value = ConvertToBase64(rur.Password);
                _config.AppSettings.Settings[Name.DNSimple_Domain].Value = rur.Domain;
                _config.AppSettings.Settings[Name.DNSimple_RecordId].Value = rur.RecordId.ToString();
                _config.AppSettings.Settings[Name.DNSimple_RecordName].Value = rur.RecordName;
                _config.AppSettings.Settings[Name.DNSimple_UpdateFreqMinutes].Value = rur.UpdateFrequencyMinutes.ToString();
            }
            
            _config.Save();
        }

        public string ConvertToBase64(string str)
        {
            string strBase64 = string.Empty;
            using (MemoryStream strm = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(strm))
                {
                    sw.Write(str);
                    sw.Flush();
                    strm.Seek(0, SeekOrigin.Begin);
                    strBase64 = Convert.ToBase64String(strm.ToArray());
                }
            }

            return strBase64;
        }

        public string ConvertFromBase64(string strBase64)
        {
            byte[] bytes = Convert.FromBase64String(strBase64);
            string str = string.Empty;
            using (MemoryStream strm = new MemoryStream())
            {
                strm.Write(bytes, 0, bytes.Length);
                strm.Flush();
                strm.Seek(0, SeekOrigin.Begin);
                using (StreamReader sr = new StreamReader(strm))
                {
                    str = sr.ReadToEnd();
                }
            }

            return str;
            
        }
    }
}
