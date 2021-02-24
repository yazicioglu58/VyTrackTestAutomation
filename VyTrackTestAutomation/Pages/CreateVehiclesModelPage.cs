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
            commons.InitPageElementsIfPageLoads();
            Thread.Sleep(1500);
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='custom_entity_type_ModelName-uid-60289ef6c6fc2']")]
        private IWebElement modelNameField;

        [FindsBy(How = How.XPath, Using = "custom_entity_type_Make-uid-60289622f067e")]
        private IWebElement makeField;

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Choose a value...')])[1]")]
        private IWebElement canBeRequested;

        [FindsBy(How = How.Id, Using = "custom_entity_type_CatalogValue-uid-60289622f0c3d")]
        private IWebElement catalogValueField;

        [FindsBy(How = How.Id, Using = "custom_entity_type_CO2Fee-uid-60289622f0d1b")]
        private IWebElement Co2FeeField;

        [FindsBy(How = How.Id, Using = "custom_entity_type_Cost-uid-60289622f0e08")]
        private IWebElement costField;

        [FindsBy(How = How.Id, Using = "custom_entity_type_TotalCost-uid-60289622f0ee7")]
        private IWebElement totalCostField;

        [FindsBy(How = How.Id, Using = "custom_entity_type_CO2Emissions-uid-60289622f0fc3")]
        private IWebElement co2EmmisionsField;

        [FindsBy(How = How.XPath, Using = "(//span[contains(text(), 'Choose a value...')])[2]")]
        private IWebElement fuelType;
        
        [FindsBy(How = How.Id, Using = "custom_entity_type_Vendors-uid-60289622f11dc")]
        private IWebElement vendorField;

        [FindsBy(How = How.XPath, Using = "//button[contains(text(), 'Save and Close')]")]
        private IWebElement saveAndCloseButton;

        public void createVehicleModel(string v1, string v2, string v3, string v4, string v5, string v6, string v7, string v8, string v9, string v10)
        {
            Thread.Sleep(5000);
            modelNameField.SendKeys(v1);
            Thread.Sleep(5000);

            makeField.SendKeys(v2);
            Thread.Sleep(5000);

            commons.dropDown(canBeRequested, v3);           
            catalogValueField.SendKeys(v4);
            Co2FeeField.SendKeys(v5);
            costField.SendKeys(v6);
            totalCostField.SendKeys(v7);
            co2EmmisionsField.SendKeys(v8);
            commons.dropDown(fuelType, v9);
            vendorField.SendKeys(v10);
            saveAndCloseButton.Click();

        }
        
    }
}
