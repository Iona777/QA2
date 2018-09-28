using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium.UnitTestProject.WebDriverManager;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.CommonMethods;
using NUnit.Framework;

namespace Selenium.UnitTestProject.QCPages
{
    class NewGetMyCustomerContactsPage
    {
        //Constructor
        public NewGetMyCustomerContactsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver,this);
        }

        //Locators
        //Change this value depending on the email address of the customer you are using
        
        
        private const string customerEmailLocator = "//*[contains(text(),'newtestaccount1@qa.com')]";

        //Webelements
        [FindsBy(How = How.XPath, Using = ".//*[@id='main']/div[1]/h2")]
        IWebElement header;
        [FindsBy(How = How.CssSelector, Using = "[id='selected']")]
        IWebElement contactsSearchBox;
        [FindsBy(How = How.CssSelector, Using = "[data-the_control_state = 'Delegates shown']")]
        IWebElement delegateButton;
        [FindsBy(How = How.CssSelector, Using = "[data-the_control_state = 'Bookers shown']")]
        IWebElement bookerButton;
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/div/label[3]")]
        IWebElement bothButton;
            //"[name='contact_Type'][value='B']")]

        [FindsBy(How = How.XPath, Using = customerEmailLocator)]
        IWebElement customerEmail;

    

        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }

        public void populateContactsSearchBox(string input)
        {
            DataEntryHelper.EnterText(input, contactsSearchBox);
        }

        
        public void clickOnDelegateButton()
        {
            DataEntryHelper.ClickOn(delegateButton);
        }

        public void clickOnBookerButton()
        {
            DataEntryHelper.ClickOn(bookerButton);
        }

        public void clickOnBothButton()
        {
            DataEntryHelper.ClickOn(bothButton);
        }

        


        public void selectCustomerEmail(string email)
        {
            string emailLocatorString = "//*[contains(text(),'" + email              + "')]";

            for (int i = 0; i < 10; i++)
            {
                try
                {
                    MyDriverManager.pause(1000);
                    IWebElement theCustomerEmail = 
                        MyDriverManager.driver.FindElement(By.XPath(emailLocatorString));
                    DataEntryHelper.ClickOn(theCustomerEmail);
                    break;
                }
                catch (Exception e)
                {

                    //This should allow the for loop to continue so it tries again
                }
            }
            
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
            Assert.IsTrue(actualHeaderText.Contains("SELECT CONTACT"), actualHeaderText + " doesn't contain 'SELECT CONTACT'");

        }


    }
}
    
