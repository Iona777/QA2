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

using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Runtime.Remoting.Contexts;


namespace Selenium.UnitTestProject
{
    
    [TestFixture]
    

    public class ChangeUserToAManager : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {
       
        [Test]
        

        //This tests uses the app.config value to pick a manager and change SP to use that salesperson to login.  It then checks user has landed on a manager version of the dashboard page.
        public void ChangeUserToAManagerTest()
        {
            //Setup reporting for this test           
            ExtentTest test = MyDriverManager.report.CreateTest("ChangeUserToAManagerTest");        

            //Setup Page(s)
            NewDashboardPage theDashboardPage              = new NewDashboardPage(MyDriverManager.driver);
            NewManagerDashboardPage theManagerDashboardPage = new NewManagerDashboardPage(MyDriverManager.driver);
                
            //Go to the the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.ManagerUserName());
            theDashboardPage.clickOnChangeTheUserBtn();

            //Check we are on manager version of Dashboard
            theManagerDashboardPage.waitForPageToLoad();


            //Set reporting info
            test.Pass("User successfully changed to manager");
            test.Log(Status.Pass, "ChangeUserToAManagerTest passed");

        }

    }
}
