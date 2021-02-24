using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VyTrackTestAutomation.Pages;

namespace VyTrackTestAutomation.Utilities
{
    public class AllPages
    {

        private LoginPage loginPage;
        private TopMenu topMenu;
        private CreateVehiclesModelPage createVehiclesModelPage;        

    public LoginPage LoginPage(IWebDriver driver)
    {
       
            if (loginPage == null)
            {
                loginPage = new LoginPage(driver);
            }
            return loginPage;
        }
    
    public TopMenu TopMenu(IWebDriver driver)
    {

        if (topMenu == null)
        {
            topMenu = new TopMenu(driver);
        }
        return topMenu;
    }

        public CreateVehiclesModelPage CreateVehiclesModelPage(IWebDriver driver)
        {

            if (createVehiclesModelPage == null)
            {
                createVehiclesModelPage = new CreateVehiclesModelPage(driver);
            }
            return createVehiclesModelPage;
        }

    }
 }



