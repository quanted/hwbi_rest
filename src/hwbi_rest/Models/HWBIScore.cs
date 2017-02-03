using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Collections;
using System.Reflection;

namespace hwbi_rest.Models
{
    public class HWBIScore
    {
        //private List<Service> Services = null;
        //private List<Domain> Domains = null;
        public MetaInfo metaInfo { get; }
        public List<MetaBase> inputs { get; }
        public Outputs outputs { get; }
        
        //public string Message = "";

        public HWBIScore()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) model calculator (calc) uses 22 economic, ecosystem, and social services values to calculate eight 'domains of well-being': Connection to Nature, Cultural Fulfillment, Education, Health, Leisure Time, Living Standards, Safety & Security, and Social Cohesion. These domains of well-being are then weighed based on user-supplied 'relative importance values' and are used to determine the overall HWBI score.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(@"rest/hwbi/calc/run").ToString();
            inputs = new List<MetaBase>();
            outputs = new Outputs();            
            
    }
        public HWBIScore(string State, string County) :this()
        {            
            try
            {
                MetaBase mb = new MetaBase("state", State, "US State");
                MetaBase mb2 = new MetaBase("county", County, "County");
                inputs.Add(mb);
                inputs.Add(mb2);

                GetBaselineScores(State, County);
                metaInfo.status = "Finished";

            }
            catch(Exception ex)
            {
                metaInfo.status = "Error - " + ex.Message;
            }
           
        }

        public HWBIScore(HWBICalcScore calc):this()
        {        
            try
            {


                if (calc == null)
                    throw new Exception("Invalid input parameters");

                Scores scores = calc.scores;
                DomainWeights weights = calc.domainWeights;

                List<MetaBase> list = BuildParameterList(calc);
                inputs.AddRange(list);

                Calculate(scores.capitalInvestment, scores.consumption, scores.employment, scores.finance, scores.innovation, scores.production, scores.redistribution,
                            scores.airQuality, scores.foodFiberAndFuel, scores.greenspace, scores.waterQuality, scores.waterQuantity, scores.activism, scores.communication,
                            scores.communityAndFaith, scores.education, scores.emergencyPreparedness, scores.familyServices, scores.healthcare, scores.justice, scores.labor,
                            scores.publicWorks, weights.connectionToNature, weights.culturalFulfillment, weights.education, weights.health, weights.leisureTime,
                            weights.livingStandards, weights.safetyAndSecurity, weights.socialCohesion);

                metaInfo.status = "Finished";                
            }
            catch(Exception ex)
            {
                metaInfo.status = "Error - " + ex.Message;
            }

        }
        public HWBIScore(double CapitalInvestment_Score, double Consumption_Score, double Employment_Score, double Finance_Score, double Innovation_Score,
                         double Production_Score, double ReDistribution_Score, double AirQuality_Score, double FoodFiberAndFuelProvisioning_Score,
                         double Greenspace_Score, double WaterQuality_Score, double WaterQuantity_Score, double Activism_Score, double Communication_Score,
                         double CommunityAndFaithBasedInitiatives_Score, double Education_Score, double EmergencyPreparedness_Score, double FamilyServices_Score,
                         double Healthcare_Score, double Justice_Score, double Labor_Score, double PublicWorks_Score,
                         double ConnectionToNatureDomain_Weight, double CulturalFulfillmentDomain_Weight, double EducationDomain_Weight, double HealthDomain_Weight,
                         double LeisureTimeDomain_Weight, double LivingStandardsDomain_Weight, double SafetyAndSecurityDomain_Weight, double SocialCohesionDomain_Weight) :this()
        {
            try
            {
                HWBICalcScore calc = new HWBICalcScore();
                calc.scores.capitalInvestment = CapitalInvestment_Score;
                calc.scores.consumption = Consumption_Score;
                calc.scores.employment = Employment_Score;
                calc.scores.finance = Finance_Score;
                calc.scores.innovation = Innovation_Score;
                calc.scores.production = Production_Score;
                calc.scores.redistribution = ReDistribution_Score;
                calc.scores.airQuality = AirQuality_Score;
                calc.scores.foodFiberAndFuel = FoodFiberAndFuelProvisioning_Score;
                calc.scores.greenspace = Greenspace_Score;
                calc.scores.waterQuality = WaterQuality_Score;
                calc.scores.waterQuantity = WaterQuantity_Score;
                calc.scores.activism = Activism_Score;
                calc.scores.communication = Communication_Score;
                calc.scores.communityAndFaith = CommunityAndFaithBasedInitiatives_Score;
                calc.scores.education = Education_Score;
                calc.scores.emergencyPreparedness = EmergencyPreparedness_Score;
                calc.scores.familyServices = FamilyServices_Score;
                calc.scores.healthcare = Healthcare_Score;
                calc.scores.justice = Justice_Score;
                calc.scores.labor = Labor_Score;
                calc.scores.publicWorks = PublicWorks_Score;

                calc.domainWeights.connectionToNature = ConnectionToNatureDomain_Weight;
                calc.domainWeights.culturalFulfillment = CulturalFulfillmentDomain_Weight;
                calc.domainWeights.education = EducationDomain_Weight;
                calc.domainWeights.health = Healthcare_Score;
                calc.domainWeights.leisureTime = LeisureTimeDomain_Weight;
                calc.domainWeights.livingStandards = LivingStandardsDomain_Weight;
                calc.domainWeights.safetyAndSecurity = SafetyAndSecurityDomain_Weight;
                calc.domainWeights.leisureTime = LeisureTimeDomain_Weight;

                Calculate(CapitalInvestment_Score, Consumption_Score, Employment_Score, Finance_Score, Innovation_Score,
                                      Production_Score, ReDistribution_Score, AirQuality_Score, FoodFiberAndFuelProvisioning_Score,
                                      Greenspace_Score, WaterQuality_Score, WaterQuantity_Score, Activism_Score, Communication_Score,
                                      CommunityAndFaithBasedInitiatives_Score, Education_Score, EmergencyPreparedness_Score, FamilyServices_Score,
                                      Healthcare_Score, Justice_Score, Labor_Score, PublicWorks_Score, ConnectionToNatureDomain_Weight,
                                      CulturalFulfillmentDomain_Weight, EducationDomain_Weight, HealthDomain_Weight, LeisureTimeDomain_Weight,
                                      LivingStandardsDomain_Weight, SafetyAndSecurityDomain_Weight, SocialCohesionDomain_Weight);

                metaInfo.status = "Finished";
                //parameters = BuildParameterList(calc);
            }
            catch(Exception ex)
            {
                metaInfo.status = "Error - " + ex.Message;
            }
        }

        private void Calculate(double CapitalInvestment_Score, double Consumption_Score, double Employment_Score, double Finance_Score, double Innovation_Score,
                         double Production_Score, double ReDistribution_Score, double AirQuality_Score, double FoodFiberAndFuelProvisioning_Score,
                         double Greenspace_Score, double WaterQuality_Score, double WaterQuantity_Score, double Activism_Score, double Communication_Score,
                         double CommunityAndFaithBasedInitiatives_Score, double Education_Score, double EmergencyPreparedness_Score, double FamilyServices_Score,
                         double Healthcare_Score, double Justice_Score, double Labor_Score, double PublicWorks_Score,
                         double ConnectionToNatureDomain_Weight, double CulturalFulfillmentDomain_Weight, double EducationDomain_Weight, double HealthDomain_Weight,
                         double LeisureTimeDomain_Weight, double LivingStandardsDomain_Weight, double SafetyAndSecurityDomain_Weight, double SocialCohesionDomain_Weight)
        {

        
            string errorMsg = "";
            ValidateServiceScores(CapitalInvestment_Score, Consumption_Score, Employment_Score, Finance_Score, Innovation_Score,
                                  Production_Score, ReDistribution_Score, AirQuality_Score, FoodFiberAndFuelProvisioning_Score,
                                  Greenspace_Score, WaterQuality_Score, WaterQuantity_Score, Activism_Score, Communication_Score,
                                  CommunityAndFaithBasedInitiatives_Score, Education_Score, EmergencyPreparedness_Score, FamilyServices_Score,
                                  Healthcare_Score, Justice_Score, Labor_Score, PublicWorks_Score, out errorMsg);
            if (errorMsg != "")
            {
                throw new Exception(errorMsg);
                //Message = errorMsg;
                //return;
            }
            validateDomainWeights(ConnectionToNatureDomain_Weight, CulturalFulfillmentDomain_Weight, EducationDomain_Weight, HealthDomain_Weight,
                                  LeisureTimeDomain_Weight, LivingStandardsDomain_Weight, SafetyAndSecurityDomain_Weight, SocialCohesionDomain_Weight, out errorMsg);
            if (errorMsg != "")
            {
                throw new Exception(errorMsg);
                //Message = errorMsg;
                //return;
            }

            Service service = null;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S01");
            service.Score = CapitalInvestment_Score;
            //service.serviceID = "S01";
            //service.name = "capitalInvestment";
            //service.serviceType = "economic";
            //service.description = "Capital Investment";
            //service.Score = CapitalInvestment_Score;           
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S02");
            service.Score = Consumption_Score;
            //service.name = "consumption";
            //service.serviceType = "conomic";
            //service.description = "Consumption";           
            //service.Score = Consumption_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S03");
            service.Score = Employment_Score;
            //service.name = "Employment";
            //service.serviceType = "Economic";
            //service.description = "Employment";
            //service.Score = Employment_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S04");
            service.Score = Finance_Score;
            //service.name = "Finance";
            //service.serviceType = "Economic";
            //service.description = "Finance";
            //service.Score = Finance_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S05");
            service.Score = Innovation_Score;
            //service.name = "Innovation";
            //service.serviceType = "Economic";
            //service.description = "Innovation";
            //service.Score = Innovation_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S06");
            service.Score = Production_Score;
            //service.name = "Production";
            //service.serviceType = "Economic";
            //service.description = "Production";
            //service.Score = Production_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S07");
            service.Score = ReDistribution_Score;
            //service.name = "Re-Distribution";
            //service.serviceType = "Economic";
            //service.description = "Re-Distribution";
            //service.Score = ReDistribution_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S08");
            service.Score = Consumption_Score;
            //service.name = "Air Quality";
            //service.serviceType = "Ecosystem";
            //service.description = "Air Quality";
            //service.Score = AirQuality_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S09");
            service.Score = FoodFiberAndFuelProvisioning_Score;
            //service.name = "Food, Fiber, Fuel";
            //service.serviceType = "Ecosystem";
            //service.description = "Food, Fiber And Fuel Provisioning";
            //service.Score = FoodFiberAndFuelProvisioning_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S10");
            service.Score = Greenspace_Score;
            //service.name = "Greenspace";
            //service.serviceType = "Ecosystem";
            //service.description = "Greenspace";
            //service.Score = Greenspace_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S11");
            service.Score = WaterQuality_Score;
            //service.name = "Water Quality";
            //service.serviceType = "Ecosystem";
            //service.description = "Water Quality";
            //service.Score = WaterQuality_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S12");
            service.Score = WaterQuantity_Score;
            //service.name = "Water Quantity";
            //service.serviceType = "Ecosystem";
            //service.description = "Water Quantity";
            //service.Score = WaterQuantity_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S13");
            service.Score = Activism_Score;
            //service.name = "Activism";
            //service.serviceType = "Social";
            //service.description = "Activism";
            //service.Score = Activism_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S14");
            service.Score = Communication_Score;
            //service.name = "Communication";
            //service.serviceType = "Social";
            //service.description = "Communication";
            //service.Score = Communication_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S15");
            service.Score = CommunityAndFaithBasedInitiatives_Score;
            //service.name = "Community and Faith";
            //service.serviceType = "Social";
            //service.description = "Community and Faith-Based Initiatives";
            //service.Score = CommunityAndFaithBasedInitiatives_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S16");
            service.Score = Education_Score;
            //service.name = "Education";
            //service.serviceType = "Social";
            //service.description = "Education";
            //service.Score = Education_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S17");
            service.Score = EmergencyPreparedness_Score;
            //service.name = "Emergency Preparedness";
            //service.serviceType = "Social";
            //service.description = "Emergency Preparedness";
            //service.Score = EmergencyPreparedness_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S18");
            service.Score = FamilyServices_Score;
            //service.name = "Family Services";
            //service.serviceType = "Social";
            //service.description = "Family Services";
            //service.Score = FamilyServices_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S19");
            service.Score = Healthcare_Score;
            //service.name = "Healthcare";
            //service.serviceType = "Social";
            //service.description = "Healthcare";
            //service.Score = Healthcare_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S20");
            service.Score = Justice_Score;
            //service.name = "Justice";
            //service.serviceType = "Social";
            //service.description = "Justice";
            //service.Score = Justice_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S21");
            service.Score = Labor_Score;
            //service.name = "Labor";
            //service.serviceType = "Social";
            //service.description = "Labor";
            //service.Score = Labor_Score;
            //outputs.services.Add(service);

            service = outputs.services.SingleOrDefault(item => item.serviceID == "S22");
            service.Score = PublicWorks_Score;
            //service.name = "Public Works";
            //service.serviceType = "Social";
            //service.description = "Public Works";
            //service.Score = PublicWorks_Score;
            //outputs.services.Add(service);
            CalculateHWBI(ConnectionToNatureDomain_Weight, CulturalFulfillmentDomain_Weight, EducationDomain_Weight, HealthDomain_Weight,
                            LeisureTimeDomain_Weight, LivingStandardsDomain_Weight, SafetyAndSecurityDomain_Weight, SocialCohesionDomain_Weight);
        }

        protected void GetBaselineScores(string state, string county)
        {
            //string errorMsg = "";
            //DB db = new DB();
            var baseLineSvcScores = SqliteMgr.GetBaselineServiceScores(state, county);
            foreach(var blSvcScore in baseLineSvcScores)
            {
                //Service service = outputs.services.SingleOrDefault(item => item.serviceID == blSvcScore.serviceID);
                Service service = outputs.services.Where(i => i.serviceID == blSvcScore.serviceID).FirstOrDefault();
                bool eq = Object.ReferenceEquals(service, outputs.services[0]);
                service.Score = blSvcScore.score;
            }
            //DataTable dt = db.getBaselineServiceScoresFromDB(state, county, out errorMsg);
            //if (errorMsg != "")
            //{
            //    throw new System.Exception("Internal error retrieving Baseline Service Scores from DB.");
            //}
            //string serviceId = "";
            //string serviceName = "";
            //double score = 0;
            //Hashtable htServiceScores = new Hashtable();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    serviceId = dr["ServiceID"].ToString();
            //    serviceName = dr["ServiceName"].ToString();
            //    //score = Convert.ToDouble(dr["Score"].ToString()) / 100.0;
            //    score = Convert.ToDouble(dr["Score"].ToString());
            //    //Prepare Service Object
            //    //Service service = new Service();
            //    Service service = outputs.services.SingleOrDefault(item => item.serviceID == serviceId);
            //    //service.serviceID = serviceId;
            //    //service.name = serviceName;
            //    service.Score = score;
            //    //service.description = dr["description"].ToString();
            //    //service.serviceType = dr["serviceType"].ToString();
            //    //outputs.services.Add(service);
            //    //Add Service Object to the list of Services
                
            //}
            CalculateHWBI(1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0);
        }
        protected void CalculateDomainScores(double ConnectionToNatureDomainWeight, double CulturalFulfillmentDomainWeight, double EducationDomainWeight,
                              double HealthDomainWeight, double LeisureTimeDomainWeight, double LivingStandardsDomainWeight,
                              double SafetyAndSecurityDomainWeight, double SocialCohesionDomainWeight)
        {
            Service service =outputs.services.SingleOrDefault(item => item.serviceID == "S01");
            double s01 = service.Score /100.0;
            service =outputs.services.SingleOrDefault(item => item.serviceID == "S02");
            double s02 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S03");
            double s03 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S04");
            double s04 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S05");
            double s05 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S06");
            double s06 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S07");
            double s07 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S08");
            double s08 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S09");
            double s09 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S10");
            double s10 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S11");
            double s11 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S12");
            double s12 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S13");
            double s13 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S14");
            double s14 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S15");
            double s15 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S16");
            double s16 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S17");
            double s17 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S18");
            double s18 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S19");
            double s19 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S20");
            double s20 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S21");
            double s21 = service.Score /100.0;
            service = outputs.services.SingleOrDefault(item => item.serviceID == "S22");
            double s22 = service.Score /100.0;

            double ConnectionToNatureDomain = 2.431227 +
                           0.577159 * s15 +             // CommunityAndFaithBasedInitiatives +
                           (-1.755944) * s13 +          // Activism +
                           (-0.370377) * s07 +          // ReDistribution +
                           0.465541 * s02 +             // Consumption +
                           (-0.111739) * s19 +          // Healthcare +
                           (-2.388524) * s17 +          // EmergencyPreparedness +
                           (-0.524012) * s10 +          // Greenspace +
                           0.05051 * s11 +              // WaterQuality +
                           (-1.934059) * s21 +          // Labor +
                           0.211648 * s16 +             // Education +
                           (-1.998989) * s15 * s17 +    // CommunityAndFaithBasedInitiatives * EmergencyPreparedness +
                           2.103267 * s13 * s17 +       // Activism * EmergencyPreparedness +
                           3.222831 * s17 * s21;        // EmergencyPreparedness * Labor;

            double CulturalFulfillmentDomain = -0.22391 +
                                        2.429595 * s15 +            // CommunityAndFaithBasedInitiatives +
                                        (-0.100712) * s08 +         // AirQuality +
                                        (-0.131353) * s12 +         // WaterQuantity +
                                        0.084694 * s17 +            // EmergencyPreparedness +
                                        0.191835 * s16 +            // Education +
                                        0.09992 * s05 +             // Innovation +
                                        1.280481 * s14 +            // Communication +
                                        (-0.097182) * s06 +         // Production +
                                        (-4.405586) * s15 * s14 +   // CommunityAndFaithBasedInitiatives * Communication +
                                        0.23472 * s15 * s08;        // CommunityAndFaithBasedInitiatives * AirQuality;

           double EducationDomain = 0.392837 +
                              0.350783 * s18 +      // FamilyServices +
                              0.463786 * s15 +      // CommunityAndFaithBasedInitiatives +
                              (-0.48866) * s06 +    // Production +
                              0.078233 * s22 +      // PublicWorks +
                              (-0.441537) * s20 +   // Justice +
                              0.574752 * s13 +      // Activism +
                              (-0.37372) * s02 +    // Consumption +
                              0.390576 * s07 * s10; // ReDistribution * Greenspace;

            double HealthDomain = 0.231086 +
                            0.072714 * s18 +            // FamilyServices +
                            0.194939 * s14 +            // Communication +
                            0.097708 * s21 +            // Labor +
                            0.020422 * s12 +            // WaterQuantity +
                            0.095983 * s05 +            // Innovation +
                            0.04914 * s17 +             // EmergencyPreparedness +
                            0.52497 * s15 +             // CommunityAndFaithBasedInitiatives +
                            0.149127 * s20 +            // Justice +
                            0.050258 * s13 * s16 +      // Activism * Education +
                            (-0.866259) * s15 * s20;    // CommunityAndFaithBasedInitiatives * Justice;

            double LeisureTimeDomain = 0.506212 +
                                (-0.340958) * s03 +         // Employment +
                                (-0.719677) * s12 +         // WaterQuantity +
                                (-0.39237) * s02 +          // Consumption +
                                0.682084 * s09 +            // FoodFiberAndFuelProvisioning +
                                (-0.053742) * s11 +         // WaterQuality +
                                0.138196 * s10 +            // Greenspace +
                                (-0.544925) * s16 +         // Education +
                                0.577271 * s22 +            // PublicWorks +
                                (-0.217388) * s15 +         // CommunityAndFaithBasedInitiatives +
                                0.934746 * s13 +            // Activism +
                                1.599972 * s12 * s16 +      // WaterQuantity * Education +
                                0.206249 * s04 * s14 +      // Finance * Communication +
                                (-1.29474) * s22 * s13 +    // PublicWorks * Activism +
                                (-0.171528) * s16 * s05;    // Education * Innovation;

            double LivingStandardsDomain = 0.275027 +
                                    0.092259 * s03 +            // Employment +
                                    (-0.146247) * s22 +         // PublicWorks +
                                    0.134713 * s21 +            // Labor +
                                    0.367559 * s13 +            // Activism +
                                    (-0.259411) * s04 +         // Finance +
                                    (-0.17859) * s20 +          // Justice +
                                    0.078427 * s12 +            // WaterQuantity +
                                    (-0.024932) * s01 +         // CapitalInvestment +
                                    0.708609 * s22 * s04 +      // PublicWorks * Finance +
                                    (-0.038308) * s01 * s12 +   // CapitalInvestment * WaterQuality +
                                    0.177212 * s09 * s14;       // FoodFiberAndFuelProvisioning * Communication;

            double SafetyAndSecurityDomain = 0.603914 +
                                      0.294092 * s15 +          // CommunityAndFaithBasedInitiatives +
                                      (-0.380562) * s11 +       // WaterQuality +
                                      (-0.385317) * s22 +       // PublicWorks +
                                      0.085398 * s12 +          // WaterQuantity +
                                      1.35322 * s13 * s21 +     // Activism * Labor +
                                      (-0.304328) * s06 * s19 + // Production * Healthcare +
                                      (-1.147411) * s21 * s20 + // Labor * Justice +
                                      0.295058 * s06 * s09 +    // Production * FoodFiberAndFuelProvisioning +
                                      (-0.742299) * s10 * s17 + // Greenspace * EmergencyPreparedness +
                                      (-0.602264) * s13 * s04 + // Activism * Finance +
                                      0.898598 * s20 * s17 +    // Justice * EmergencyPreparedness +
                                      0.574027 * s22 * s04 +    // PublicWorks * Finance +
                                      0.655645 * s11 * s22;     // WaterQuality * PublicWorks;

            double SocialCohesionDomain = -0.810156 +
                                   1.07278 * s20 +              // Justice +
                                   0.042486 * s08 +             // AirQuality +
                                   (-0.382991) * s06 +          // Production +
                                   1.980596 * s15 +             // CommunityAndFaithBasedInitiatives +
                                   0.047261 * s22 +             // PublicWorks +
                                   1.282272 * s07 +             // ReDistribution +
                                   0.100406 * s01 +             // CapitalInvestment +
                                   0.152944 * s18 +             // FamilyServices +
                                   0.120707 * s21 +             // Labor +
                                   1.291316 * s10 +             // Greenspace +
                                   (-0.148073) * s02 +          // Consumption +
                                   (-3.59425) * s15 * s07 +     // CommunityAndFaithBasedInitiatives * ReDistribution +
                                   (-2.048002) * s20 * s10 +    // Justice * Greenspace +
                                   (-0.036457) * s03 * s11;     // Employment * WaterQuality;

            Domain domain = null;
            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Connection");            
            domain.weight = ConnectionToNatureDomainWeight;
            domain.score = ConnectionToNatureDomain *100;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Culture");
            domain.weight = CulturalFulfillmentDomainWeight;
            domain.score = CulturalFulfillmentDomain * 100;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Education");
            domain.weight = EducationDomainWeight;
            domain.score = EducationDomain * 100;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Health");
            domain.weight = HealthDomainWeight;
            domain.score = HealthDomain * 100;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Leisure");
            domain.weight = LeisureTimeDomainWeight;
            domain.score = LeisureTimeDomain * 100;;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Living");
            domain.weight = LivingStandardsDomainWeight;
            domain.score = LivingStandardsDomain * 100;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Safety");
            domain.weight = SafetyAndSecurityDomainWeight;
            domain.score = SafetyAndSecurityDomain * 100;;

            domain = outputs.domains.SingleOrDefault(item => item.domainID == "Social");
            domain.weight = SocialCohesionDomainWeight;
            domain.score = SocialCohesionDomain * 100;

        }
        public void CalculateHWBI(double ConnectionToNatureDomainWeight, double CulturalFulfillmentDomainWeight, double EducationDomainWeight,
                              double HealthDomainWeight, double LeisureTimeDomainWeight, double LivingStandardsDomainWeight,
                              double SafetyAndSecurityDomainWeight, double SocialCohesionDomainWeight)
        {
            CalculateDomainScores(ConnectionToNatureDomainWeight, CulturalFulfillmentDomainWeight, EducationDomainWeight, HealthDomainWeight,
                           LeisureTimeDomainWeight, LivingStandardsDomainWeight, SafetyAndSecurityDomainWeight, SocialCohesionDomainWeight);

            double total_wt = 0;
            foreach (Domain domain in  outputs.domains)
            {
                total_wt += domain.weight;
            }
            //double hwbi = 0;
            outputs.hwbi = 0.0;
            foreach (Domain domain in  outputs.domains)
            {
                outputs.hwbi += domain.score * domain.weight / total_wt;
            }

            //HWBi.Score = hwbi;
            //results.hwbi.Score = hwbi;
        }

        protected void ValidateServiceScores(double CapitalInvestment_Score, double Consumption_Score, double Employment_Score, double Finance_Score, double Innovation_Score,
                         double Production_Score, double ReDistribution_Score, double AirQuality_Score, double FoodFiberAndFuelProvisioning_Score,
                         double Greenspace_Score, double WaterQuality_Score, double WaterQuantity_Score, double Activism_Score, double Communication_Score,
                         double CommunityAndFaithBasedInitiatives_Score, double Education_Score, double EmergencyPreparedness_Score, double FamilyServices_Score,
                         double Healthcare_Score, double Justice_Score, double Labor_Score, double PublicWorks_Score, out string errorMsg)
        {
            errorMsg = "";
            if ((CapitalInvestment_Score < 56.31683197) || (CapitalInvestment_Score > 61.75389692))
            {
                errorMsg = errorMsg + "CapitalInvestmentScore must be between 56.31683197 and 61.75389692 ";
            }
            if ((Consumption_Score < 47.42882423) || (Consumption_Score > 54.04916975))
            {
                errorMsg = errorMsg + "ConsumptionScore must be between 47.42882423 and 54.04916975 ";
            }
            if ((Employment_Score < 33.13814798) || (Employment_Score > 72.57176231))
            {
                errorMsg = errorMsg + "EmploymentScore must be between 33.13814798 and 72.57176231 ";
            }
            if ((Finance_Score < 31.42250002) || (Finance_Score > 61.56578545))
            {
                errorMsg = errorMsg + "FinanceScore must be between 31.42250002 and 61.56578545 ";
            }
            if ((Innovation_Score < 25.89488723) || (Innovation_Score > 65.3289721))
            {
                errorMsg = errorMsg + "InnovationScore must be between 25.89488723 and 65.3289721 ";
            }
            if ((Production_Score < 45.11697104) || (Production_Score > 51.67193166))
            {
                errorMsg = errorMsg + "ProductionScore must be between 45.11697104 and 51.67193166 ";
            }
            if ((ReDistribution_Score < 23.51316313) || (ReDistribution_Score > 68.92691912))
            {
                errorMsg = errorMsg + "ReDistributionScore must be between 23.51316313 and 68.92691912 ";
            }
            if ((AirQuality_Score < 10) || (AirQuality_Score > 90))
            {
                errorMsg = errorMsg + "AirQualityScore must be between 10 and 90 ";
            }
            if ((FoodFiberAndFuelProvisioning_Score < 32.62908483) || (FoodFiberAndFuelProvisioning_Score > 48.49178319))
            {
                errorMsg = errorMsg + "FoodFiberAndFuelProvisioningScore must be between 32.62908483 and 48.49178319 ";
            }
            if ((Greenspace_Score < 36.11207908) || (Greenspace_Score > 62.03906984))
            {
                errorMsg = errorMsg + "GreenspaceScore must be between 36.11207908 and 62.03906984 ";
            }
            if ((WaterQuality_Score < 15.95637509) || (WaterQuality_Score > 88.22033237))
            {
                errorMsg = errorMsg + "WaterQualityScore must be between 15.95637509 and 88.22033237 ";
            }
            if ((WaterQuantity_Score < 21.70976841) || (WaterQuantity_Score > 72.834479987))
            {
                errorMsg = errorMsg + "WaterQuantityScore must be between 21.70976841 and 72.83447998 ";
            }
            if ((Activism_Score < 25.85945275) || (Activism_Score > 73.66346154))
            {
                errorMsg = errorMsg + "ActivismScore must be between 25.85945275 and 73.66346154 ";
            }
            if ((Communication_Score < 33.10020486) || (Communication_Score > 68.98955269))
            {
                errorMsg = errorMsg + "CommunicationScore must be between 33.10020486 and 68.98955269 ";
            }
            if ((CommunityAndFaithBasedInitiatives_Score < 12.21375305) || (CommunityAndFaithBasedInitiatives_Score > 90))
            {
                errorMsg = errorMsg + "CommunityAndFaithBasedInitiativesScore must be between 12.21375305 and 90 ";
            }
            if ((Education_Score < 12.21375305) || (Education_Score > 56.47803694))
            {
                errorMsg = errorMsg + "EducationScore must be between 33.24429069 and 56.47803694 ";
            }
            if ((EmergencyPreparedness_Score < 19.78920564) || (EmergencyPreparedness_Score > 76.07510118))
            {
                errorMsg = errorMsg + "EmergencyPreparednessScore must be between 19.78920564 and 76.07510118 ";
            }
            if ((FamilyServices_Score < 42.66833596) || (FamilyServices_Score > 73.35259094))
            {
                errorMsg = errorMsg + "FamilyServicesScore must be between 42.66833596 and 73.35259094 ";
            }
            if ((Healthcare_Score < 29.63020433) || (Healthcare_Score > 62.25876617))
            {
                errorMsg = errorMsg + "HealthcareScore must be between 29.63020433 and 62.25876617 ";
            }
            if ((Justice_Score < 31.22560175) || (Justice_Score > 71.78167536))
            {
                errorMsg = errorMsg + "JusticeScore must be between 31.22560175 and 71.78167536 ";
            }
            if ((Labor_Score < 36.52332879) || (Labor_Score > 53.29715035))
            {
                errorMsg = errorMsg + "LaborScore must be between 36.52332879 and 53.29715035 ";
            }
            if ((PublicWorks_Score < 33.53645478) || (PublicWorks_Score > 66.4893089))
            {
                errorMsg = errorMsg + "PublicWorksScore must be between 33.53645478 and 66.4893089 ";
            }
        }
        protected void validateDomainWeights(double ConnectionToNatureDomain_Weight, double CulturalFulfillmentDomain_Weight, double EducationDomain_Weight, double HealthDomain_Weight,
                         double LeisureTimeDomain_Weight, double LivingStandardsDomain_Weight, double SafetyAndSecurityDomain_Weight, double SocialCohesionDomain_Weight, out string errorMsg)
        {
            errorMsg = "";
            if ((ConnectionToNatureDomain_Weight < 1) || (ConnectionToNatureDomain_Weight > 10))
            {
                errorMsg = errorMsg + "ConnectionToNatureDomainWeight must be between 1 and 10";
            }
            if ((CulturalFulfillmentDomain_Weight < 1) || (CulturalFulfillmentDomain_Weight > 10))
            {
                errorMsg = errorMsg + "CulturalFulfillmentDomainWeight must be between 1 and 10";
            }
            if ((EducationDomain_Weight < 1) || (EducationDomain_Weight > 10))
            {
                errorMsg = errorMsg + "EducationDomainWeight must be between 1 and 10";
            }
            if ((HealthDomain_Weight < 1) || (HealthDomain_Weight > 10))
            {
                errorMsg = errorMsg + "HealthDomainWeight must be between 1 and 10";
            }
            if ((LeisureTimeDomain_Weight < 1) || (LeisureTimeDomain_Weight > 10))
            {
                errorMsg = errorMsg + "LeisureTimeDomainWeight must be between 1 and 10";
            }
            if ((LivingStandardsDomain_Weight < 1) || (LivingStandardsDomain_Weight > 10))
            {
                errorMsg = errorMsg + "LivingStandardsDomainWeight must be between 1 and 10";
            }
            if ((SafetyAndSecurityDomain_Weight < 1) || (SafetyAndSecurityDomain_Weight > 10))
            {
                errorMsg = errorMsg + "SafetyAndSecurityDomainWeight must be between 1 and 10";
            }
            if ((SocialCohesionDomain_Weight < 1) || (SocialCohesionDomain_Weight > 10))
            {
                errorMsg = errorMsg + "SocialCohesionDomainWeight must be between 1 and 10";
            }
        }

        private List<MetaBase> BuildParameterList(HWBICalcScore calc)
        {
            //List<Parameter> list = new List<Parameter>();
            List<MetaBase> list = new List<MetaBase>();
            PropertyInfo[] props =  calc.scores.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                MetaBase mb = new MetaBase(pi.Name, pi.GetValue(calc.scores).ToString(), "");                
                list.Add(mb);
            }

            props = calc.domainWeights.GetType().GetProperties();
            foreach (PropertyInfo pi in props)
            {
                MetaBase mb = new MetaBase(pi.Name, pi.GetValue(calc.domainWeights).ToString(), "");
                list.Add(mb);
            }

            return list;
        }
    }
}