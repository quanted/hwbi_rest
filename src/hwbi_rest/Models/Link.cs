using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
        //public string postRequestExample { get; set; }
    }
}