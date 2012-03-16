using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;
using Microsoft.Win32;

namespace DNScymbal
{
    #region Obsolete
    /// <summary>
    /// This class is obsolete. Use <see cref="DNScymbalSettings"/> instead.
    /// </summary>
    [Obsolete("Use DNScymbalSettings instead.", true)]
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
    #endregion

    /// <summary>
    /// The class wrapper for DNScymbal configuration settings.
    /// </summary>
    public class DNScymbalSettings
    {
        #region Private Data
        private static XmlSerializer s_xmlSerializer = new XmlSerializer(typeof(DNScymbalSettings));
        #endregion

        /// <summary>
        /// Get file name of the DNScymbal settings file.
        /// </summary>
        public const string Str_Filename = "DNScymbal.config";

        /// <summary>
        /// Gets or sets the list of Record Update Requests for the DNSimple updater.
        /// </summary>
        public List<RecordUpdateRequest> RecordUpdateRequests { get; set; }

        /// <summary>
        /// Gets or sets a boolean flag indicating whether the application should automatically start when someone logs onto the computer.
        /// </summary>
        public bool AutoStartApplication { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public DNScymbalSettings() 
        {
            this.AutoStartApplication = false;
            this.RecordUpdateRequests = new List<RecordUpdateRequest>();
        }

        /// <summary>
        /// Gets the full path and filename of the application config file.
        /// </summary>
        public static string FullName
        {
            get
            {
                string strPath = Path.GetDirectoryName(System.Windows.Forms.Application.CommonAppDataPath);
                string strSettingsFile = Path.Combine(strPath, Str_Filename);
                return strSettingsFile;
            }
        }

        /// <summary>
        /// Saves the DNScymbal applications config settings.
        /// </summary>
        public void Save()
        {
            UpdateRegistryAutoStart();

            // Save our settings.
            using (FileStream fileStream = new FileStream(DNScymbalSettings.FullName, FileMode.Create, FileAccess.Write))
            {
                s_xmlSerializer.Serialize(fileStream, this);
            }
        }

        /// <summary>
        /// Loads the DNScymbal applications config settings.
        /// </summary>
        /// <returns></returns>
        public static DNScymbalSettings Load()
        {
            DNScymbalSettings config;
            if (!File.Exists(DNScymbalSettings.FullName))
            {
                config = new DNScymbalSettings();
            }
            else
            {
                using (FileStream fileStream = new FileStream(DNScymbalSettings.FullName, FileMode.Open, FileAccess.Read))
                {
                    config = (DNScymbalSettings)s_xmlSerializer.Deserialize(fileStream);
                }
            }

            // Return
            return config;
        }

        /// <summary>
        /// Converts the specified clear text string to base64.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ConvertToBase64(string str)
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

        /// <summary>
        /// Converts the specified string from base64 to clear text.
        /// </summary>
        /// <param name="strBase64"></param>
        /// <returns></returns>
        public static string ConvertFromBase64(string strBase64)
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

        private void UpdateRegistryAutoStart()
        {
            using (RegistryKey regRun = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true))
            {
                if (this.AutoStartApplication)
                {
                    // Set the Registry setting for the autostart option
                    regRun.SetValue(this.GetType().Namespace, System.Windows.Forms.Application.ExecutablePath);
                }
                else
                {
                    // Remove the setting for autostart.
                    regRun.DeleteValue(this.GetType().Namespace);
                }
            }
        }
    }
}
