using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;


namespace hwbi_rest.Models
{
    public class HWBICalculator
    {
        public HWBICalculator()
        {
        }
        //public static double getHWBI(double S01, double S02, double S03, double S04, double S05, double S06, double S07, double S08, double S09, double S10,
        //                             double S11, double S12, double S13, double S14, double S15, double S16, double S17, double S18, double S19, double S20,
        //                             double S21, double S22, double connectionDomainWt, double cultureDomainWt, double educationDomainWt, double healthDomainWt,
        //                             double leisureDomainWt, double livingDomainWt, double safetyDomainWt, double socialDomainWt,
        //                             out double connectionDomainScore, out double cultureDomainScore, out double educationDomainScore, out double healthDomainScore,
        //                             out double leisureDomainScore, out double livingDomainScore, out double safetyDomainScore, out double socailDomainScore,
        //                             out string errorMsg)
        //{
        //    errorMsg = "";
        //    connectionDomainScore = 0;
        //    cultureDomainScore = 0;
        //    educationDomainScore = 0;
        //    healthDomainScore = 0;
        //    leisureDomainScore = 0;
        //    livingDomainScore = 0;
        //    safetyDomainScore = 0;
        //    socailDomainScore = 0;

        //    double hwbiScore = 0;

        //    double connectionIntercept = Convert.ToDouble(HttpContext.Current.Application[Common.ConnectionDomainIntercept].ToString());
        //    SortedList slConnectionCoeffs = (SortedList)HttpContext.Current.Application[Common.ConnectionDomainCoeffs];
        //    for (int i=0; i < slConnectionCoeffs.Count; i++)
        //    {

        //    }
        //    return hwbiScore;
        //}
    }
}