using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class LocationInputs
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaInput> metaInputs { get; set; }

        public LocationInputs()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model locations endpoint requires USA state and county names.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/inputs").ToString();

            metaInputs = new List<MetaInput>();

            MetaInput metaInput = new MetaInput();
            metaInput.name = "State";
            metaInput.type = "text";
            metaInput.description = "United States of America state name";
            metaInput.required = true;
            metaInputs.Add(metaInput);

            MetaInput metaInput2 = new MetaInput();
            metaInput2.name = "County";
            metaInput2.type = "text";
            metaInput2.description = "United States of America county name";
            metaInput2.required = true;
            metaInputs.Add(metaInput2);
            
        }
    }
}