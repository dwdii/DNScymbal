using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DNScymbal
{
    public class RecordUpdateRequest
    {
        public bool Enabled { get; set; }
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or sets the clear text password associated with the DNS host account.
        /// </summary>
        [XmlIgnore]
        public string Password 
        {
            get
            {
                return DNScymbalSettings.ConvertFromBase64(this.Password64);
            }

            set
            {
                this.Password64 = DNScymbalSettings.ConvertToBase64(value);
            }
        }
        public string Password64 { get; set; }
        public string Domain { get; set; }
        public int RecordId { get; set; }
        public string RecordContent { get; set; }
        public string RecordName { get; set; }
        public int UpdateFrequencyMinutes { get; set; }
        public string IpAddressType { get; set; }

        [XmlIgnore]
        public DateTime? LastUpdated { get; set; }

        /// <summary>
        /// Performs a cursory validation of this record update request.
        /// </summary>
        /// <exception cref="System.ArgumentException">If a given field does not meet required criteria, this exception will be thrown.</exception>
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                throw new ArgumentException("Email Address must contain the DNSimple email address of the account holder.", "Email Address");
            }
        }

        public class IpAddressTypes
        {
            public const string JsonIp = "JsonIp.com";
        }

    }
}
