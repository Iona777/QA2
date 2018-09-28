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

    class SendApprovedQuotesViaCustomerPortal : Hooks//Inherit the SetUp and TearDown from Hooks class.
    {         
 
        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void SendApprovedQuotesViaCustomerPortalTest()
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
            NewGetMyCustomerContactsPage theGetMyCustomerContactsPage   = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage                   = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage         = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendToCustomerPage                 = new NewSendToCustomerPage(MyDriverManager.driver);

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

            //Select customer
            theGetMyCustomersPage.waitForPageToLoad();
            theGetMyCustomersPage.populateCustomerSearchBox(customerCompanyName);
            theGetMyCustomersPage.selectCustomerByNumber(customerNumber);

            //Select Contact            
            theGetMyCustomerContactsPage.waitForPageToLoad();
            theGetMyCustomerContactsPage.clickOnBothButton();
            theGetMyCustomerContactsPage.populateContactsSearchBox(contactSurname);
            theGetMyCustomerContactsPage.selectCustomerEmail(customerEmailAddress);

            //Select licence
            theGetMyLicencesPage.waitForPageToLoad();
            theGetMyLicencesPage.clickOnBankTemplate();

            //Enter quote details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");

            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Send Skills Licence to customer via Portal
            theSendToCustomerPage.waitForPageToLoadSkillsLicence();
            theSendToCustomerPage.clickOnSendUsingPortalButton();
            Assert.IsTrue(theSendToCustomerPage.getsubHeadingPortalText().Equals("PORTAL"), "Portal Subheading does NOT equal 'PORTAL' ");
            theSendToCustomerPage.clickOnSendtoCustomerButton_Portal();

            theDashboardPage.waitForDashboardPageToLoad();

            // Check approvedSL Count increased by 1
            int expectedValue_int = approvedCountSL_int + 1;
            int updatedApprovedCountSL_int = int.Parse(theDashboardPage.getApprovedCount_SL() );

            Assert.IsTrue(updatedApprovedCountSL_int == expectedValue_int,
                "Expected approvedCountSL= " + expectedValue_int + " actually got " + updatedApprovedCountSL_int);

        }
        
    }
}
