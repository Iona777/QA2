using NUnit.Framework;
using Selenium.UnitTestProject.QCPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.UnitTestProject.WebDriverManager;
using Selenium.UnitTestProject.EnvironmentConfig;

namespace Selenium.UnitTestProject.QCTests
{
    [TestFixture]
    class DummyTest
    {
        [Test]
        public void DummyMethodTest()
        {
            //Constants
            string customerCompanyName = "TEST QC CUSTOMER";
            string customerNumber = "3402211";
            string contactSurname = "Marshall";
            string customerEmailAddress = "newtestaccount1@qa.com";
            string quoteValue = "1000.00";


            //Setup Page(s)
            NewDashboardPage theDashboardPage = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustumersPage = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theContactsPAge = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theSkillLicencePage = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicensePage = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendPAge = new NewSendToCustomerPage(MyDriverManager.driver);


            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Approved Skills Licence Count
            string appCountSL = theDashboardPage.getApprovedCount_SL();
            int appCountSL_int = int.Parse(appCountSL);

            //Select Skills Licence
            theDashboardPage.clickOnCreateSkillsLicenceButton();
            


            //Select customer
            theGetMyCustumersPage.waitForPageToLoad();
            theGetMyCustumersPage.populateCustomerSearchBox(customerCompanyName);
            theGetMyCustumersPage.selectCustomerByNumber(customerNumber);

            //Select Contact            
            theContactsPAge.waitForPageToLoad();
            theContactsPAge.clickOnBothButton();
            theContactsPAge.populateContactsSearchBox(contactSurname);
            theContactsPAge.selectCustomerEmail(customerEmailAddress);

            //Select licence
            theSkillLicencePage.waitForPageToLoad();
            theSkillLicencePage.clickOnBankTemplate();


            //Enter quote details
            theAlterSkillsLicensePage.waitForPageToLoad();
            theAlterSkillsLicensePage.populateQuoteATextBox(quoteValue);
            theAlterSkillsLicensePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicensePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");

            theAlterSkillsLicensePage.clickOnSaveAndSendButton();

            //Send Skills Licence to customer via Portal
            theSendPAge.waitForPageToLoadacp();
            theSendPAge.clickOnSendUsingPortalButton();
            Assert.IsTrue(theSendPAge.getsubHeadingPortalText().Equals("PORTAL"));

            theSendPAge.clickOnSendtoCustomerButton_Portal();




            // Check approvedSL Count increased by 1
            int expectedValue_int = approvedCountSL_int + 1;
            int updatedApprovedCountSL_int = int.Parse(theDashboardPage.getApprovedCount_SL());

            Assert.IsTrue(updatedApprovedCountSL_int == expectedValue_int,
                "Expected approvedCountSL= " + expectedValue_int + " actually got " + updatedApprovedCountSL_int);
        }

    }
}
