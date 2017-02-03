using System;
using System.Collections.Generic;
using System.Data;

namespace hwbi_rest.Models
{
    public class LocationRun
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaInput> inputs { get; set; }
        public Outputs outputs { get; set; }

        public LocationRun()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model locations endpoint uses state and county names to provide values for 22 economic, ecosystem, and social services, 8 domains of well-being, and a total HWBI score for the county.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/run").ToString();

            inputs = GetInputs();
            outputs = new Outputs();
        }

        private List<MetaInput> GetInputs()
        {
            inputs = new List<MetaInput>();
            var services = SqliteMgr.GetAllServices();
            //SqliteMgr sqlMgr = new SqliteMgr();
            //DataTable dt = sqlMgr.ExecuteQuery("select * from Services");

            foreach (var service in services)
            {
                MetaInput metaInput = new MetaInput();
                metaInput.name = service.name;
                metaInput.min = service.min;
                metaInput.max = service.max;
                metaInput.unit = service.serviceTypeName;
                metaInput.type = "number";
                metaInput.required = true;
                metaInput.description = service.serviceName;
                inputs.Add(metaInput);
            }

            return inputs;
        }
    }
}