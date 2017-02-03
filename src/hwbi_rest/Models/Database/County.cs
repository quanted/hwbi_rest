using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwbi_rest.Models.Database
{
    public class County
    {
        public int county_FIPS { get; set; }
        public string county { get; set; }
        public string stateID { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string EPA_Region { get; set; }
        public string GSS_Region { get; set; }

    }
}
