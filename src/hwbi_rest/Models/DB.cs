using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Microsoft.Data.Sqlite;


namespace hwbi_rest.Models
{
    public class DB
    {
        //protected string connectionString = @"Server = LZ2626UAIGNATIU\SQLEXPRESS2008R2; Database = HWBI; Trusted_Connection = True;";
        //protected string connectionString = @"Server = LZ2626URPARMAR\SQLEXPRESS2008R2; Database = HWBI; Trusted_Connection = True;";
        protected string connectionString = @"";
        public string getConnectionString()
        {
            return connectionString;
        }
        //protected DataTable runSelectQuery(string query, out string errorMsg)
        //{
        //    errorMsg = "";
        //    DataTable dt = null;
        //    try
        //    {
        //        SqliteMgr sqlMgr = new SqliteMgr();
        //        dt =sqlMgr.ExecuteQuery(query);
        //        return dt;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        errorMsg = ex.Message;
        //    }
        //    return dt;
        //}
        //public DataTable getBaselineServiceScoresFromDB(string state, string county, out string errorMsg)
        //{
        //    errorMsg = "";
        //    string stateUpper = state.ToUpper();
        //    string countyUpper = county.ToUpper();
        //    string query = @"Select SSB.county_FIPS, CO.stateID, ST.[State], CO.county, SSB.ServiceID, SVC.ServiceName, SSB.Score, SVC.description, SVT.serviceType " +
        //                     "From ServiceScores_Baseline SSB, Counties CO, [Services] SVC, States ST, ServiceTypes SVT " +
        //                     "Where SSB.county_FIPS=CO.county_FIPS and " +
        //                     "UPPER(ST.State)='" + stateUpper + "' and UPPER(CO.county)='" + countyUpper + "' and SSB.serviceID=SVC.serviceID and CO.stateID=ST.stateID and " +
        //                     "SVC.ServiceTypeID=SVT.ServiceTypeID";
        //    DataTable dt = runSelectQuery(query, out errorMsg);
        //    return dt;
        //}

    }
}