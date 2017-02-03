using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class Domain
    {
        public string domainID { get; set; }
        public string domainName { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public double score { get; set; }
        public double weight { get; set; }

    }
}