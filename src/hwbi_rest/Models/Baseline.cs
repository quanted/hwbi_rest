using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Data;

namespace hwbi_rest.Models
{
    public class Baseline
    {
        public double CapitalInvestment { get; set; }
        public double Consumption { get; set; }
        public double Employment { get; set; }
        public double Finance { get; set; }
        public double Innovation { get; set; }
        public double Production { get; set; }
        public double ReDistribution { get; set; }
        public double AirQuality { get; set; }
        public double FoodFiberandFuelProvisioning { get; set; }
        public double Greenspace { get; set; }
        public double WaterQuality { get; set; }
        public double WaterQuantity { get; set; }
        public double Activism { get; set; }
        public double Communication { get; set; }
        public double CommunityandFaithBasedInitiatives { get; set; }
        public double Education { get; set; }
        public double EmergencyPreparedness { get; set; }
        public double FamilyServices { get; set; }
        public double Healthcare { get; set; }
        public double Justice { get; set; }
        public double Labor { get; set; }
        public double PublicWorks { get; set; }
        //public Baseline(string state, string county)
        //{
        //    string errorMsg = "";
        //    DB db = new DB();
        //    DataTable dt = db.getBaselineServiceScoresFromDB(state, county, out errorMsg);
        //    if (errorMsg != "")
        //    {

        //    }
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        string serviceName = dr["ServiceName"].ToString();
        //        double score = Convert.ToDouble(dr["Score"].ToString());
        //        serviceName = serviceName.Replace(",", "");
        //        serviceName = serviceName.Replace(" ", "");
        //        serviceName = serviceName.Replace("-", "");
        //        switch (serviceName)
        //        {
        //            case "CapitalInvestment":
        //                CapitalInvestment = score;
        //                break;
        //            case "Consumption":
        //                Consumption = score;
        //                break;
        //            case "Employment":
        //                Employment = score;
        //                break;
        //            case "Finance":
        //                Finance = score;
        //                break;
        //            case "Innovation":
        //                Innovation = score;
        //                break;
        //            case "Production":
        //                Production = score;
        //                break;
        //            case "ReDistribution":
        //                ReDistribution = score;
        //                break;
        //            case "AirQuality":
        //                AirQuality = score;
        //                break;
        //            case "FoodFiberAndFuelProvisioning":
        //                FoodFiberandFuelProvisioning = score;
        //                break;
        //            case "Greenspace":
        //                Greenspace = score;
        //                break;
        //            case "WaterQuality":
        //                WaterQuality = score;
        //                break;
        //            case "WaterQuantity":
        //                WaterQuantity = score;
        //                break;
        //            case "Activism":
        //                Activism = score;
        //                break;
        //            case "Communication":
        //                Communication = score;
        //                break;
        //            case "CommunityAndFaithBasedInitiatives":
        //                CommunityandFaithBasedInitiatives = score;
        //                break;
        //            case "Education":
        //                Education = score;
        //                break;
        //            case "EmergencyPreparedness":
        //                EmergencyPreparedness = score;
        //                break;
        //            case "FamilyServices":
        //                FamilyServices = score;
        //                break;
        //            case "Healthcare":
        //                Healthcare = score;
        //                break;
        //            case "Justice":
        //                Justice = score;
        //                break;
        //            case "Labor":
        //                Labor = score;
        //                break;
        //            case "PublicWorks":
        //                PublicWorks = score;
        //                break;
        //            default:
        //                throw new System.Exception("Unknown Service");
        //        }
        //    }
        //}
        
    }
}