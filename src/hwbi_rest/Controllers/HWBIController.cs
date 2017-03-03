using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.PlatformAbstractions;
using hwbi_rest.Models;

namespace hwbi_rest.Controllers
{
    //[RoutePrefix("api")]
    [Route("rest")]
    public class HWBIController : Controller
    {
        //[Route("hwbi")]
        [HttpGet]
        public Models.HWBI GetHWBI()
        {
            ////SetBaseUrl(this.Request);
            Models.HWBI hwbi = new Models.HWBI();
            //string absPath = this.Request.RequestUri.AbsolutePath;
            return hwbi;
        }

        [Route("calc")]
        [HttpGet]
        public HWBICalc GetCalc()
        {
            //SetBaseUrl(this.Request);
            HWBICalc calc = new HWBICalc();
            return calc;
        }

        [Route("calc/inputs")]
        [HttpGet]
        public Models.CalcInputs GetCalcInputs()
        {
            //SetBaseUrl(this.Request);
            CalcInputs calcInputs = new CalcInputs();      
            return calcInputs;
        }

        [Route("calc/outputs")]
        [HttpGet]
        public CalcOutputs GetCalcOutputs()
        {
            //SetBaseUrl(this.Request);
            CalcOutputs calcOutputs = new CalcOutputs();
            return calcOutputs;
        }

        [Route("calc/run")]
        [HttpGet]
        public CalcRun GetCalcRun()
        {
            //SetBaseUrl(this.Request);
            CalcRun calcRun = new CalcRun();
            return calcRun;
        }

        [Route("calc/run")]
        [HttpPost]
        public HWBIScore PostCalcRun([FromBody]HWBICalcScore calcScore)
        {
            //SetBaseUrl(this.Request);
            HWBIScore score = new HWBIScore(calcScore);           
            return score;
        }

        [Route("locations")]
        [HttpGet]
        public Models.HWBILocations GetLocations()
        {
            //SetBaseUrl(this.Request);
            Models.HWBILocations locations = new Models.HWBILocations();
            return locations;
        }

        [Route("locations/inputs")]
        [HttpGet]
        public Models.LocationInputs GetLocationsInputs()
        {
            //SetBaseUrl(this.Request);
            Models.LocationInputs li = new Models.LocationInputs();
            return li;
        }

        [Route("locations/outputs")]
        [HttpGet]
        public Models.LocationOutputs GetLocationsOutputs()
        {
            //SetBaseUrl(this.Request);
            Models.LocationOutputs lo = new Models.LocationOutputs();
            return lo;
        }

        [Route("locations/run")]
        [HttpGet]
        public Models.LocationRun GetLocationsRun()
        {
            //SetBaseUrl(this.Request);
            Models.LocationRun lr = new Models.LocationRun();
            return lr;
        }

        [Route("locations/run")]
        [HttpPost]
        public Models.HWBIScore PostLocationsRun([FromBody]Location location)
        {
            Microsoft.Extensions.PlatformAbstractions.ApplicationEnvironment appEnv = new ApplicationEnvironment();
            string basePath = appEnv.ApplicationBasePath;
            string dbPath = System.IO.Path.Combine(basePath, "Data");

            string connStr = string.Format("Filename={0}hwbi.db; Mode=ReadOnly", dbPath);
            Models.HWBIScore hwbiScore = new Models.HWBIScore(location.state, location.county);
            return hwbiScore;
        }


        //private void SetBaseUrl(HttpRequestMessage reqMsg)
        //{
        //    string scheme = this.Request.RequestUri.Scheme;
        //    string host = this.Request.RequestUri.Host;
        //    int port = this.Request.RequestUri.Port;
        //    UriBuilder uriBldr = new UriBuilder(scheme, host, port);
        //    Common.baseUrl = uriBldr.ToString();
        //}



        // GET: rest/hwbi
        //[Route("hwbi")]
        //Provides usage information for this endpoint
        //[Route("calc")]
        //[HttpGet]
        //public System.Web.Mvc.ActionResult Get()
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
        //    string sval = @"[""HWBI REST API / calculator endpoint"" ";
        //    sb.Append(sval);

        //    sval = "GET request URL example:";
        //    sb.Append(sval);

        //    sval = @"https://qed.epa.gov/rest/hwbi/calc?";
        //    sb.Append(sval);


        //     sval = @"CapitalInvestmentScore=58.9&" +
        //                  "ConsumptionScore=51.6&EmploymentScore=52.30000000&FinanceScore=44.0&InnovationScore=43.24&" +
        //                  "ProductionScore=50.44&ReDistributionScore=47.2&AirQualityScore=19.2&FoodFiberAndFuelProvisioningScore=44.44&" +
        //                  "GreenspaceScore=42.6&WaterQualityScore=67.4&WaterQuantityScore=37.9&ActivismScore=48.9&" +
        //                  "CommunicationScore=43.4&CommunityAndFaithBasedInitiativesScore=15.81&EducationScore=45.0&" +
        //                  "EmergencyPreparednessScore=52.6&FamilyServicesScore=50.0&HealthcareScore=48.7&JusticeScore=42.76&" +
        //                  "LaborScore=40.82&PublicWorksScore=41.84&ConnectionToNatureDomainWeight=1.0&" +
        //                  "CulturalFulfillmentDomainWeight=2.0&EducationDomainWeight=1.0&HealthDomainWeight=1.0&" +
        //                  "LeisureTimeDomainWeight=1.0&LivingStandardsDomainWeight=1.0&SafetyAndSecurityDomainWeight=1.0&" +
        //                  "SocialCohesionDomainWeight=1.0";
        //    sb.Append(sval);
        //    sb.Append("              ");

        //    sval = @" POST request body example: { ""scores"" : { ""CapitalInvestment"":58.9, ""Consumption"":51.6, ""Employment"":52.3, ""Finance"" : 44.0, ""Innovation"" : 43.24, ""Production"" : 50.44, ""ReDistribution"" : 47.2, ""AirQuality"" : 40.0, ""FoodFiberAndFuel"" : 44.44, ""Greenspace"" : 42.6, ""WaterQuality"" : 67.4, ""WaterQuantity"" : 37.9, ""Activism"" : 48.9, ""Communication"" : 43.4, ""CommunityAndFaith"" : 15.81, ""Education"" : 45.0, ""EmergencyPreparedness"" : 52.6, ""FamilyServices"" : 50.0, ""Healthcare"": 48.7, ""Justice"" : 42.76, ""Labor"" :40.82, ""PublicWorks"" :41.84 }, ""domainWeights"" : { ""ConnectionToNature"":1.0, ""CulturalFulfillment"":1.0, ""Education"":1.0, ""Health"":1.0, ""LeisureTime"":1.0, ""LivingStandards"":1.0, ""SafetyAndSecurity"":1.0, ""SocialCohesion"":1.0 } }";

        //    sb.Append(sval);
        //    sb.Append("]");
        //    System.Web.Mvc.ContentResult cr = new System.Web.Mvc.ContentResult();
        //    cr.Content = sb.ToString();
        //    return cr;
        //}



        //GET: http://localhost:64399/api/HWBI?CapitalInvestmentScore=58.9&ConsumptionScore=51.6&EmploymentScore=52.3&FinanceScore=44.0&InnovationScore=43.24&ProductionScore=50.44&ReDistributionScore=47.2&AirQualityScore=0.9&FoodFiberAndFuelProvisioningScore=44.44&GreenspaceScore=42.6&WaterQualityScore=67.4&WaterQuantityScore=37.9&ActivismScore=48.9&CommunicationScore=43.4&CommunityAndFaithBasedInitiativesScore=15.81&EducationScore=45.0&EmergencyPreparednessScore=52.6&FamilyServicesScore=50.0&HealthcareScore=48.7&JusticeScore=42.76&LaborScore=40.82&PublicWorksScore=41.84&ConnectionToNatureDomainWeight=1.0&CulturalFulfillmentDomainWeight=1.0&EducationDomainWeight=1.0&HealthDomainWeight=1.0&LeisureTimeDomainWeight=1.0&LivingStandardsDomainWeight=1.0&SafetyAndSecurityDomainWeight=1.0&SocialCohesionDomainWeight=1.0
        //[Route("hwbi")]
        //[Route("calc")]
        //[HttpGet]
        //public Models.HWBIScore Get(double CapitalInvestmentScore, double ConsumptionScore, double EmploymentScore, double FinanceScore, double InnovationScore, double ProductionScore,
        //                  double ReDistributionScore, double AirQualityScore, double FoodFiberAndFuelProvisioningScore, double GreenspaceScore, double WaterQualityScore,
        //                  double WaterQuantityScore, double ActivismScore, double CommunicationScore, double CommunityAndFaithBasedInitiativesScore, double EducationScore,
        //                  double EmergencyPreparednessScore, double FamilyServicesScore, double HealthcareScore, double JusticeScore,
        //                  double LaborScore, double PublicWorksScore, double ConnectionToNatureDomainWeight, double CulturalFulfillmentDomainWeight,
        //                  double EducationDomainWeight, double HealthDomainWeight, double LeisureTimeDomainWeight, double LivingStandardsDomainWeight,
        //                  double SafetyAndSecurityDomainWeight, double SocialCohesionDomainWeight)
        //{
        //    Models.HWBIScore hwbi = new Models.HWBIScore(CapitalInvestmentScore, ConsumptionScore, EmploymentScore, FinanceScore, InnovationScore,
        //                                     ProductionScore, ReDistributionScore, AirQualityScore, FoodFiberAndFuelProvisioningScore,
        //                                     GreenspaceScore, WaterQualityScore, WaterQuantityScore, ActivismScore, CommunicationScore,
        //                                     CommunityAndFaithBasedInitiativesScore, EducationScore, EmergencyPreparednessScore, FamilyServicesScore,
        //                                     HealthcareScore, JusticeScore, LaborScore, PublicWorksScore,
        //                                     ConnectionToNatureDomainWeight, CulturalFulfillmentDomainWeight, EducationDomainWeight, HealthDomainWeight,
        //                                     LeisureTimeDomainWeight, LivingStandardsDomainWeight, SafetyAndSecurityDomainWeight, SocialCohesionDomainWeight);
        //    return hwbi;
        //}

        //[Route("calc")]
        //[HttpPost]
        //public Models.HWBIScore Post(HWBICalcScore calc)
        //{
        //    //Scores scores = calc.scores;
        //    //DomainWeights weights = calc.domainWeights;
        //    HWBIScore hwbi = new HWBIScore(calc);            

        //    //hwbi.metaInfo.url = this.Request.RequestUri.ToString();
        //    return hwbi;
        //}

        //// PUT: api/HWBI/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/HWBI/5
        //public void Delete(int id)
        //{
        //}
    }
}
