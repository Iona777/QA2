using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.CommonMethods;
using Selenium.UnitTestProject.WebDriverManager;
using NUnit.Framework;

namespace Selenium.UnitTestProject.QCPages
{
    class NewManagerDashboardPage
    {
        //Constructor
        public NewManagerDashboardPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Webelements
        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div[1]/div/h2")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div[1]/table/tbody/tr[1]/td[1]/a/span[1]")]                                           
        IWebElement SkillsLicenceContact;

        [FindsBy(How = How.XPath, Using = "//*[@id='base']/ul/li[2]/span[1]/i")]
        IWebElement userCircle;

        [FindsBy(How = How.Id, Using = "userCode")]
        IWebElement changeUserFreeTextBox;

        [FindsBy(How = How.XPath,Using = "//*[@id='menu']/div/ul/li[3]/form/div/ul/li/label/span[1]")]
        IWebElement changeTheUserButton;

        
        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }

        public string getContactText()
        {
            return SkillsLicenceContact.Text;
        }

        public void clickOnSkillsLicenceContact()
        {
            DataEntryHelper.ClickOn(SkillsLicenceContact);
        }


        public void clickOnUserCircle()
        {
            DataEntryHelper.ClickOn(userCircle);
        }

            
        public void populateUserFreeTextBox(string input)
        {
            DataEntryHelper.EnterText(input, changeUserFreeTextBox);
        }

        public void clickOnChangeTheUserButton()
        {
            DataEntryHelper.ClickOn(changeTheUserButton);
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
            Assert.IsTrue(actualDashboardHeaderText.Contains("APPROVALS PENDING"), actualDashboardHeaderText + " doesn't contain 'APPROVALS PENDING'");

        }


    }
}
