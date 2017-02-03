using System;
using System.Collections.Generic;
using System.Data;

namespace hwbi_rest.Models
{
    public class CalcRun
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaInput> inputs { get; set; }

        public Outputs outputs { get; set; }
        //public Outputs outputs { get; set; }
        public CalcRun()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = @"The Human Well-Being Index (HWBI) model calculator uses 22 economic, ecosystemm, and social services values to calculate eight 'domains of well-being': Connection to Nature, Cultural Fulfillment, Education, Health, Leisure Time, Living Standards, Safety & Security, and social Cohesion. These domains of well-being are then weighed based on user-supplied 'relative importance values' and are used to determine the overall HWBI score.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/calc/run").ToString();

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

    public class Outputs
    {
        public double hwbi { get; set; }
        public List<Service> services { get; set; }
        public List<Domain> domains { get; set; }

        public Outputs()
        {
            //services = GetServices();
            services = SqliteMgr.GetAllServices();
            //domains = GetDomains();
            domains = SqliteMgr.GetAllDomains();
        

        }

        private IEnumerable<Domain> GetDomains()
        {

            //List<Domain> domains = new List<Domain>();
            var domains = SqliteMgr.GetAllDomains();
            return domains;
            //SqliteMgr sqlMgr = new SqliteMgr();
            //DataTable dt = sqlMgr.ExecuteQuery("select * from Domains");
            //Domain domain = null;
            //foreach (DataRow dr in dt.Rows)
            //{
            //    domain = new Domain();
            //    domain.domainID = dr["DomainID"].ToString();
            //    domain.domainName = dr["domainName"].ToString();
            //    domain.description = dr["name"].ToString();                
            //    domains.Add(domain);
            //}

            //return domains;

            // Domain domain = new Domain();
            // domain.domainID = "d01";
            // domain.domainName = "connection";
            // domain.description = "Connection To Nature";
            // //domain.weight = ConnectionToNatureDomainWeight;
            // //domain.score = ConnectionToNatureDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d02";
            // domain.domainName = "culture";
            // domain.description = "Cultural Fulfillment";
            // //domain.weight = CulturalFulfillmentDomainWeight;
            // //domain.score = CulturalFulfillmentDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d03";
            // domain.domainName = "education";
            // domain.description = "Education";
            // //domain.weight = EducationDomainWeight;
            // //domain.score = EducationDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d04";
            // domain.domainName = "health";
            // domain.description = "Health";
            // //domain.weight = HealthDomainWeight;
            //// domain.score = HealthDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d05";
            // domain.domainName = "leisure";
            // domain.description = "Leisure Time";
            // //domain.weight = LeisureTimeDomainWeight;
            // //domain.score = LeisureTimeDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d06";
            // domain.domainName = "living";
            // domain.description = "Living Standards";
            // //domain.weight = LivingStandardsDomainWeight;
            // //domain.score = LivingStandardsDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d07";
            // domain.domainName = "safety";
            // domain.description = "Safety And Security";
            // //domain.weight = SafetyAndSecurityDomainWeight;
            // //domain.score = SafetyAndSecurityDomain * 100;
            // domains.Add(domain);

            // domain = new Domain();
            // domain.domainID = "d08";
            // domain.domainName = "social";
            // domain.description = "Social Cohesion";
            // //domain.weight = SocialCohesionDomainWeight;
            // //domain.score = SocialCohesionDomain * 100;
            // domains.Add(domain);


        }
    }
}