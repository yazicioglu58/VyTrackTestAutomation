using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.Enums;
using VyTrackTestAutomation.Local_Settings;

namespace VyTrackTestAutomation.Utilities
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected BrowserType browserType;
        protected TestEnvironment environment;
        protected string URL;

        //  public static TestContext testContextInstance;
        //   public TestContext TestContext
        //  {
        //      get
        //    {
        //      return testContextInstance;
        //   }
        //   set
        //   {
        //    testContextInstance = value;
        //   }
        //  }              

        protected void SetRunSettings()
        {
            if ((string)TestContext.Parameters["RUNFROMPIPELINE"] == "true")
            {
                UsePipelineSettings();
            }
            else
            {
                UseLocalSettings();
            }
        }

        protected void UsePipelineSettings()
        {
            URL = (string)TestContext.Parameters["URL"];

            if (!Enum.TryParse((string)TestContext.Parameters["ENVIRONMENT"], out environment))
            {
                //Log parsing error
            }

            if (!Enum.TryParse((string)TestContext.Parameters["BROWSER"], out browserType))
            {
                //Log parsing error
            }

            SetDriver(true);
        }

        protected void UseLocalSettings()
        {
            URL = LocalTestProperties.GetURLForDefaultEnv();
            browserType = LocalTestProperties.DEFAULT_BROWSER_TYPE;
            SetDriver(false);
        }

        protected void LaunchBrowser()
        {
            SetRunSettings();

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LocalTestProperties.IMPLICIT_WAIT_TIME_SECONDS);

            driver.Navigate().GoToUrl(URL);

            //driver.Manage().Logs.GetLog(LogType.Browser);
        }

        protected void LaunchBrowserEcommLogin()
        {
            SetRunSettings();

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LocalTestProperties.IMPLICIT_WAIT_TIME_SECONDS);

            //  driver.Navigate().GoToUrl("https://vytrack.com/");
            driver.Navigate().GoToUrl("https://vytrack.com/");

        }

        protected void LaunchBrowserCustomerPortalLoginPage()
        {
            SetRunSettings();

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LocalTestProperties.IMPLICIT_WAIT_TIME_SECONDS);

            driver.Navigate().GoToUrl("https://vytrack.com/");

        }
        public void CloseBrowser()
        {
            TakeScreenShot();
            driver.Quit();
        }

        public void TakeScreenShot()
        {
            try
            {
                if ((string)TestContext.Parameters["RUNFROMPIPELINE"] == "true")
                {
                    Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                    //    string path = Directory.GetCurrentDirectory() + testContextInstance.FullyQualifiedTestClassName + ".png";
                    //     screenShot.SaveAsFile(path);
                    //   TestContext.AddResultFile(path);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void TearDown()
        {
            driver.Close();
        }

        private void CleanCookies()
        {
            driver.Manage().Cookies.DeleteAllCookies();
        }

        private void SetDriver(bool runOnPipeline)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    var chromeOptions = new ChromeOptions();
                    if (runOnPipeline)
                    {
                        chromeOptions.AddArguments("headless");
                    }

                    driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);
                    break;

            }
        }
       
        protected void SetRunSettings(string Type)
        {
            if ((string)TestContext.Parameters["RUNFROMPIPELINE"] == "true")
            {
                UsePipelineSettings();
            }
            else
            {
                UseLocalSettings(Type);
            }
        }

        protected void UseLocalSettings(String Type)
        {
            if (Type.Equals("Acquisition"))
                URL = LocalTestProperties.GetURLForDefaultEnv();
            else if (Type.Equals("Customer"))
                URL = LocalTestProperties.GetURLForDefaultEnv();
            else
                Assert.Fail("Not valid url type provided");
            browserType = LocalTestProperties.DEFAULT_BROWSER_TYPE;
            SetDriver(false);
        }

        protected void LaunchBrowser(String Type)
        {
            SetRunSettings(Type);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(LocalTestProperties.IMPLICIT_WAIT_TIME_SECONDS);

            driver.Navigate().GoToUrl(URL);

        }
    }
}
