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
    class NewSendToCustomerPage
    {

        //Constructor
        public NewSendToCustomerPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #region webelements
        //WebElements
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[1]/h2")]
        IWebElement header;

        [FindsBy(How = How.XPath, Using = "//*[@id='how_to_send']/label[1]/div[2]/span")]
        IWebElement SendUsingPortalButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='how_to_send']/label[2]/div[2]/span")]
        IWebElement SendUsingAdobeSignButton;


        //NOTE: The relative Xpath for CreateInBAPS is different depending on whether you are sending a 
        //Skills Licence or an ACP, hence 2 different IWebElements. 
        //Also note that the Xpath is the same for SendUsingAdobeSignButton and ACPCreateInBAPSButton
        [FindsBy(How = How.XPath, Using = "//*[@id='how_to_send']/label[3]/div[2]/span/i")]
        IWebElement SKillsLicenceCreateInBAPSButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='how_to_send']/label[2]/div[2]/span/i")]
        IWebElement ACPCreateInBAPSButton;

        [FindsBy(How = How.Id, Using = "email_body")]
        IWebElement emailTextBody;

        [FindsBy(How = How.Id, Using = "portal_notes")]
        IWebElement portalNotesTextBody;

        [FindsBy(How = How.XPath, Using = "//*[@id='btn_CustomerApproval_SendPortal']/span[1]")]
        IWebElement SendToCustomerButton_Portal;


        [FindsBy(How = How.XPath, Using = "//*[@id='btn_CustomerApproval_SendAdobeSign']/span[1]")]
        IWebElement SendToCustomerButton_Adobe;
        

        [FindsBy(How = How.XPath, Using = "//*[@id='btn_CustomerApproval_SendBAPS']/span[1]")]
        IWebElement SendToCustomerButton_BAPS;

        

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[3]/div[1]/h2")]
        IWebElement subHeadingPortal;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/div[1]/h2")]
        IWebElement subHeadingAdobe;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[5]/div[1]/h2")]
        IWebElement subHeadingBAPS_SL;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/div[1]/h2")]
        IWebElement subHeadingBAPS_ACP;

        //Adobe Quotes
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/div[2]/div[1]/div")]
        IWebElement adobeCheckBoxQuoteA;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/div[2]/div[1]/div[2]")]
        IWebElement adobeCheckBoxQuoteB;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[4]/div[2]/div[1]/div[3]")]
        IWebElement adobeCheckBoxQuoteC;



        //BAPS Quotes
        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[5]/div[2]/div/div[1]")]
        IWebElement bapsCheckBoxQuoteA;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[5]/div[2]/div/div[2]")]
        IWebElement bapsCheckBoxQuoteB;

        [FindsBy(How = How.XPath, Using = "//*[@id='main']/div[5]/div[2]/div/div[3]")]
        IWebElement bapsCheckBoxQuoteC;

        #endregion


        //Methods
        #region get subheading text
        public string getsubHeadingPortalText()
        {
            return subHeadingPortal.Text;
        }


        public string getsubHeadingAdobeText()
        {
            return subHeadingAdobe.Text;
        }

        public string getsubHeadingBAPS_SLText()
        {
            return subHeadingBAPS_SL.Text;
        }

        public string getsubHeadingBAPS_ACPText()
        {
            return subHeadingBAPS_ACP.Text;
        }

        #endregion

        public string getHeaderText()
        {
            return header.Text;
        }

        public void clickOnSendUsingPortalButton()
        {
            DataEntryHelper.ClickOn(SendUsingPortalButton);   
        }

        public void clickOnSendUsingAdobeSignButton()
        {
            DataEntryHelper.ClickOn(SendUsingAdobeSignButton);
        }

        public void clickOnSkillsLicenceCreateInBAPSbutton()
        {
            DataEntryHelper.ClickOn(SKillsLicenceCreateInBAPSButton);
        }

        public void clickOnACPCreateInBAPSbutton()
        {
            DataEntryHelper.ClickOn(ACPCreateInBAPSButton);
        }


        public void clickOnAdobeCheckBoxQuoteA()
        {
            DataEntryHelper.ClickOn(adobeCheckBoxQuoteA);
        }

        public void clickOnAdobeCheckBoxQuoteB()
        {
            DataEntryHelper.ClickOn(adobeCheckBoxQuoteB);
        }


        public void clickOnAdobeCheckBoxQuoteC()
        {
            DataEntryHelper.ClickOn(adobeCheckBoxQuoteC);
        }


        public void clickOnBapsCheckBoxQuoteA()
        {
            DataEntryHelper.ClickOn(bapsCheckBoxQuoteA);
        }

        public void clickOnBapsCheckBoxQuoteB()
        {
            DataEntryHelper.ClickOn(bapsCheckBoxQuoteB);
        }

        public void clickOnBapsCheckBoxQuoteC()
        {
            DataEntryHelper.ClickOn(bapsCheckBoxQuoteC);
        }

        public string getEmailTextBody()
        {
            return emailTextBody.Text;
        }

        public void populateEmailTextBody(string input)
        {
            DataEntryHelper.EnterText(input, emailTextBody);
        }

        public void populatePortalNotesTextBody(string input)
        {
            DataEntryHelper.EnterText(input, portalNotesTextBody);
        }

        public void clickOnSendtoCustomerButton_Portal()
        {
            DataEntryHelper.ClickOn(SendToCustomerButton_Portal);
        }

        public void clickOnSendtoCustomerButton_Adobe()
        {
            DataEntryHelper.ClickOn(SendToCustomerButton_Adobe);
        }

        public void clickOnSendtoCustomerButton_BAPS()
        {
            DataEntryHelper.ClickOn(SendToCustomerButton_BAPS);
        }

        public void waitForPageToLoadSkillsLicence()
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
            Assert.IsTrue(actualHeaderText.Contains("SEND SKILLS LICENCE TO CUSTOMER"), actualHeaderText + "does NOT contain 'SEND SKILLS LICENCE TO CUSTOMER'");

        }

        public void waitForPageToLoadacp()
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
            Assert.IsTrue(actualHeaderText.Contains("SEND CUSTOMER ADVANCED PRICING TO CUSTOMER"), actualHeaderText + "does NOT contain 'SEND CUSTOMER ADVANCED PRICING TO CUSTOMER'");

        }

    }
}
