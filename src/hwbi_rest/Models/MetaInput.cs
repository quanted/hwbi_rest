using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{

    public class MetaBase
    {
        public string name { get; set; }
        public string value { get; set; }
        public string description { get; set; }

        public MetaBase() { }

        public MetaBase(string name, string value, string description)
        {
            this.name = name;
            this.value = value;
            this.description = description;
        }

        public MetaBase(MetaBase metaBase)
        {
            name = metaBase.name;
            value = metaBase.value;
            description = metaBase.description;
        }
        public MetaBase Clone()
        {
            return new MetaBase(this);
        }
    }

    public class MetaOutput 
    {
        public string name { get; set; }
        public string description { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public string unit { get; set; }
        public string type { get; set; }
        

        public MetaOutput() { }

        public MetaOutput(MetaOutput metaOutput)
        {
            this.name = metaOutput.name;
            this.min = metaOutput.min;
            this.max = metaOutput.max;
            this.unit = metaOutput.unit;
            this.type = metaOutput.type;
            this.description = metaOutput.description;
        }

        public MetaOutput Clone()
        {
            return new MetaOutput(this);
        }
    }

    public class MetaInput
    {
        public string name { get; set; }
        public string description { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public string unit { get; set; }
        public string type { get; set; }
        public bool required { get; set; }

        public MetaInput()  { }

        public MetaInput(MetaInput metaInput)
        {
            this.name = metaInput.name;
            this.min = metaInput.min;
            this.max = metaInput.max;
            this.unit = metaInput.unit;
            this.type = metaInput.type;
            this.required = metaInput.required;
            this.description = metaInput.description;
        }

        public MetaInput Clone()
        {
            return new MetaInput(this);
        }
    }


}