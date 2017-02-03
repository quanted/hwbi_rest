using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace hwbi_rest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            SqliteConnection connection = new SqliteConnection("Data Source=hwbi.db");
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT state FROM States";
            List<string> stuff = new List<string>();
            try
            {
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var message = reader.GetString(0);
                    stuff.Add(message);
                    Console.WriteLine(message);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return stuff[id].ToString();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
