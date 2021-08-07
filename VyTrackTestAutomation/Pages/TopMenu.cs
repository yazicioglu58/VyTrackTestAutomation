using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VyTrackTestAutomation.Utilities;

namespace VyTrackTestAutomation.Pages
{
    public class TopMenu
    {

        public IWebDriver driver;
        Commons commons = new Commons();
       

        public TopMenu()
        {

        }
        public TopMenu(IWebDriver driver)
        {
            Console.WriteLine("TopMenu Page Object Model created.");
             this.driver = driver;        
            Thread.Sleep(1500);
            PageFactory.InitElements(driver, this);
        }


        [FindsBy(How = How.XPath, Using = "(//span[@class='title title-level-1'])[2]")]
        private IWebElement fleet;

        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Vehicles Model')]")]
        private IWebElement vehiclesModel;

        [FindsBy(How = How.XPath, Using = "//a[@title='Create Vehicles Model']")]
        private IWebElement createVehicleModel;
    
    public void goToVehiclesPage()
        {
            Console.WriteLine("goToVehiclesPage method is started.");

            Actions action = new Actions(driver);
            Thread.Sleep(1000);
            action.MoveToElement(fleet).Perform();
            Thread.Sleep(1000);
            vehiclesModel.Click();
        }

        public void CreateAVehicle()
        {
            Console.WriteLine("CreateAVehicle method is started.");

            Thread.Sleep(2000);
            createVehicleModel.Click();
        }

    }


}