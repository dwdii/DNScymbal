using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DNSimple;
using System.Windows.Forms;
using DNScymbal.Azure;

namespace DNScymbal
{
    class DnsCymbalUpdater
    {
        Thread _mainThread = null;
        static ManualResetEvent _stopEvent = new ManualResetEvent(false);

        internal void Start()
        {
            _stopEvent.Reset();

            _mainThread = new System.Threading.Thread(new System.Threading.ThreadStart(MainSvcThread));
            _mainThread.Start();
        }

        internal void Stop()
        {
            _stopEvent.Set();
            if (!_mainThread.Join(10000))
            {
                _mainThread.Abort();
            }
        }

        internal void Restart()
        {
            this.Stop();
            this.Start();
        }

        private static void MainSvcThread()
        {
            try
            {
                ConfigSettings configSettings = new ConfigSettings();

                //SqlAzureRest sar = new SqlAzureRest();
                //sar.ServerName = "rfu3pk0bka";
                //sar.SubscriptionId = "9799e688-6fa7-4085-ab24-9b6d9233e2ad";
                //sar.SetServerFirewallRuleWithIpDetect();

                // Loop until we are stopping
                while (!_stopEvent.WaitOne(1000))
                {
                    foreach (RecordUpdateRequest rur in configSettings.RecordUpdateRequests)
                    {
                        UpdateRecordIfNeeded(rur);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void UpdateRecordIfNeeded(RecordUpdateRequest rur)
        {
            try
            {
                // Is the update request enabled?
                if (rur.Enabled)
                {
                    // Yes, so validate first
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
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message, Properties.Resources.Str_DNSimpleUpdaterThread_MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static string GetPublicIP()
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
