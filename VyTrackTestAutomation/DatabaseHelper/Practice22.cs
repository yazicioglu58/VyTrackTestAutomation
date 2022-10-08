using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.Utilities;

namespace VyTrackTestAutomation.DatabaseHelper
{
    public class Practice22
    {

        [Test]
        public static void GeneralTest(string[] args)
        {
            DatabaseManager db22 = new DatabaseManager();

            string newq = "select from ";
            var results = db22.GetReportingDataTable(newq);

            Console.WriteLine(results.number1);


            var onuncuRowFirstNAme = db22.GetReportingDataTableList(newq);

            List<String> Ssns = new List<string>();
            foreach(var eachrow in onuncuRowFirstNAme)
            {
                Ssns.Add(eachrow.number1);
            }
        }
        
        
    }
}
