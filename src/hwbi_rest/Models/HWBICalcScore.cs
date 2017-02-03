using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class HWBICalcScore
    {
        public Scores scores { get; set; }
        public DomainWeights domainWeights { get; set; }
    }

    public class Scores
    {
        public Scores()
        {

        }
        public double capitalInvestment { get; set; }
        public double consumption { get; set; }
        public double employment { get; set; }
        public double finance { get; set; }
        public double innovation { get; set; }
        public double production { get; set; }
        public double redistribution { get; set; }
        public double airQuality { get; set; }
        public double foodFiberAndFuel { get; set; }
        public double greenspace { get; set; }
        public double waterQuality { get; set; }
        public double waterQuantity { get; set; }
        public double activism { get; set; }
        public double communication { get; set; }
        public double communityAndFaith { get; set; }
        public double education { get; set; }
        public double emergencyPreparedness { get; set; }
        public double familyServices { get; set; }
        public double healthcare { get; set; }
        public double justice { get; set; }
        public double labor { get; set; }
        public double publicWorks { get; set; }
    }

    public class DomainWeights
    {
        public DomainWeights()
        {

        }
        public double connectionToNature { get; set; }
        public double culturalFulfillment { get; set; }
        public double education { get; set; }
        public double health { get; set; }
        public double leisureTime { get; set; }
        public double livingStandards { get; set; }
        public double safetyAndSecurity { get; set; }
        public double socialCohesion { get; set; }
    }
}