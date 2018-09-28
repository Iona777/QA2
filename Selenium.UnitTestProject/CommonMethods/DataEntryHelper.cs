using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Selenium.UnitTestProject.WebDriverManager;
using OpenQA.Selenium.Support.UI;



namespace Selenium.UnitTestProject.CommonMethods
{
    class DataEntryHelper
    {
        
        private static SelectElement select;


        public static void EnterText(string input, IWebElement element)
        {
            MyDriverManager.waitForElement(element);
            element.SendKeys(input);

        }

        public static void ClickOn(IWebElement element)
        {
            MyDriverManager.waitForElement(element);
            element.Click();
        }

        public static void pressTab(IWebElement element)
        {
            element.SendKeys(Keys.Tab);
        }

        public static void SelectElementByText(IWebElement element, string visibletext)
        {
            select = new SelectElement(element);
            select.SelectByText(visibletext);
        }

        public static void SelectElementByIndex(IWebElement element, int index)
        {
            select = new SelectElement(element);
            select.SelectByIndex(index);
        }
    }
}
