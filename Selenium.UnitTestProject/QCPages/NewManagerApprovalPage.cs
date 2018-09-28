using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.WebDriverManager;
using Selenium.UnitTestProject.CommonMethods;
using NUnit.Framework;

namespace Selenium.UnitTestProject.QCPages
{
    class NewManagerApprovalPage
    {
        //Constructor
        public NewManagerApprovalPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Webelements
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/h2")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='approval']/div[2]/div[1]/div[2]/ul/li[2]/span[1]/span[1]/i")]
        IWebElement managerButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='approval']/div[2]/div[1]/div[2]/ul/li[3]/span/span[2]/i")]
        IWebElement anotherManagerButton;

        [FindsBy(How = How.Id, Using = "alt_manager")]
        IWebElement anotherManagerDropdown;

        [FindsBy(How = How.Id, Using = "Save_Submit_To_Manager_link")]
        IWebElement submitForManagerApprovalButton;
                
        
        //Methods
        public string getHeaderText()
        {
            return header.Text;
        }

        
        public void clickOnManagerButton()
        {
            DataEntryHelper.ClickOn(managerButton);   
        }

        //Select the first manager in the dropdown list
        public void selectFirstManager()
        {
            DataEntryHelper.SelectElementByIndex(anotherManagerDropdown, 1);
        }

        public void selectAnotherManager(string managerToSelect)
        {
            DataEntryHelper.SelectElementByText(anotherManagerDropdown,managerToSelect);
        }

        public void clickOnSubmitForManagerApprovalButton()
        {
            DataEntryHelper.ClickOn(submitForManagerApprovalButton);
        }

        public void waitForPageToLoad()
        {


            for (int i = 0; i < 2; i++)
            {
                try
                {
                    MyDriverManager.waitForElement(header);
                    break;
                }
                catch (Exception e)
                {

                    //this should loop back and try again if it fails to find the element
                }
            }
            string actualText = getHeaderText();
            Assert.IsTrue(actualText.Equals("MANAGER APPROVAL"), actualText + "'does NOT equal MANAGER APPROVAL'" );

        }
    }
}
