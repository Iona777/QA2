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
using Selenium.UnitTestProject.WebDriverManager;

namespace Selenium.UnitTestProject
{  

    [TestFixture]
   

    class CreateApprovedButSuspendedSkillsLicenceSmoke : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         
 
        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateApprovedButSuspendedSkillsLicenceSmokeTest()
        {
            //Constants
            string customerCompanyName      = "TEST QC CUSTOMER";
            string customerNumber           = "3402211";
            string contactSurname           = "Marshall";
            string customerEmailAddress     = "newtestaccount1@qa.com";
            string quoteValue               = "1000.00";

            //Setup Page(s)
            NewDashboardPage theDashboardPage                           = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustomersPage                 = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theGetMyCustomerContactPage    = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage                   = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage         = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendToCustomerPage                 = new NewSendToCustomerPage(MyDriverManager.driver);
            NewHeaderPage theHeaderPage                                 = new NewHeaderPage(MyDriverManager.driver);
            NewDashBoardWithMeApprovedPage theDashboardWithMeApprovedPage = new NewDashBoardWithMeApprovedPage(MyDriverManager.driver);

            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Suspended Skills Licence Count
            string suspendedCountSL = theDashboardPage.getSuspendedCount_SL();
            int suspendedCountSL_int = int.Parse(suspendedCountSL);

            //Select Skills Licence.
            theDashboardPage.clickOnCreateSkillsLicenceButton();

            //Select customer
            theGetMyCustomersPage.waitForPageToLoad();
            theGetMyCustomersPage.populateCustomerSearchBox(customerCompanyName);
            theGetMyCustomersPage.selectCustomerByNumber(customerNumber);

            //Select contact
            theGetMyCustomerContactPage.waitForPageToLoad();
            theGetMyCustomerContactPage.clickOnBothButton();
            theGetMyCustomerContactPage.populateContactsSearchBox(contactSurname);
            theGetMyCustomerContactPage.selectCustomerEmail(customerEmailAddress);

            //Select licence template
            theGetMyLicencesPage.waitForPageToLoad();
            theGetMyLicencesPage.clickOnBankTemplate();

            //Enter quote details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");
            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Select Sales Portal via menu
            theSendToCustomerPage.waitForPageToLoadSkillsLicence();
            theHeaderPage.clickOnquotationsMenuOption();
            theHeaderPage.clickOnsalesPortalMenuOption();
     
            //Find approved Skills Licence and suspend it.
            theDashboardPage.waitForDashboardPageToLoad();
            theDashboardPage.clickOnApproved_SL();
            theDashboardWithMeApprovedPage.waitForPageToLoad();
            theDashboardWithMeApprovedPage.clickOnSuspendButton();
            
            theDashboardPage.waitForDashboardPageToLoad();

            
            //Check Suspended Skills Licence Count increased by 1
            int expectedValue_int = suspendedCountSL_int + 1;
            int updatedSuspendedCountSL_int = int.Parse(theDashboardPage.getSuspendedCount_SL());

            Assert.IsTrue(updatedSuspendedCountSL_int == expectedValue_int,
                "Expected suspendedCountSL= " + expectedValue_int + " actually got " + updatedSuspendedCountSL_int);
        }

    }
}
