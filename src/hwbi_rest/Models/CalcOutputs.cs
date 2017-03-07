using System;
using System.Collections.Generic;

namespace hwbi_rest.Models
{
    public class CalcOutputs
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaOutput> metaOutputs { get; set; }

        public CalcOutputs()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model calculator provides eight 'domain of well-being' scores and an overall HWBI score.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/calc/outputs").ToString();

            metaOutputs = new List<MetaOutput>();
            MetaOutput metaOutput = null;

            var domains = SqliteMgr.GetAllDomains();
            //SqliteMgr sqlMgr = new SqliteMgr();
            //DataTable dt = sqlMgr.ExecuteQuery("select * from Domains");
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

            metaOutput = new MetaOutput();
            metaOutput.name = "hwbi";
            metaOutput.min = 0.0;
            metaOutput.max = 5.0;
            metaOutput.unit = "hwbi score";
            metaOutput.type = "int";
            metaOutput.description = "human well-being index";
            metaOutputs.Add(metaOutput);            

        }
    }
}