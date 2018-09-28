using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.CommonMethods;
using Selenium.UnitTestProject.WebDriverManager;
using NUnit.Framework;

namespace Selenium.UnitTestProject.QCPages
{
    class NewDashboardPage
    {
        //Constructor
        public NewDashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #region webelements
        //WebElements
        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/div/h2")]
        private IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='menu']/span")]
        private IWebElement sideMenuArrow;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/div/h2")]
        private IWebElement skillsLicenceHeader;

        //Skills Licence/ACP Counts
        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[2]/td[2]")]
        private IWebElement draftCount_SL;

        
        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[3]/td[2]")]
        private IWebElement approvedCount_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[4]/td[2]")]
        private IWebElement suspendedCount_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[5]/td[2]")]
        private IWebElement declinedCount_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[2]/tr[2]/td[2]")]
        private IWebElement awaitingApprovalCount_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[2]/tr[4]/td[2]")]
        private IWebElement withCustomerCount_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[3]/tr[2]/td[2]")]
        private IWebElement bookingProvisional_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[3]/tr[3]/td[2]")]
        private IWebElement bookingConfirmed_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[3]/tr[4]/td[2]")]
        private IWebElement bookingInvoiced_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[1]/td[2]")]
        private IWebElement draftCount_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[2]/td[2]")]
        private IWebElement approvedCount_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[3]/td[2]")]
        private IWebElement declinedCount_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[2]/tr[2]/td[2]")]
        private IWebElement awaitingApprovalCount_ACP;




        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[2]/td[1]/a/span")]
        private IWebElement draft_SL;


        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[1]/tr[3]/td[1]/a/span")]
        private IWebElement approved_SL;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div[1]/table/tbody[1]/tr[4]/td[1]/a/span")]
        private IWebElement approvedButSuspended_SL;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div[1]/table/tbody[1]/tr[5]/td[1]/a/span")]
        private IWebElement declined_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[2]/tr[2]/td[1]/a/span")]
        private IWebElement awaitingApproval_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody[2]/tr[4]/td[1]/a/span")]
        private IWebElement AllSkillsLicencesWithCustomers;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/ul/li/a/span[1]")]
        private IWebElement createSkillsLicenceButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='base']/ul/li[2]/span[1]/i")]
        private IWebElement userCircle;

        [FindsBy(How = How.XPath, Using = "//*[@id='userCode']")]
        private IWebElement changeUserFreeTextBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='menu']/div/ul/li[3]/form/div/ul/li/label/span[1]")]
        private IWebElement changeTheUserButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[1]/td[1]/a/span")]
        private IWebElement Drafts_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[2]/td[1]/a/span")]
        private IWebElement Approved_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[1]/tr[3]/td[1]/a/span")]
        private IWebElement Declined_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/table/tbody[2]/tr[2]/td[1]/a/span")]
        private IWebElement AwaitingApproval_ACP;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[3]/ul/li/a/span[1]")]
        private IWebElement manageCustomerContractPricingButton;

        #endregion

        //Methods
        public string getHeaderText()
        {

            return header.Text;
        }

        //Get Counts
        public string getDraftCount_SL()
        {
            return draftCount_SL.Text;
        }

        public string getApprovedCount_SL()
        {
            return approvedCount_SL.Text;
        }

        public string getSuspendedCount_SL()
        {
            return suspendedCount_SL.Text;
        }

        public string getDeclinedCount_SL()
        {
            return declinedCount_SL.Text;
        }

        public string getAwaitingApprovalCount_SL()
        {
            return awaitingApprovalCount_SL.Text;
        }

        public string getWithCustomerCount_SL()
        {
            return withCustomerCount_SL.Text;
        }


        public string getBookingProvisional_SL()
        {
            return bookingProvisional_SL.Text;
        }

        public string getBookingConfirmed_SL()
        {
            return bookingProvisional_SL.Text;
        }

        public string getBookingInvoiced_SL()
        {
            return bookingInvoiced_SL.Text;
        }

        public string getDraftCount_ACP()
        {
            return draftCount_ACP.Text;
        }

        public string getApprovedCount_ACP()
        {
            return approvedCount_ACP.Text;
        }

        public string getDeclinedCount_ACP()
        {
            return declinedCount_ACP.Text;
        }

        public string getAwaitingApprovalCount_ACP()
        {
            return awaitingApprovalCount_ACP.Text;
        }


        public void clickOnSideMenuArrow()
        {
            DataEntryHelper.ClickOn(sideMenuArrow);
            
        }

        public void clickOnDraft_SL()
        {
            DataEntryHelper.ClickOn(draft_SL);
        }

        public void clickOnApproved_SL()
        {
            DataEntryHelper.ClickOn(approved_SL);
        }

        public void clickOnApprovedButSuspended_SL()
        {
            DataEntryHelper.ClickOn(approvedButSuspended_SL);
        }

        public void clickOnDeclined_SL()
        {
            DataEntryHelper.ClickOn(declined_SL);
        }

        public void clickOnAwaitingApproval_SL()
        {
            DataEntryHelper.ClickOn(awaitingApproval_SL);
        }

        public void clickOnAllSkillsLicencesWithCustomers()
        {
            DataEntryHelper.ClickOn(AllSkillsLicencesWithCustomers);
        }

        public void clickOnUserCircle()
        {
            DataEntryHelper.ClickOn(userCircle);
        }

        public void populateUserFreeTextBox(string input)
        {
            DataEntryHelper.EnterText(input, changeUserFreeTextBox);
        }


        public void clickOnChangeTheUserBtn()
        {
            DataEntryHelper.ClickOn(changeTheUserButton);
        }

        public void clickOnCreateSkillsLicenceButton()
        {
            DataEntryHelper.ClickOn(createSkillsLicenceButton);
        }

        public void clickOnManageCustomerContractPricingButton()
        {
            DataEntryHelper.ClickOn(manageCustomerContractPricingButton);
        }

        public void waitForDashboardPageToLoad()
        {
            //Waits for the time specified in AppConfig for the header to appear (currently 20 seconds)
            //To allow for slow performance, it will try twice before failing.
            for (int i = 0; i < 2; i++)
            {
                try
                {
                    MyDriverManager.waitForElement(header);
                    break;
                }

                catch (Exception e)
                {
                    //This should allow the for loop to continue so it tries again
                }
            }
            string actualDashboardHeaderText = getHeaderText();
            Assert.IsTrue(actualDashboardHeaderText.Contains("SKILLS LICENCES"), actualDashboardHeaderText + " doesn't contain 'SKILLS LICENCES'");

        }

        

    }
}
