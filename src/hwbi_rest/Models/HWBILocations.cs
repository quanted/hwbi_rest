using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class HWBILocations
    {
        public MetaInfo metaInfo { get; set; }

        public List<Link> links { get; set; }

        public HWBILocations()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = @"The Human Well-Being Index (HWBI) model locations endpoint uses state and county names to provide values for 22 economic, ecosystem, and social services, 8 domains of well-being, and a total HWBI score for the county.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations").ToString();

            links = new List<Link>();
            Link link = new Link();
            link.rel = "inputs";
            link.type = "application/json";
            link.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/inputs").ToString();
            links.Add(link);

            Link link2 = new Link();
            link2.rel = "outputs";
            link2.type = "application/json";
            link2.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/outputs").ToString();
            links.Add(link2);

            Link link3 = new Link();
            link3.rel = "run";
            link3.type = "application/json";
            link3.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations/run").ToString();
            links.Add(link3);

            Link link4 = new Link();
            link4.rel = "html";
            link4.type = "text/html";
            link4.href = "https://qed.epa.gov/ubertool/hwbi";
            links.Add(link4);
        }
    }
}