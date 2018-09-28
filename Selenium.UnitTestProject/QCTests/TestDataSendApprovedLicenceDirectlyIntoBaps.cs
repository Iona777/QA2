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
    

    class CreateApprovedLicenceDirectlyIntoBaps : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {

        [Test]
        //This test clicks dashboard approved then hit save into baps area, select quote A and save into BAPS.  Checks user returned to dashboard.
        public void SendApprovedQuotesViaBAPS()
        {
            //Constants
            string customerCompanyName  = "TEST QC CUSTOMER";
            string customerNumber       = "3402211";
            string contactSurname       = "Marshall";
            string customerEmailAddress = "newtestaccount1@qa.com";
            string quoteValue           = "1000.00";

            //Setup Page(s)
            NewDashboardPage theDashboardPage                       = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustomersPage             = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theCustomerContactsPage    = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage               = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage     = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendtoCustomerPage             = new NewSendToCustomerPage(MyDriverManager.driver);


            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Booking Provisional Skills Licence Count
            string provisionalCountSL = theDashboardPage.getBookingProvisional_SL();
            int provisionalCountSL_int = int.Parse(provisionalCountSL);

            //Select Skills Licence.
            theDashboardPage.clickOnCreateSkillsLicenceButton();

            //Select customer
            theGetMyCustomersPage.waitForPageToLoad();
            theGetMyCustomersPage.populateCustomerSearchBox(customerCompanyName);
            theGetMyCustomersPage.selectCustomerByNumber(customerNumber);

            //Select contact
            theCustomerContactsPage.waitForPageToLoad();
            theCustomerContactsPage.clickOnBothButton();
            theCustomerContactsPage.populateContactsSearchBox(contactSurname);
            theCustomerContactsPage.selectCustomerEmail(customerEmailAddress);

            //Select licence template
            theGetMyLicencesPage.waitForPageToLoad();
            theGetMyLicencesPage.clickOnBankTemplate();

            //Enter quote details
            theAlterSkillsLicencePage.waitForPageToLoad();
            theAlterSkillsLicencePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");
            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Create skills licence in BAPs
            theSendtoCustomerPage.waitForPageToLoadSkillsLicence();
            theSendtoCustomerPage.clickOnSkillsLicenceCreateInBAPSbutton();
            Assert.IsTrue(theSendtoCustomerPage.getsubHeadingBAPS_SLText().Equals("BAPS"), "BAPS Subheading does NOT equal 'BAPS' ");
                        
            theSendtoCustomerPage.clickOnBapsCheckBoxQuoteA();
            theSendtoCustomerPage.clickOnSendtoCustomerButton_BAPS();

            theDashboardPage.waitForDashboardPageToLoad();

            
            // Check Provisional Skills Licence Count increased by 1
            int expectedValue_int = provisionalCountSL_int + 1;
            int updatedProvisionalCountSL_int = int.Parse(theDashboardPage.getBookingProvisional_SL());

            Assert.IsTrue(updatedProvisionalCountSL_int == expectedValue_int,
                "Expected provisionalCountSL= " + expectedValue_int + " actually got " + updatedProvisionalCountSL_int);
        }


    }
}
