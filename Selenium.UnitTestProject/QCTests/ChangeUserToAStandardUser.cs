using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using Selenium.UnitTestProject.QCPages;
using Selenium.UnitTestProject.EnvironmentConfig;
using Selenium.UnitTestProject.WebDriverManager; //Because MyDriverManager in a separate namespace


namespace Selenium.UnitTestProject
{
    
    [TestFixture]
    
    class ChangeUserToAStandardUser : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {
       
        [Test]
        //This tests uses the app.config value to pick a salesperson and change SP to use that salesperson to login
        public void ChangeUserToAStandardUserTest()
        {
            //Setup Page(s)
            NewDashboardPage theDashboardPage = new NewDashboardPage(MyDriverManager.driver);

            //Go to the the intial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();
           
           }
        }
   
    }

