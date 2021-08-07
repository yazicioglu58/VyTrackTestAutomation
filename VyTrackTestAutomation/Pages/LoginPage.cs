using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using System.Diagnostics;
using VyTrackTestAutomation.Local_Settings;
using VyTrackTestAutomation.Utilities;

namespace VyTrackTestAutomation.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        Commons commons = new Commons();

        public  LoginPage(){
            }

        public LoginPage(IWebDriver driver)  
        {
            Console.WriteLine("Home Page Object Model created.");
            this.driver = driver;         
            Thread.Sleep(1500);
            PageFactory.InitElements(driver, this);
        }

        
        [FindsBy(How = How.PartialLinkText, Using = "LOGIN")]
        private IWebElement loginButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-prepend']//input")]
        private IWebElement username;

        [FindsBy(How = How.XPath, Using = "//div[@class='input-prepend input-prepend--last']//input")]
        private IWebElement password;
        
        [FindsBy(How = How.Id, Using = "_submit")]
        private IWebElement submitButton;

        public void login()
        {
            Console.WriteLine("Login called.");
            Thread.Sleep(1000);
            loginButton.Click();
            username.SendKeys(LocalStrings.Username);
            password.SendKeys(LocalStrings.Password);
            submitButton.Click();

        }
    }
}


