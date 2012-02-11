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
    }
}
