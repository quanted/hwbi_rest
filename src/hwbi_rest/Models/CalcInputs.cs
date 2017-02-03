using System;
using System.Collections.Generic;
using System.Data;

namespace hwbi_rest.Models
{
    public class CalcInputs
    {
        public MetaInfo metaInfo { get; set; }
        public List<MetaInput> metaInputs { get; set; }

        public CalcInputs()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model calculator requires twenty-two economic; ecosystem; and social service values and a 'relative importance value' for each of the eight domains of well-being.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/calc/inputs").ToString();

            metaInputs = GetMetaInputs();

        }

        private List<MetaInput> GetMetaInputs()
        {
            metaInputs = new List<MetaInput>();

            //SqliteMgr sqlMgr = new SqliteMgr();
            //DataTable dt = sqlMgr.ExecuteQuery("select * from Services");
            var services = SqliteMgr.GetAllServices();

            foreach(var service in services)
            {
                MetaInput metaInput = new MetaInput();
                metaInput.name = service.name;
                metaInput.min = service.min;
                metaInput.max = service.max;
                metaInput.unit = service.serviceTypeName;
                metaInput.type = "number";
                metaInput.required = true;
                metaInput.description = service.serviceName;
                metaInputs.Add(metaInput);
            }

            //dt = sqlMgr.ExecuteQuery("select * from Domains");
            var domains = SqliteMgr.GetAllDomains();

            foreach (var domain in domains)
            {
                MetaInput metaInput = new MetaInput();
                metaInput.name = domain.name;
                metaInput.min = domain.min;
                metaInput.max = domain.max;
                metaInput.unit = "domain weight";
                metaInput.type = "number";
                metaInput.required = true;
                metaInput.description = domain.domainName;
                metaInputs.Add(metaInput);
            }

            return metaInputs;

            //MetaInput metaInput = new MetaInput();

      //      metaInput.name = "capitalInvestment";
		    //metaInput.min = 56.31683197;
		    //metaInput.max = 61.75389692;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Capital Investment";
      //      metaInputs.Add(metaInput.Clone());
           


		    //metaInput.name = "consumption";
		    //metaInput.min = 47.42882423;
		    //metaInput.max = 54.04916975;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Consumption";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "employment";
		    //metaInput.min = 33.13814798;
		    //metaInput.max = 72.57176231;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Employment";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "finance";
		    //metaInput.min = 31.42250002;
		    //metaInput.max = 61.56578545;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Finance";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "innovation";
		    //metaInput.min = 25.89488723;
		    //metaInput.max = 65.3289721;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Innovation";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "production";
		    //metaInput.min = 45.11697104;
		    //metaInput.max = 51.67193166;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Production";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "redistribution";
		    //metaInput.min = 23.51316313;
		    //metaInput.max = 68.92691912;
		    //metaInput.unit = "economic service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Re-Distribution";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "airQuality";
		    //metaInput.min = 10;
		    //metaInput.max = 90;
		    //metaInput.unit = "ecosystem service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Air Quality";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "foodFiberAndFuel";
		    //metaInput.min = 32.62908483;
		    //metaInput.max = 48.49178319;
		    //metaInput.unit = "ecosystem service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Food; Fiber And Fuel Provisioning";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "greenspace";
		    //metaInput.min = 36.11207908;
		    //metaInput.max = 62.03906984;
		    //metaInput.unit = "ecosystem service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Greenspace";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "waterQuality";
		    //metaInput.min = 15.95637509;
		    //metaInput.max = 88.22033237;
		    //metaInput.unit = "ecosystem service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Water Quality";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "waterQuantity";
		    //metaInput.min = 21.70976841;
		    //metaInput.max = 72.83447998;
		    //metaInput.unit = "ecosystem service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Water Quantity";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "activism";
		    //metaInput.min = 25.85945275;
		    //metaInput.max = 73.66346154;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Activism";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "communication";
		    //metaInput.min = 33.10020486;
		    //metaInput.max = 68.98955269;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Communication";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "communityAndFaith";
		    //metaInput.min = 12.21375305;
		    //metaInput.max = 90;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Community and Faith-Based Initiatives";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "education";
		    //metaInput.min = 33.24429069;
		    //metaInput.max = 56.47803694;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Education";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "emergencyPreparedness";
		    //metaInput.min = 19.78920564;
		    //metaInput.max = 76.07510118;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Emergency Preparedness";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "familyServices";
		    //metaInput.min = 42.66833596;
		    //metaInput.max = 73.35259094;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Family Services";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "healthcare";
		    //metaInput.min = 29.63020433;
		    //metaInput.max = 62.25876617;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Healthcare";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "justice";
		    //metaInput.min = 31.22560175;
		    //metaInput.max = 71.78167536;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Justice";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "labor";
		    //metaInput.min = 36.52332879;
		    //metaInput.max = 53.29715035;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Labor";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "publicWorks";
		    //metaInput.min = 33.53645478;
		    //metaInput.max = 66.4893089;
		    //metaInput.unit = "social service score";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Public Works";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "connectionToNatureDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Connection to Nature relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "culturalFulfillmentDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Cultural Fulfillment relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "educationDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Education relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "healthDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Health relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "leisureTimeDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Leisure Time relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "livingStandardsDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Living Standards relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      metaInput.name = "safetyAndSecurityDomainWeight";
		    //metaInput.min = 0;               
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Safety and Security relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());
	
		    //metaInput.name = "socialCohesionDomainWeight";
		    //metaInput.min = 0;
		    //metaInput.max = 5;
		    //metaInput.unit = "domain weight";
		    //metaInput.type = "int";
		    //metaInput.required = true;
      //      metaInput.description = "Social Cohesion relative importance index domain weight";
      //      metaInputs.Add(metaInput.Clone());

      //      return metaInputs;
        }
        
    }
}