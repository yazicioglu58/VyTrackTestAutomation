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
        }      
       
        public void CloseBrowser()
        {            
            driver.Quit();
        }

        public void TakeScreenShot()
        {
            try
            {
                if ((string)TestContext.Parameters["RUNFROMPIPELINE"] == "true")
                {
                    Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
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
                    driver = new ChromeDriver();
                    break;

            }
        }
       
    }
}
