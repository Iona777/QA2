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
    [Parallelizable]

    class CreateAwaitingApprovalSkillsLicence : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         
       
        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateAwaitingApprovalSkillsLicenceTest()
        {
            //Constants
            string customerCompanyName = "TEST QC CUSTOMER";
            string customerNumber = "3402211";
            string contactSurname = "Marshall";
            string customerEmailAddress = "newtestaccount1@qa.com";
            string quoteValue = "1000.00";
            string discountValue = "99";

            //Setup Page(s)
            NewDashboardPage theDashboardPage                       = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustomersPage             = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theCustomerContactsPage    = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage               = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage     = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewSendToCustomerPage theSendtoCustomerPage             = new NewSendToCustomerPage(MyDriverManager.driver);
            NewManagerApprovalPage theManagerApprovalPage           = new NewManagerApprovalPage(MyDriverManager.driver);


            //Go to the initial page
            MyDriverManager.goToDashboardPage();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theDashboardPage.clickOnChangeTheUserBtn();
            theDashboardPage.waitForDashboardPageToLoad();

            //Get Initial Awaiting Approval Skills Licence Count
            string awaitingApprovedCountSL = theDashboardPage.getAwaitingApprovalCount_SL();
            int awaitingApprovedCountSL_int = int.Parse(awaitingApprovedCountSL);

            //Select Skills Licence
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

            //Enter a discount and check for hierarchy warning text
            theAlterSkillsLicencePage.enterDiscountForAmazonQuoteA(discountValue);
            string warningText = theAlterSkillsLicencePage.getHierarchyWarningText();     
            Assert.IsTrue(warningText.Equals("Over Sales Director"), warningText + " does NOT equal 'Over Sales Director'");
            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Select first manager in list and send for approval
            theManagerApprovalPage.waitForPageToLoad();
            theManagerApprovalPage.selectFirstManager();
            theManagerApprovalPage.clickOnSubmitForManagerApprovalButton();
            theDashboardPage.waitForDashboardPageToLoad();

            // Check Awaiting Approval Skills Licence Count increased by 1
            int expectedValue_int = awaitingApprovedCountSL_int + 1;
            int updatedAwaitingApprovalCountSL_int = int.Parse(theDashboardPage.getAwaitingApprovalCount_SL() );

            Assert.IsTrue(updatedAwaitingApprovalCountSL_int == expectedValue_int,
                "Expected awaitingApprovedCountSL= " + expectedValue_int + " actually got " + updatedAwaitingApprovalCountSL_int);
        }

    }
}
