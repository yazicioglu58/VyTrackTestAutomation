using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VyTrackTestAutomation.Utilities;

namespace VyTrackTestAutomation.Pages
{
    public class CreateVehiclesModelPage
    {

        private IWebDriver driver;
        Commons commons = new Commons();

        public CreateVehiclesModelPage()
        {
        }

        public CreateVehiclesModelPage(IWebDriver driver)
        {
            Console.WriteLine("CreateVehiclesModelPage Page Object Model created.");
            this.driver = driver;               
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_ModelName-uid-610')]")]
        private IWebElement modelNameField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_Make-uid-610')]")]
        private IWebElement makeField;

        [FindsBy(How = How.XPath, Using = "//*[@id='s2id_custom_entity_type_Canberequested - uid - 610eea1c1fde0']/a")]
        private IWebElement canBeRequested;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_CatalogValue-uid-610')]")]
        private IWebElement catalogValueField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_CO2Fee-uid-610')]")]
        private IWebElement Co2FeeField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_Cost-uid-610')]")]
        private IWebElement costField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_TotalCost-uid-610')]")]
        private IWebElement totalCostField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_CO2Emissions-uid-610')]")]
        private IWebElement co2EmmisionsField;

        [FindsBy(How = How.XPath, Using = "//*[@id='s2id_custom_entity_type_FuelType - uid - 610eea1c2070b']/a/span[1]")]
        private IWebElement fuelType;
        
        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'custom_entity_type_Vendors-uid-610')]")]
        private IWebElement vendorField;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Save and Close')]")]
        private IWebElement saveAndCloseButton;

        public void createVehicleModel(string v1, string v2, string v4, string v5, string v6, string v7, string v8, string v10)
        {
            Thread.Sleep(5000);
            commons.sendKeysTest(modelNameField, v1);  
            makeField.Click();
            makeField.SendKeys(v2);
           // commons.dropDown(canBeRequested, v3);           
            catalogValueField.SendKeys(v4);
            Co2FeeField.SendKeys(v5);
            costField.SendKeys(v6);
            totalCostField.SendKeys(v7);
            co2EmmisionsField.SendKeys(v8);
        //    commons.dropDown(fuelType, v9);
            vendorField.SendKeys(v10);
            saveAndCloseButton.Click();

        }
        
    }
}
