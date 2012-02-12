using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNScymbal
{
    class RecordUpdateRequest
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public int RecordId { get; set; }
        public string RecordContent { get; set; }
        public string RecordName { get; set; }
        public int UpdateFrequencyMinutes { get; set; }
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
    }
}
