using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class Parameter
    {
        public string name { get; set; }
        public string description { get; set; }
        public string value { get; set; }

        public Parameter()
        {

        }
        public Parameter(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public Parameter(string name, string value, string description)
        {
            this.name = name;
            this.description = description;
            this.value = value;
        }

    }
}