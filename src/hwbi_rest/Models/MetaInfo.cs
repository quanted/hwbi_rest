using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class MetaInfo
    {
        public string model { get; set; }
        public string collection{ get; set; }
        public double modelVersion { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string timestamp { get; set; }
        public Url url { get; set; }

        public MetaInfo()
        {
            url = new Url();
        }
    }

    public class Url
    {
        public string type { get; set; }
        public string href { get; set; }

        public Url()
        {
            type = @"application / json";
        }
    }

    
}