using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class Results
    {
        public HWBI hwbi { get; set; }
        public List<Service> services { get; set; }
        public List<Domain> domains { get; set; }
        public Results()
        {
            services = new List<Service>();
            domains = new List<Domain>();
            hwbi = new Models.HWBI();
        }
    }
}