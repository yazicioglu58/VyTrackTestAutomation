using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.Enums;

namespace VyTrackTestAutomation.Local_Settings
{
    public class LocalTestProperties
    {
        public static TestEnvironment DEFAULT_ENVIRONMENT = TestEnvironment.QA;
        public static BrowserType DEFAULT_BROWSER_TYPE = BrowserType.Chrome;

        public static string URL_QA = "https://vytrack.com/";
        public static string URL_DEV = "https://vytrack.com/";
        public static string URL_LOCAL_UI = "https://vytrack.com/";
        public static string URL_STAGE = "https://vytrack.com/";
        public static string URL_PRODUCTION = "https://vytrack.com/";


        public static int IMPLICIT_WAIT_TIME_SECONDS = 10;
        public static int IMPLICIT_WAIT_TIME_MILLISECONDS = IMPLICIT_WAIT_TIME_SECONDS * 1000;
        public static int DOM_POLLING_INTERVAL_MILLISECONDS = 100;

        //Sets the URL based on which environment is set in the LocalTestProperties.cs
        public static string GetURLForDefaultEnv()
        {
            switch (DEFAULT_ENVIRONMENT)
            {

                case TestEnvironment.Dev:
                    return URL_DEV;
                case TestEnvironment.QA:
                    return URL_QA;
                case TestEnvironment.STAGE:
                    return URL_STAGE;
                case TestEnvironment.Production:
                    return URL_PRODUCTION;
                default:
                    return "";
            }
        }



    }


}


