using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyTrackTestAutomation.PracticeFolder
{
    public class EnumsTrial
    {
        // https://csharp-video-tutorials.blogspot.com/2012/06/part-45-c-tutorial-why-enums.html
        //public static void Main()
        //{
        //    Customer[] customers = new Customer[3];
        //    customers[0] = new Customer()
        //    {
        //        Name = "Mark",
        //        Gender = 1
        //    };
        //    customers[1] = new Customer()
        //    {
        //        Name = "Mary",
        //        Gender = 2
        //    };
        //    customers[2] = new Customer()
        //    {
        //        Name = "Sam",
        //        Gender = 0
        //    };
        //    foreach (Customer customer in customers)
        //    {
        //        Console.WriteLine("Name = {0} && Gender = {1}", customer.Name, GetGender(customer.Gender));
        //    }
        //}


        public static string GetGender(int gender)
        {
            // The swicth here is less readable because of these integral numbers
            switch (gender)
            {
                case 0:
                    return "Unknown";
                case 1:
                    return "Male";
                case 2:
                    return "Female";
                default:
                    return "Invalid Data for Gender";
            }
        }
    }


    // 0 - Unknown
    // 1 - Male
    // 2 - Female


    public class Customer
    {
        public string Name { get; set; }
        public int Gender { get; set; }
    }
}

