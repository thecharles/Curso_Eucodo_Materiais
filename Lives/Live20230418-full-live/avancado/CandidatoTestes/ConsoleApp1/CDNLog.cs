using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateTesting.CharlesAugustoSilva.Converters
{
    /// <summary>
    /// Responsiable to convert the string into an object.
    /// </summary>
    public class CDNLog
    {
        public string ResponseSize { get; set; }
        public string StatusCode { get; set; }
        public string CacheStatus { get; set; }
        public string RequestLine { get; set; }
        public decimal TimeTaken { get; set; }
        public string HttpMethod { get; set; }
        public string UriPath { get; set; }

        public bool IsValid { get { return StatusCode != null; } }

        public CDNLog() { }

        public CDNLog(string logText)
        {
            string[] parts = logText.Split('|');
            if (parts.Length != 5)
                return;

            this.ResponseSize = parts[0];
            this.StatusCode = parts[1];
            this.CacheStatus = parts[2];
            this.RequestLine = parts[3].Trim('"');
            this.TimeTaken = decimal.Parse(parts[4].Replace(".", ","));

            string[] requestParts = this.RequestLine.Split(' ');
            this.HttpMethod = requestParts[0];
            this.UriPath = requestParts[1];

            if (this.CacheStatus == "INVALIDATE")
            {
                this.CacheStatus = "REFRESH_HIT";
            }
        }
    }
}
