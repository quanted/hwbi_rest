using System;
using System.Collections.Generic;
using System.Data;

namespace hwbi_rest.Models
{
    public class LocationOutputs
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaOutput> metaOutputs { get; set; }

        public LocationOutputs()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model locations endpoint uses state and county names to provide values for 22 economic, ecosystem, and social services, 8 domains of well-being, and a total HWBI score for the county.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/outputs").ToString();

            metaOutputs = new List<MetaOutput>();
            MetaOutput metaOutput = null;            

            //dt = sqlMgr.ExecuteQuery("select * from Domains");
            var domains = SqliteMgr.GetAllDomains();
            foreach (var domain in domains)
            {
                metaOutput = new MetaOutput();
                metaOutput.name = domain.name;
                metaOutput.min = domain.min;
                metaOutput.max = domain.max;
                metaOutput.unit = "domain score";
                metaOutput.type = "number";
                metaOutput.description = domain.domainName;
                metaOutputs.Add(metaOutput);
            }

            var services = SqliteMgr.GetAllServices();
            metaOutputs = new List<MetaOutput>();
            foreach (var service in services)
            {
                metaOutput = new MetaOutput();
                metaOutput.name = service.name;
                metaOutput.min = service.min;
                metaOutput.max = service.max;
                metaOutput.unit = service.serviceTypeName;
                metaOutput.type = "number";
                metaOutput.description = service.serviceName;
                metaOutputs.Add(metaOutput);
            }

            metaOutput = new MetaOutput();
            metaOutput.name = "hwbi";
            metaOutput.min = 0;
            metaOutput.max = 100;
            metaOutput.unit = "hwbi score";
            metaOutput.type = "number";
            metaOutput.description = "human well-being index";
            metaOutputs.Add(metaOutput);      
            
        }

    }
}