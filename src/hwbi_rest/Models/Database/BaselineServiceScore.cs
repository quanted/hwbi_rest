using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwbi_rest.Models.Database
{
    public class BaselineServiceScore
    {
        public int county_FIPS { get; set; }
        public string stateID { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string serviceID { get; set; }
        public string serviceName { get; set; }
        public double score { get; set; }
        public string description { get; set; }
        public string serviceType { get; set; }
    }
}
