using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DNSimple;

namespace DNScymbal
{
    class DnsCymbalUpdater
    {
        Thread _mainThread = new System.Threading.Thread(new System.Threading.ThreadStart(MainSvcThread));
        static ManualResetEvent _stopEvent = new ManualResetEvent(false);

        internal void Start()
        {
            _stopEvent.Reset();
            _mainThread.Start();
        }

        internal void Stop()
        {
            _stopEvent.Set();
            System.Threading.Thread.Sleep(2000);
        }

        private static void MainSvcThread()
        {
            System.Configuration.AppSettingsReader appSettings = new System.Configuration.AppSettingsReader();
            RecordUpdateRequest rur = new RecordUpdateRequest();

            // Load the settings so we know what to udpate...
            rur.EmailAddress = appSettings.GetValue("EmailAddress", typeof(string)).ToString();
            rur.Password = appSettings.GetValue("Password", typeof(string)).ToString();
            rur.Domain = appSettings.GetValue("Domain", typeof(string)).ToString();
            rur.RecordId = Convert.ToInt32(appSettings.GetValue("RecordId", typeof(int)));
            rur.RecordName = appSettings.GetValue("RecordName", typeof(string)).ToString();
            rur.RecordContent = GetPublicIP();
            rur.LastUpdated = null;
            rur.UpdateFrequencyMinutes = Convert.ToInt32(appSettings.GetValue("UpdateFrequencyMinutes", typeof(int)));

            // Loop until we are stopping
            while (!_stopEvent.WaitOne(1000))
            {
                // Check if it is time to update...
                bool bUpdate = true;
                if (rur.LastUpdated.HasValue)
                {
                    TimeSpan ts = DateTime.Now.Subtract(rur.LastUpdated.Value);
                    bUpdate = ts.TotalMinutes >= rur.UpdateFrequencyMinutes;
                }

                // Update?
                if (bUpdate)
                {
                    DNSimple.DNSimpleRestClient c = new DNSimpleRestClient(rur.EmailAddress, rur.Password);
                    c.UpdateRecord(rur.Domain, rur.RecordId, rur.RecordName, rur.RecordContent);
                    rur.LastUpdated = DateTime.Now;
                }
            }
        }

        private static string GetPublicIP()
        {
            dynamic oIP = null;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                string strJsonIP = wc.DownloadString("http://jsonip.com/");
                JsonFx.Json.JsonReader r = new JsonFx.Json.JsonReader();
                oIP = r.Read(strJsonIP);
            }
            return oIP.ip;
        }
    }
}
