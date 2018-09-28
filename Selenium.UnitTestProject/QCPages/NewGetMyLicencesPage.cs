using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.WebDriverManager;
using Selenium.UnitTestProject.CommonMethods;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Selenium.UnitTestProject.QCPages
{
    class NewGetMyLicencesPage
    {
        //Constructor
        public NewGetMyLicencesPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }


        //Webelements
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/h2")]
        private IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[2]/ul/li[1]/a")]
        private IWebElement blankTemplate;

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div[2]/div[2]/ul/li[2]/a")]
        private IWebElement manageExistingACP;


        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }

        public void clickOnBankTemplate()
        {
            DataEntryHelper.ClickOn(blankTemplate);
        }

        public void clickOnManageExistingACP()
        {
            DataEntryHelper.ClickOn(manageExistingACP);
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

                    //This should return to the loop so it tries again
                }

            }

            string actualHeaderText = getHeaderText();
            Assert.IsTrue(actualHeaderText.Contains("SELECT"), actualHeaderText + "does NOT contain 'SELECT'");
        }



        

    }
}
