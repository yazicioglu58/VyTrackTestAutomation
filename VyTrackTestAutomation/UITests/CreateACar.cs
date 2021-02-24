using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.Local_Settings;
using VyTrackTestAutomation.Pages;
using VyTrackTestAutomation.Utilities;

namespace VyTrackTestAutomation.UITests
{

    [TestClass]
    public class CreateACar : BaseTest
    {
        AllPages all = new AllPages();

    [ClassInitialize]
    public static void ClassInitialize(TestContext context)
    {
            //testContextInstance = context;
           
        }

    [TestInitialize]
    public void TestInitialization()
    { 
        LaunchBrowser();
          
            all.LoginPage(driver).login();

        }

    [TestMethod]
    public void Test()
    {
            try
            {

                Console.WriteLine("Create a car Test is started.");
                all.TopMenu(driver).goToVehiclesPage();
                all.TopMenu(driver).CreateAVehicle();
                all.CreateVehiclesModelPage(driver).createVehicleModel(LocalStrings.modelName,
                                            LocalStrings.make,
                                            LocalStrings.canBeRequested,
                                            LocalStrings.catalogValue,
                                            LocalStrings.co2Fee,
                                            LocalStrings.cost,
                                            LocalStrings.totalCost,
                                            LocalStrings.co2Emmisions,
                                            LocalStrings.fuelType,
                                            LocalStrings.vendor);


            } 
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CloseBrowser();
        }
    }
}