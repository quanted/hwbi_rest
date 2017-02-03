using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace hwbi_rest.Controllers
{
    [Route("api")]
    public class BaselineServiceScoresController : Controller
    {
        [Route("baselineservicescores")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("baselineservicescores")]
        [HttpGet]
        public string Get(string State, string County)
        {
            return State + " " + County;
        }

        // POST: api/BaselineServiceScores
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BaselineServiceScores/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BaselineServiceScores/5
        public void Delete(int id)
        {
        }
    }
}
