using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwbi_rest.Models.Database
{
    public class ServiceScore_Baseline
    {
        public int county_FIPS { get; set; }
        public string serviceID { get; set; }
        public double score { get; set; }
        public double stdError { get; set; }
        public string dataYear { get; set; }
    }
}
