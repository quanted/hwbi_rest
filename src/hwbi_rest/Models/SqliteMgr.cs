using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.Extensions.PlatformAbstractions;
using hwbi_rest.Models.Database;
using Microsoft.Data.Sqlite;
using PetaPoco;

namespace hwbi_rest.Models
{
    public class SqliteMgr
    {

        string _dbFile = "";
        private static string connectionString = "Filename=./hwbi.db; Mode=ReadOnly";

        public SqliteMgr()
        {
         
        }

                

        /// <summary>
        /// Returns the list of tables in opened database.
        /// </summary>
        /// <returns></returns>
        //public static List<string> GetTables()
        //{
        //    //SqliteConnection connection = new SqliteConnection("Filename=./hwbi.db; Mode=ReadOnly");
        //    //// executes query that select names of all tables in master table of the database
        //    //String query = "SELECT name FROM sqlite_master WHERE type = 'table' ORDER BY 1";
        //    //DataTable table = ExecuteQuery(query);

        //    //// Return all table names in the ArrayList
        //    //List<string> list = new List<string>();
        //    //foreach (DataRow row in table.Rows)
        //    //{
        //    //    list.Add(row.ItemArray[0].ToString());
        //    //}
        //    //return list;
        //}

        public static List<Service> GetAllServices()
        {            
            List<Service> services = new List<Service>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "select * from Services";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Service svc = new Service();
                    svc.serviceID = reader.GetString(0);
                    svc.serviceTypeID = reader.GetString(1);
                    svc.serviceName = reader.GetString(2);
                    svc.serviceTypeName = reader.GetString(3);
                    svc.description = reader.GetString(4);
                    svc.name = reader.GetString(5);
                    svc.min = reader.GetInt32(6);
                    svc.max = reader.GetInt32(7);

                    services.Add(svc);
                }
            }

            return services;
                    //SqliteConnection connection = new SqliteConnection(connectionString);
                    //var db = new PetaPoco.NetCore.Database(connection);
                    //IEnumerable<Service> services = db.Query<Service>("select * from Services");
                    //return services;

        }

        public static List<Domain> GetAllDomains()
        {
            List<Domain> domains = new List<Domain>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "select * from Domains";
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Domain domain = new Domain();                    
                    domain.domainID = reader.GetString(0);
                    domain.domainName = reader.GetString(1);
                    domain.name = reader.GetString(2);
                    domain.min = reader.GetInt32(3);
                    domain.max = reader.GetInt32(4);

                    domains.Add(domain);
                }
            }

            return domains;
            //SqliteConnection connection = new SqliteConnection(connectionString);
            //var db = new PetaPoco.NetCore.Database(connection);
            //IEnumerable<Domain> domains = db.Query<Domain>("select * from Domains");
            //return domains;
        }

        //public static IEnumerable<BaselineServiceScore> GetBaselineServiceScores(string state, string county)
        //{
        //    string uState = state.ToUpper();
        //    string uCounty = county.ToUpper();
        //    string query = null;
        //    query = @"Select SSB.county_FIPS, CO.stateID, ST.[State], CO.county, SSB.ServiceID, SVC.ServiceName, SSB.Score, SVC.description, SVT.serviceType " +
        //         "From ServiceScores_Baseline SSB, Counties CO, [Services] SVC, States ST, ServiceTypes SVT " +
        //         "Where SSB.county_FIPS=CO.county_FIPS and UPPER(ST.State)='{0}' and UPPER(CO.county)='{1}' and SSB.serviceID=SVC.serviceID and CO.stateID=ST.stateID and SVC.ServiceTypeID=SVT.ServiceTypeID";

        //    query = string.Format(query, uState, uCounty);

        //    SqliteConnection connection = new SqliteConnection("Filename =./hwbi.db;");
        //    var db = new PetaPoco.NetCore.Database(connection);
        //    IEnumerable<BaselineServiceScore> services = db.Query<BaselineServiceScore>(query);
        //    return services;
        //}

        public static List<BaselineServiceScore> GetBaselineServiceScores(string state, string county)
        {
            string uState = state.ToUpper();
            string uCounty = county.ToUpper();
            string query = null;
            query = @"Select SSB.county_FIPS, CO.stateID, ST.[State], CO.county, SSB.ServiceID, SVC.ServiceName, SSB.Score, SVC.description, SVT.serviceType " +
                 "From ServiceScores_Baseline SSB, Counties CO, [Services] SVC, States ST, ServiceTypes SVT " +
                 "Where SSB.county_FIPS=CO.county_FIPS and UPPER(ST.stateID)='{0}' and UPPER(CO.county)='{1}' and SSB.serviceID=SVC.serviceID and CO.stateID=ST.stateID and SVC.ServiceTypeID=SVT.ServiceTypeID";

            query = string.Format(query, uState, uCounty);
            List<BaselineServiceScore> svcScores = new List<BaselineServiceScore>();

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = query;
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaselineServiceScore svcScore = new BaselineServiceScore();
                    svcScore.county_FIPS = reader.GetInt32(0);
                    svcScore.stateID = reader.GetString(1);
                    svcScore.state = reader.GetString(2);
                    svcScore.county = reader.GetString(3);
                    svcScore.serviceID = reader.GetString(4);
                    svcScore.serviceName = reader.GetString(5);
                    svcScore.score = reader.GetDouble(6);
                    svcScore.description = reader.GetString(7);
                    svcScore.serviceType = reader.GetString(8);
                    svcScores.Add(svcScore);
                }
                int fldCount = reader.FieldCount;
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string name = reader.GetName(i);
                    Type fldType = reader.GetFieldType(i);
                    Console.WriteLine("Column{0}  Name:{1}  Type{2}", i, name, fldType.ToString());
                }
                
            }

            return svcScores;

        }

            //public DataTable ExecuteQuery(string query)
            //{


            //    try
            //    {
            //        using (SqliteConnection connection = new SqliteConnection("Filename=./hwbi.db; Mode=ReadOnly"))
            //        { 
            //            connection.Open();
            //            var command = connection.CreateCommand();
            //            command.CommandText = query;
            //            List<string> colNames = new List<string>();
            //            using (var reader = command.ExecuteReader())
            //            {
            //                for (int i = 0; i < reader.FieldCount; i++)
            //                    colNames.Add(reader.GetName(i));

            //                while (reader.Read())
            //                {
            //                    int fldCount = reader.FieldCount;                            
            //                    var message = reader.GetString(0);
            //                    Console.WriteLine(message);
            //                }
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        var msg = ex.Message;
            //    }

            //    DataTable dt = new DataTable();
            //    try
            //    {
            //        SQLiteConnection conn;
            //        using (conn = new SQLiteConnection(string.Format("Data Source={0};Version=3;Pooling=True;Max Pool Size=100", _dbFile)))
            //        { 
            //            conn.Open();
            //            SQLiteCommand command = new SQLiteCommand(conn);
            //            command.CommandText = query;
            //            SQLiteDataReader reader = command.ExecuteReader();
            //            dt.Load(reader);
            //            //reader.Close();
            //            //conn.Close();
            //        }

            //    }
            //    catch (Exception e)
            //    {
            //        throw new Exception(e.Message);
            //    }
            //    return dt;

            //}



            /// <summary>
            ///     Allows the programmer to interact with the database for purposes other than a query.
            /// </summary>
            /// <param name="query">The SQL to be run.</param>
            /// <returns>An Integer containing the number of rows updated.</returns>

            public void ExecuteNonQuery(string query)
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            var db = new PetaPoco.NetCore.Database(connection);
            db.Execute(query);

            return;
        }


        /// <summary>
        ///     Allows the programmer to retrieve single items from the DB.
        /// </summary>
        /// <param name="sql">The query to run.</param>
        /// <returns>A string.</returns>
        public long ExecuteScalar(string query)
        {
            SqliteConnection connection = new SqliteConnection(connectionString);
            var db = new PetaPoco.NetCore.Database(connection);
            long retval = db.ExecuteScalar<long>(query);
            return retval;            
        }

    }
}
