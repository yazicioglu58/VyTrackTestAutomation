using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VyTrackTestAutomation.Local_Settings;

namespace VyTrackTestAutomation.Utilities
{
   public class Commons
    {
        public IWebDriver driver;

        public void InitPageElementsIfPageLoads()
        {
            Console.WriteLine("Attempting to initialize elements for page");
            int implicitWaitTime = LocalTestProperties.IMPLICIT_WAIT_TIME_MILLISECONDS;
            while (implicitWaitTime > 0 )
            {
                implicitWaitTime -= LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS;
                Thread.Sleep(LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS);
            }           
        }

        public string GetWindowPageName()
        {
            IJavaScriptExecutor javascriptInstance = (IJavaScriptExecutor)driver;
            return (string)javascriptInstance.ExecuteScript("return window.location.pathname");
        }

        public void WaitUntilElementHasValue(IWebElement elementWithStringValue)
        {
            int implicitWaitTime = LocalTestProperties.IMPLICIT_WAIT_TIME_MILLISECONDS;
            while (implicitWaitTime > 0 && string.IsNullOrWhiteSpace(elementWithStringValue.Text))
            {
                implicitWaitTime -= LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS;
                Task.Delay(LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS);
            }
        }

        public void WaitUntilSpinnerDisappears()
        {
            IWebElement elementSpinner = driver.FindElement(By.Id("loadingIcon"));
            int implicitWaitTime = LocalTestProperties.IMPLICIT_WAIT_TIME_MILLISECONDS;
            while (implicitWaitTime > 0 && elementSpinner.Displayed)
            {
                implicitWaitTime -= LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS;
                Task.Delay(LocalTestProperties.DOM_POLLING_INTERVAL_MILLISECONDS);
            }
        }
        public string GetAlertPopUpMessageText()
        {
            Thread.Sleep(4000);
            return driver.SwitchTo().Alert().Text;
        }

        public void HandleAlertPopUp(string acceptOrDismiss)
        {
            Thread.Sleep(4000);
            IAlert alertPopUp = driver.SwitchTo().Alert();

            if (acceptOrDismiss == "accept")
            {
                alertPopUp.Accept();
            }
            else
            {
                alertPopUp.Dismiss();
            }
        }

        public void hover(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        /*// public static IList<string> getElementsText(IList<IWebElement> list)
         {
           *//*  IList<string> elemTexts = new ArrayList<>();
             for (IWebElement el : list)
             {
                 elemTexts.Add(el.Text);
             }
             return elemTexts;*//*
         }*/

         public void dropDown(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(value);
        }

        public void sendKeysTest(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
            
        }
    }
}
