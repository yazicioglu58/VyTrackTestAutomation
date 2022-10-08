using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.DatabaseHelper;

namespace VyTrackTestAutomation.Utilities
{
    public class DatabaseManager
    {
        public ReportingData GetReportingDataTable(string query)
        {

            ReportingData report;

           query = "Select * from reportingdata";
          

            using (SqlConnection con = new SqlConnection("Data Source=SVRAZ08;Initial Catalog=SecurityDW;Integrated Security=True;"))
            {
                con.Open();
                 
                report = con.Query<ReportingData>(query).FirstOrDefault();
                
            }
            return report;
        }

        public List<ReportingData> GetReportingDataTableList(string query)
        {

           List<ReportingData> report;

            query = "Select * from reportingdata";

            using (SqlConnection con = new SqlConnection("/Server=serveradi,port;Database=databaseInAdi;user=username;pasword+pasword"))
            {
                con.Open();

                report = con.Query<ReportingData>(query).ToList();

            }
            return report;
        }
    }
}


//Server=serveradi,port;Database=databaseInAdi;user=username;pasword+pasword
