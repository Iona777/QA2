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
    //add these bits in to make all tests run at same time
    [TestFixture]

    class CreateSkillsLicenceSmoke : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         

        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateSkillsLicenceSmokeTest()
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
            NewGetMyLicencesPage theGetMyLicencePage                    = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage         = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendtoCustomerPage                 = new NewSendToCustomerPage(MyDriverManager.driver);
            NewHeaderPage theHeaderPage                                 = new NewHeaderPage(MyDriverManager.driver);


            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Approved Skills Licence Count
            string approvedCountSL = theDashboardPage.getApprovedCount_SL();
            int approvedCountSL_int = int.Parse(approvedCountSL);

            //Select Skills Licence
            theDashboardPage.clickOnCreateSkillsLicenceButton();

            //Select Customer
            theGetMyCustomersPage.waitForPageToLoad();
            theGetMyCustomersPage.populateCustomerSearchBox(customerCompanyName);
            theGetMyCustomersPage.selectCustomerByNumber(customerNumber);

            //Select Contact
            theGetMyCustomerContactPage.waitForPageToLoad();
            theGetMyCustomerContactPage.clickOnBothButton();
            theGetMyCustomerContactPage.populateContactsSearchBox(contactSurname);
            theGetMyCustomerContactPage.selectCustomerEmail(customerEmailAddress);

            //Select licence template
            theGetMyLicencePage.waitForPageToLoad();
            theGetMyLicencePage.clickOnBankTemplate();

            //Enter Quote Details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");
            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Select Sales Portal via menu
            theSendtoCustomerPage.waitForPageToLoadSkillsLicence();
            theHeaderPage.clickOnquotationsMenuOption();
            theHeaderPage.clickOnsalesPortalMenuOption();

            theDashboardPage.waitForDashboardPageToLoad();

            // Check Approved Skills Licence Count increased by 1
            int expectedValue_int = approvedCountSL_int + 1;
            int updatedapprovedCountSL_int = int.Parse(theDashboardPage.getApprovedCount_SL() );

            Assert.IsTrue(updatedapprovedCountSL_int == expectedValue_int,
                "Expected approvedCountSL= " + expectedValue_int + " actually got " + updatedapprovedCountSL_int);
        }

    }
}
