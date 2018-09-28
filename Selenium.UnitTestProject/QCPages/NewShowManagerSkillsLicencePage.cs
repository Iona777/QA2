using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.CommonMethods;
using Selenium.UnitTestProject.WebDriverManager;


namespace Selenium.UnitTestProject.QCPages
{
    class NewShowManagerSkillsLicencePage : Hooks //Inherit the SetUp and TearDown from Hooks class
    {
        //Constructor
        public NewShowManagerSkillsLicencePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Webelements
        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/dl/dt[1]")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/dl/dd[8]/ul/li[1]/a/span[1]")]
        IWebElement approveSkillsLicenceButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/dl/dd[8]/ul/li[2]/a/span[1]")]
        IWebElement declineSkillsLicenceButton;
        
        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }

        public void clickOnApproveSkillsLicenceButton()
        {
            DataEntryHelper.ClickOn(approveSkillsLicenceButton);
        }

        public void clickOnDeclineSkillsLicenceButton()
        {
            DataEntryHelper.ClickOn(declineSkillsLicenceButton);
        }

        public void waitForPageToLoad()
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
            NUnit.Framework.Assert.IsTrue(actualDashboardHeaderText.Contains("AWAITING APPROVAL"), actualDashboardHeaderText + "does not contain 'AWAITING APPROVAL'");

        }
    }
}
