using System;
using System.Collections.Generic;
using System.Linq;
using hwbi_rest.Models;

namespace hwbi_rest.Models
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

        public double Score  { get; set; }
        public Service()
        {

        }       
            
    }
}