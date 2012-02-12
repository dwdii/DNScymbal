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
        static ConfigSettings _configSettings = new ConfigSettings();

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
            List<RecordUpdateRequest> Rurs = _configSettings.RecordUpdateRequests;

            // Loop until we are stopping
            while (!_stopEvent.WaitOne(1000))
            {
                foreach(RecordUpdateRequest rur in Rurs)
                {
                    rur.Validate();

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

                        rur.RecordContent = GetPublicIP();
                        c.UpdateRecord(rur.Domain, rur.RecordId, rur.RecordName, rur.RecordContent);
                        rur.LastUpdated = DateTime.Now;
                    }
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
