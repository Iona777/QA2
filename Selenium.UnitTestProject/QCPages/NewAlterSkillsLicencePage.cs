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
    class NewAlterSkillsLicencePage
    {
        //Constructor
        public NewAlterSkillsLicencePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Webelements
        [FindsBy(How = How.XPath, Using = ".//*[@id='dash']/div/dl/dt[1]")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/dl/dd[3]/ul/li[2]/span")]                                           
        IWebElement NewCustomerCheckboxUnticked;

        [FindsBy(How = How.XPath, Using = "//*[@id='dash']/div/dl/dd[3]/ul/li[1]/span")]
        IWebElement NewCustomerCheckboxTicked;

        

        [FindsBy(How = How.Id, Using = "the_main_input")]
        IWebElement quoteATextBox;

        [FindsBy(How = How.Id, Using = "the_alt1_input")]
        IWebElement quoteBTextBox;

        [FindsBy(How = How.Id, Using = "the_alt2_input")]
        IWebElement quoteCTextBox;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[5]/td[5]/span[5]")]                                          
        IWebElement HierarchyWarning;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[1]/th/span[1]/span")]
        IWebElement PracticeSelectIT;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[1]/th/span[3]/span[2]/span")]
        IWebElement AddAllVendorsIT;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[1]/th/span[3]/span[1]/span/span")]
        IWebElement addAVendorIT;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[1]/th/ol/li[2]/span")]
        IWebElement amazonVendor;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[5]/td[1]/span")]
        IWebElement techTypeAmazonSpecialist;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tbody[1]/tr[1]/th/span[3]/span[3]/span/span")]
        IWebElement removeIT;

        [FindsBy(How = How.Id, Using = "saveasdraft_link")]
        IWebElement saveDraftButton;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div/table/tfoot/tr/td[1]/ul/li[1]/a/span[1]")]
        IWebElement saveAndSendButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='sl_cancel']/span[1]")]
        IWebElement CancelACPButton;



        //Methods       
        public string getHeaderText()
        {
            return header.Text;
        }

        public string getNewCustomerCheckBoxTickedText()
        {
            return NewCustomerCheckboxTicked.Text;
        }

        public string getNewCustomerCheckBoxUntickedText()
        {
            return NewCustomerCheckboxUnticked.Text;
        }

        public void clickOnNewCustomerCheckboxUnticked()
        {
            DataEntryHelper.ClickOn(NewCustomerCheckboxUnticked);
        }

        public void clickOnNewCustomerCheckboxTicked()
        {
            DataEntryHelper.ClickOn(NewCustomerCheckboxTicked);

        }

        public void clickOnSaveDraftButton()
        {
            DataEntryHelper.ClickOn(saveDraftButton);
        }

        public void clickOnPracticeSelectIT()
        {
            DataEntryHelper.ClickOn(PracticeSelectIT);
        }

        public void clickOnAddVendorIT()
        {
            DataEntryHelper.ClickOn(addAVendorIT);
        }

        public void clickOnAmazonVendor()
        {
            DataEntryHelper.ClickOn(amazonVendor);
        }

        public Boolean isTechTypeAmazonSpecialistDisplayed()
        {
            return techTypeAmazonSpecialist.Displayed;
        }

        public void enterDiscountForAmazonQuoteA(string input)
        {
            IWebElement AmazonDiscount = MyDriverManager.driver.FindElement(By.XPath("//*[@id='main']/div/table/tbody[1]/tr[5]/td[2]/input"));
            AmazonDiscount.Clear();
            DataEntryHelper.EnterText(input, AmazonDiscount);
            DataEntryHelper.pressTab(AmazonDiscount);

        }

        public void clickOnRemoveIT()
        {
            if (removeIT.Displayed)
            {
                DataEntryHelper.ClickOn(removeIT);
            }

        }

        public void populateQuoteATextBox(string input)
        {
            DataEntryHelper.EnterText(input, quoteATextBox);

        }


        public void populateQuoteBTextBox(string input)
        {
            DataEntryHelper.EnterText(input, quoteBTextBox);
            DataEntryHelper.pressTab(quoteBTextBox);
        }

        public void populateQuoteCTextBox(string input)
        {
            DataEntryHelper.EnterText(input, quoteCTextBox);
            DataEntryHelper.pressTab(quoteCTextBox);
        }


        public void clickOnCancelACPButton()
        {
            DataEntryHelper.ClickOn(CancelACPButton);
        }

        public void clickOnSaveAndSendButton()
        {
            DataEntryHelper.ClickOn(saveAndSendButton);
        }


        public void enterAmazonAsVendor()
        {
            clickOnPracticeSelectIT();
            clickOnRemoveIT();
            clickOnAddVendorIT();
            clickOnAmazonVendor();
        }

        public string getHierarchyWarningText()
        {
            if (HierarchyWarning.Displayed)
            {
                return HierarchyWarning.Text;
            }
            return null;
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
            Assert.IsTrue(actualHeaderText.Contains("IN DRAFT"), actualHeaderText + "does NOT contain 'In Draft'");
          
        }

        public void switchWindowLast()
        {
            MyDriverManager.driver.SwitchTo().Window(MyDriverManager.driver.WindowHandles.Last());
        }

        public void switchWindowFirst()
        {
            MyDriverManager.driver.SwitchTo().Window(MyDriverManager.driver.WindowHandles.First());
        }

        
        public void clickOnYesToNewCustomerDiscountsPopUp()
        {
            //The Yes element cannot be accessed like normal elements because it is in a separate popup window
            //So you need to switch to that windon before you attempt to access it.
            //It won't wait for the element until the switch is complete, so I have used a loop to allow it to try again
            //Once the Yes element has been clicked on, you then need to wait for it to disappear before the focus is back on 
            //the main window.
            
            string yesLocatorString = "//*[@id='toast']/ul/li/span[2]";

            switchWindowLast();
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    IWebElement yes = MyDriverManager.waitForAndReturnElementByXpath(yesLocatorString);
                    DataEntryHelper.ClickOn(yes);
                    
                    MyDriverManager.waitForElementToDisappearByXpath(yesLocatorString);
                    break;
                }
                catch (Exception e)
                {
                    //This should loop back to try again
                    MyDriverManager.pause(1000);
                }
            }
            
        
        }

    }
}
