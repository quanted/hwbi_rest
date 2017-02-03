using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwbi_rest.Models.Database
{
    public class Domain
    {
        public string domainID { get; set; }
        public string domainName { get; set; }
        public string name { get; set; }
        public int min { get; set; }
        public int max { get; set; }
    }
}
