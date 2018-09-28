using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Selenium.UnitTestProject.CommonMethods;

namespace Selenium.UnitTestProject.QCPages
{
    class NewHeaderPage
    {
        //Constructor
        public NewHeaderPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);

        }

        //Webelements
        [FindsBy(How = How.XPath, Using = "//*[@id='head']/div[1]/ul/li[3]/span")]
        IWebElement quotationsMenuOption;

        [FindsBy(How = How.XPath, Using = "//*[@id='head']/div[1]/ul/li[3]/ul/li[1]/a")]
        IWebElement salesPortalMenuOption;


        //Methods
        public void clickOnquotationsMenuOption()
        {
            DataEntryHelper.ClickOn(quotationsMenuOption);
        }

        public void clickOnsalesPortalMenuOption()
        {
            DataEntryHelper.ClickOn(salesPortalMenuOption);
        }

    }
}
