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
 
    class SendApprovedLicenceViaEchosign : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         
 
        [Test]
        //This test creates a self-approved licence and sends via Echosign
        public void SendApprovedLicenceViaEchosignTest()
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

            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial With Customer Skills Licence Count
            string withCustomerCountSL = theDashboardPage.getWithCustomerCount_SL();
            int withCustomerCountSL_int = int.Parse(withCustomerCountSL);

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

            //Enter quote details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");

            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Send Skills Licence to customer via Echosign
            theSendToCustomerPage.waitForPageToLoadSkillsLicence();
            theSendToCustomerPage.clickOnSendUsingAdobeSignButton();
            Assert.IsTrue(theSendToCustomerPage.getsubHeadingAdobeText().Equals("ADOBE SIGN"), "Portal Subheading does NOT equal 'ADOBE SIGN' ");
            theSendToCustomerPage.clickOnAdobeCheckBoxQuoteA();
            theSendToCustomerPage.clickOnSendtoCustomerButton_Adobe(); ;

            theDashboardPage.waitForDashboardPageToLoad();

            // Check WithCustomer Count increased by 1
            int expectedValue_int = withCustomerCountSL_int + 1;
            int updatedWithCustomerCountSL_int = int.Parse(theDashboardPage.getWithCustomerCount_SL() );

            Assert.IsTrue(updatedWithCustomerCountSL_int == expectedValue_int,
                "Expected withCustomerCountSL= " + expectedValue_int + " actually got " + updatedWithCustomerCountSL_int);
        }

    }
}
