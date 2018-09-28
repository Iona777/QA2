using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.UnitTestProject.WebDriverManager;
using Selenium.UnitTestProject.CommonMethods;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using NUnit.Framework;

namespace Selenium.UnitTestProject.QCPages
{
    class NewDashBoardWithMeApprovedPage
    {
        //Constructor
        public NewDashBoardWithMeApprovedPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Webelements
        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/div/h2")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div/table/tbody/tr[1]/td[1]/a/span[1]")]
        IWebElement ApprovedLicence;

        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div/table/tbody/tr[1]/td[7]/a/span")]
        IWebElement SuspendButton;



        
        


        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }


        public void clickOnSuspendButton()
        {
            DataEntryHelper.ClickOn(SuspendButton);
        }

        public void waitForPageToLoad()
        {

            for (int i = 0; i < 2; i++)
            {
                try
                {
                    MyDriverManager.waitForElement(header);
                }
                catch (Exception e)
                {

                    //This should loop back to try again
                }
            }

            string actualHeaderText = getHeaderText();
            Assert.IsTrue(actualHeaderText.Contains("APPROVED SKILLS LICENCES"), actualHeaderText + "does NOT contain 'APPROVED SKILLS LICENCES'");

        }
    }
}
