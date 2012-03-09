using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;

namespace DNScymbal.Azure
{
    class SqlAzureRest
    {
        RestSharp.RestClient _rc = new RestSharp.RestClient("https://management.database.windows.net:8443/");

        public string SubscriptionId { get; set; }
        public string ServerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Need to authenticate. See http://msdn.microsoft.com/en-us/library/windowsazure/gg715282.aspx
        /// </remarks>
        public void SetServerFirewallRuleWithIpDetect()
        {
            var request = new RestRequest("{subscription-id}/servers/{servername}/firewallrules/{rulename}?op=AutoDetectClientIP", Method.POST);

            request.AddUrlSegment("subscription-id", SubscriptionId);
            request.AddUrlSegment("servername", ServerName);
            request.AddUrlSegment("rulename", string.Format("{0}-DNScymbal", Environment.MachineName));

            request.AddHeader("x-ms-version", "1.0");

            // execute the request
            RestResponse response = _rc.Execute(request);
            var content = response.Content; // raw content as string

        }

    }
}
