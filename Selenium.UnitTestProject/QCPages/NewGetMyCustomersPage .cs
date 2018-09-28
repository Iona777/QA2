using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.WebDriverManager;
using Selenium.UnitTestProject.CommonMethods;
using NUnit.Framework;


namespace Selenium.UnitTestProject
{
    class NewGetMyCustomersPage
    {

        //Constructor
        public NewGetMyCustomersPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //WebElements
        [FindsBy(How = How.CssSelector, Using ="#selected")]
        private IWebElement customerSearchBox;

        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[2]/h2")]
        private IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='reducing']/ul/li[1]/a/span[7]/div")]
        private IWebElement customerSelectButton;


        //Methods
        public string getHeaderText()
        {

            return header.Text;
        }


        public void selectCustomerByNumber(string customerNumber)
        {
            string numberLocatorString = "//*[contains(text(),'" + customerNumber + "')]";

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    MyDriverManager.pause(1500);
                    IWebElement theCustomerNumber = 
                        MyDriverManager.driver.FindElement(By.XPath(numberLocatorString));
                    DataEntryHelper.ClickOn(theCustomerNumber);
                    break;
                }

                catch (Exception e)
                {
                    //This should allow the for loop to continue so it tries again
                }
            }


        }




        public void populateCustomerSearchBox(string input)
        {
            DataEntryHelper.EnterText(input, customerSearchBox);
        }

        public void clickOnCustomerSelectButton()
        {
            DataEntryHelper.ClickOn(customerSelectButton);
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
            string actualHeaderText = getHeaderText();
            Assert.IsTrue(actualHeaderText.Contains("SELECT COMPANY"), actualHeaderText + " doesn't contain 'SELECT COMPANY'");

        }

    }
}
