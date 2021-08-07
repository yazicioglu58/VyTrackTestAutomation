using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VyTrackTestAutomation.Utilities
{
   public class BrowserUtils : BaseTest
    {
       
        public void WaitUntilElementHasValue(IWebElement elementWithStringValue)
        {
            //int implicitWaitTime = GetJsonConfigurationValue("Implicit_Wait_Time_Ms");
            //while (implicitWaitTime > 0 && string.IsNullOrWhiteSpace(elementWithStringValue.Text))
            //{
            //    implicitWaitTime -= GetJsonConfigurationValue(Dom_Polling_Interval_Ms);
            //    Task.Delay(GetJsonConfigurationValue(Dom_Polling_Interval_Ms));
            //}
        }

        public string GetAlertPopUpMessageText()
        {
            BrowserUtils.waitFor(4);
            return driver.SwitchTo().Alert().Text;
        }

        public void HandleAlertPopUp(string acceptOrDismiss)
        {
            BrowserUtils.waitFor(4);
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

        public void Hover(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public IList<string> GetElementsText1(By locator)
        {
            IList elements = driver.FindElements(locator);

            List<string> elemTexts = new List<string>();
            foreach (IWebElement el in elements)
            {
                elemTexts.Add(el.Text);
            }
            return elemTexts;
        }

        public IList<string> GetElementsText2(IList<IWebElement> elements)
        {
            List<string> elemTexts = new List<string>();
            foreach (IWebElement el in elements)
            {
                elemTexts.Add(el.Text);
            }
            return elemTexts;
        }


        public static void DropDown(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByText(value);
        }

        public void GetElementByText(string value)
        {
            driver.FindElement(By.LinkText(value)).Click();
        }

        public static void SendKeysTest(IWebElement element, string anyKey)
        {
            element.Clear();
            element.SendKeys(anyKey);
        }

        public static void CheckBoxTest(IWebElement element)
        {
            if (!element.Enabled)
            {
                element.Click();
            }
        }

        public static void UncheckBoxTest(IWebElement element)
        {
            if (element.Enabled)
            {
                element.Click();
            }
        }
        public string GetPopUpText()
        {
            IAlert alert = driver.SwitchTo().Alert();
            var messageOnPopUp = alert.Text;
            Console.WriteLine("message is " + messageOnPopUp);
            //   alert.Accept();
            return messageOnPopUp;
        }

        public void EnterTextToPopUp(string reason)
        {
            BrowserUtils.waitFor(7);

            //  IWebDriver driver = new ChromeDriver();
            IAlert alert = driver.SwitchTo().Alert();

            BrowserUtils.waitFor(4);
            //   alert.SendKeys(reason);

            // alert.SendKeys(reason);
            BrowserUtils.waitFor(4);

            alert.Accept();
            BrowserUtils.waitFor(4);
        }

        public void ClickByAction(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void ClickByJs(IWebElement element)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            jse.ExecuteScript("arguments[0].Click()", element);
        }

        public void WaitUntilClickability(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void WaitForElement(IWebElement element, int timeout = 20)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.Until<bool>(driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }


        /*
       * switches to new window by the exact title
       */
        public void switchToWindow(String targetTitle)
        {
            string origin = driver.CurrentWindowHandle;
            foreach (string handle in driver.WindowHandles)
            {
                driver.SwitchTo().Window(handle);
                if (driver.Title.Equals(targetTitle))
                {
                    return;
                }
            }
            driver.SwitchTo().Window(origin);
        }

        public void hover(IWebElement element)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(element).Perform();
        }

        public static void waitFor(int sec)
        {
            try
            {
                Thread.Sleep(sec * 1000);
            }
            catch (ThreadInterruptedException e)
            {
                Console.WriteLine("newThread cannot go to sleep - " +
               "interrupted by main thread.");
            }
        }
        public string GetSkNumberFromUrl()
        {
            string currentUrl = driver.Url;
            int equalsIndex = currentUrl.IndexOf("=");
            return currentUrl.Substring(equalsIndex + 1);
        }

        public void WaitForAlert(bool accept)
        {
            //Initialize your wait.
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //Wait for alert
            IAlert alert = driver.SwitchTo().Alert();
            try
            {
                wait.Until(ExpectedConditions.AlertIsPresent());
                if (accept)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
            }
            catch (WebDriverTimeoutException) { /*Alert did not appear, do nothing*/ }
        }
    }
}
