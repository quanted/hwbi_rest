using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace hwbi_rest.Models
{
    public class Common
    {

        public static string baseUrl = "";

        public static string GetTimeStamp()
        {
            return DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
        }

    }

}