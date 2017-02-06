﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace hwbi_rest.Models
{
    public class HWBI
    {
        public MetaInfo metaInfo { get; set; }
        public List<Link> links { get; set; }

        public HWBI()
        {
            metaInfo = new MetaInfo();
            metaInfo.model = "hwbi";
            metaInfo.collection = "qed";
            metaInfo.modelVersion = 1.0;
            metaInfo.description = "The Human Well-Being Index (HWBI) was generated by researchers at the U.S. Environmental Protection Agency using over one hundred nationally-available data layers to assess economic, social, and ecosystem services and calculate human well-being across the entire U.S. at the regional, state, and county levels for years 2000-2010.";
            metaInfo.status = "";
            metaInfo.timestamp = Common.GetTimeStamp();
            metaInfo.url.type = @"application/json";
            metaInfo.url.href = new UriBuilder(Common.baseUrl + @"rest/hwbi").ToString();

            links = new List<Link>();
            Link link = new Link();
            link.rel = "calc";
            link.type = "application/json";
            link.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/calc").ToString();
            links.Add(link);

            Link link2 = new Link();
            link2.rel = "locations";
            link2.type = "application/json";
            link2.href = new UriBuilder(Common.baseUrl + @"rest/hwbi/locations").ToString();
            links.Add(link2);

            Link link3 = new Link();
            link3.rel = "html";
            link3.type = "text/html";
            link3.href = new UriBuilder(Common.baseUrl + @"ubertool/hwbi").ToString();
            links.Add(link3);


        }
    }
}