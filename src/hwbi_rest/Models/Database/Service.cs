using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwbi_rest.Models.Database
{
    public class Service
    {
        public string serviceID { get; set; }
        public string serviceTypeID { get; set; }
        public string serviceName { get; set; }
        public string serviceTypeName { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
