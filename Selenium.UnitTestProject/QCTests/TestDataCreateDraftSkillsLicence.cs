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
    
    class CreateDraftSkillsLicence: Hooks //Inherit the SetUp and TearDown from Hooks class.
    {

        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateDraftSkillsLicenceSmokeTest()
        {
            //Constants
            string customerCompanyName = "TEST QC CUSTOMER";
            string customerNumber = "3402211";
            string contactSurname = "Marshall";
            string customerEmailAddress = "newtestaccount1@qa.com";
            string quoteValue = "1000.00";


            //Setup Page(s)
            NewDashboardPage theDashboardPage = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustomersPage = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theGetMyCustomerContactPage = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendToCustomerPage = new NewSendToCustomerPage(MyDriverManager.driver);

            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Draft Skills Licence Count
            string draftCountSL = theDashboardPage.getDraftCount_SL();
            int draftCountSL_int = int.Parse(draftCountSL);


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

            //Select licence
            theGetMyLicencesPage.waitForPageToLoad();
            theGetMyLicencesPage.clickOnBankTemplate();

            //Enter Quote Details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");

            //Save Skills Licence as a Draft
            theAlterSkillsLicencePage.clickOnSaveDraftButton();
            theDashboardPage.waitForDashboardPageToLoad();

            // Check Draft Skills Licence Count increased by 1
            int expectedValue_int = draftCountSL_int + 1;
            int updatedDraftCountSL_int = int.Parse(theDashboardPage.getDraftCount_SL());

            Assert.IsTrue(updatedDraftCountSL_int == expectedValue_int,
                "Expected draftCountSL= " + expectedValue_int + " actually got " + updatedDraftCountSL_int);
        }
    }
}
