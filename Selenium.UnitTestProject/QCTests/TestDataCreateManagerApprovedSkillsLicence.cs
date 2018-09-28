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
   

    class CreateManagerApprovedSkillsLicence : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         
 
        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateManagerApprovedSkillsLicenceTest()
        {

            //Constants
            string customerCompanyName  = "TEST QC CUSTOMER";
            string customerNumber       = "3402211";
            string contactSurname       = "Marshall";
            string customerEmailAddress = "newtestaccount1@qa.com";
            string quoteValue           = "1000.00";
            string discountValue        = "99";

            //Setup Page(s)
            NewDashboardPage theDashboardPage                       = new NewDashboardPage(MyDriverManager.driver);
            NewGetMyCustomersPage theGetMyCustomersPage             = new NewGetMyCustomersPage(MyDriverManager.driver);
            NewGetMyCustomerContactsPage theCustomerContactsPage    = new NewGetMyCustomerContactsPage(MyDriverManager.driver);
            NewGetMyLicencesPage theGetMyLicencesPage               = new NewGetMyLicencesPage(MyDriverManager.driver);
            NewAlterSkillsLicencePage theAlterSkillsLicencePage     = new NewAlterSkillsLicencePage(MyDriverManager.driver);
            NewManagerApprovalPage theManagerApprovalPage           = new NewManagerApprovalPage(MyDriverManager.driver);
            NewManagerDashboardPage theManagerDashboardPage          = new NewManagerDashboardPage(MyDriverManager.driver);
            NewShowManagerSkillsLicencePage theShowManagerSkillsLicencePage 
                                                                    = new NewShowManagerSkillsLicencePage(MyDriverManager.driver);

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

            //Create Skill Licence
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

            //Select manager and send for approval
            theManagerApprovalPage.waitForPageToLoad();
            theManagerApprovalPage.selectAnotherManager(ConfigurationWrapper.ManagerFullName());
            theManagerApprovalPage.clickOnSubmitForManagerApprovalButton();
            theDashboardPage.waitForDashboardPageToLoad();

            //Set User to manager
            theDashboardPage.clickOnUserCircle();
            theDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.ManagerUserName());
            theDashboardPage.clickOnChangeTheUserBtn();

            //Check contact in manager dashboard page
            theManagerDashboardPage.waitForPageToLoad();
            string contactName = theManagerDashboardPage.getContactText();
            Assert.IsTrue(contactName.Contains(ConfigurationWrapper.ContactUserName()), contactName + " does NOT contain contact's username");       
            theManagerDashboardPage.clickOnSkillsLicenceContact();

            //Approve the SKills Licence via Show Manager SL Page
            theShowManagerSkillsLicencePage.waitForPageToLoad();
            theShowManagerSkillsLicencePage.clickOnApproveSkillsLicenceButton();

            //Set User back to salesperson
            theManagerDashboardPage.waitForPageToLoad();
            theManagerDashboardPage.clickOnUserCircle();
            theManagerDashboardPage.populateUserFreeTextBox(ConfigurationWrapper.SalespersonUserName());
            theManagerDashboardPage.clickOnChangeTheUserButton();

            theDashboardPage.waitForDashboardPageToLoad();

            // Check Approved Skills Licence Count increased by 1
            int expectedValue_int = approvedCountSL_int + 1;
            int updatedApprovedCountSL_int = int.Parse(theDashboardPage.getApprovedCount_SL() );

            Assert.IsTrue(updatedApprovedCountSL_int == expectedValue_int,
                "Expected approvedCountSL= " + expectedValue_int + " actually got " + updatedApprovedCountSL_int);
            
        }

    }
}
