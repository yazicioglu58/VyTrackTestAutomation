using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VyTrackTestAutomation.UITests
{
    public class practice
    {
        public practice()
        {

        }

        [Test]
        public void Test3()
        {
            List<string> list = new List<string>();

            Console.WriteLine("Adding some numbers:");
            list.Add("two");
            list.Add("two");
            list.Add("three");
            list.Add("four");
            list.Add("five");
            list.Add("five");
            list.Add("five");
            list.Add("six");
            list.Add("seven");

            Console.WriteLine(list[2]);
            string str = "Reverse Me!!";

            string reverse = (string)str.Reverse();
            Console.WriteLine(reverse);
        }
    }

}