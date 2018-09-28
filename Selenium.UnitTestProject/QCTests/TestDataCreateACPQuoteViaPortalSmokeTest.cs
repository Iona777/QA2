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

namespace Selenium.UnitTestProject
{
    
    [TestFixture]
   
    class CreateACPQuotePortal : Hooks //Inherit the SetUp and TearDown from Hooks class.
    {         
 
        [Test]
        //This test creates a self-approved licence and returns user to dashboard
        public void CreateAdvancedCustomerPricingQuoteViaPortalSmokeTest()
        {
            //Setup reporting for this test           
            ExtentTest test = MyDriverManager.report.CreateTest("CreateAdvancedCustomerPricingQuoteViaPortalSmokeTest");

            //Constants
            string customerCompanyName      = "TEST QC CUSTOMER";
            string customerNumber           = "3402211";
            string contactSurname           = "Marshall";
            string customerEmailAddress     = "newtestaccount1@qa.com";
            

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

            //Get Initial Approved ACP Count
            string approvedCountACP = theDashboardPage.getApprovedCount_ACP();
            int approvedCountACP_int = int.Parse(approvedCountACP);
            
            //Select ACP
            theDashboardPage.clickOnManageCustomerContractPricingButton();

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
            theGetMyLicencesPage.clickOnManageExistingACP();
            
            theAlterSkillsLicencePage.waitForPageToLoad();

            //Check correct text displayed for New Customer Check Box for both ticked and unticked conditions
            string actualTickBoxUntickedText = theAlterSkillsLicencePage.getNewCustomerCheckBoxUntickedText();
            try
            {
                Assert.IsTrue(actualTickBoxUntickedText.Equals("Additional discounts for being a new customer not applied"),
                actualTickBoxUntickedText + " does NOT equal 'Additional discounts for being a new customer not applied'");
            }
            catch (Exception e )
            {
                //Set reporting info
                test.Fail("Tickbox unticked text does NOT equal 'Additional discounts for being a new customer not applied");
                test.Log(Status.Fail, "CreateAdvancedCustomerPricingQuoteViaPortalSmokeTest Failed");
                throw;
            }
            

            theAlterSkillsLicencePage.clickOnNewCustomerCheckboxUnticked();
            theAlterSkillsLicencePage.clickOnYesToNewCustomerDiscountsPopUp();
                        
            string actualTickBoxTickedText = theAlterSkillsLicencePage.getNewCustomerCheckBoxTickedText();
            Assert.IsTrue(actualTickBoxTickedText.Equals("Additional discounts for being a new customer applied"),
                actualTickBoxTickedText + " does NOT equal 'Additional discounts for being a new customer applied'");


            //Enter ACP Details
            theAlterSkillsLicencePage.enterAmazonAsVendor();
            Assert.IsTrue(theAlterSkillsLicencePage.isTechTypeAmazonSpecialistDisplayed(), "Tech Type Specialist not displayed for vendor Amazon");
            theAlterSkillsLicencePage.clickOnSaveAndSendButton();

            //Send ACP to customer via Portal
            theSendToCustomerPage.waitForPageToLoadacp();
            theSendToCustomerPage.clickOnSendUsingPortalButton();
            Assert.IsTrue(theSendToCustomerPage.getsubHeadingPortalText().Equals("PORTAL"),"Portal Subheading does NOT equal 'Portal' ");
            theSendToCustomerPage.clickOnSendtoCustomerButton_Portal();

            theDashboardPage.waitForDashboardPageToLoad();

            //Check Approved ACP Count increased by 1
            int expectedValue_int = approvedCountACP_int + 1;
            int updatedApprovedCountACP_int = int.Parse(theDashboardPage.getApprovedCount_ACP());

            Assert.IsTrue(updatedApprovedCountACP_int ==  expectedValue_int, 
                "Expected ApprovedCountACP= "+ expectedValue_int + " actually got "+ updatedApprovedCountACP_int);

            //Set reporting info
            test.Pass("ACP successfully created via portal");
            test.Log(Status.Pass, "CreateAdvancedCustomerPricingQuoteViaPortalSmokeTest passed");
        }
     }


}
