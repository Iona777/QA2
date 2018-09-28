using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
//using SeleniumExtras.WaitHelpers; --seems that OpenQA.Selenium.Support.UI can be used instead

using AventStack.ExtentReports;

namespace Selenium.UnitTestProject.WebDriverManager
{
    public static class MyDriverManager
    {
        public static IWebDriver driver;
        public static WebDriverWait wait;
        public static ExtentReports report;


        public static void NewGetWebDriverFromConfig()
        {

            switch (EnvironmentConfig.ConfigurationWrapper.Browser())
            {
                case "FireFox":
                    driver = GetWebDriverFireFox();
                    break;
                case "IE":
                    driver = GetWebDriverFireIE();
                    break;
                case "Chrome":
                    driver = GetWebDriverForChrome();
                    break;
                case "Headless":
                    driver = GetHeadlessWebDriverForChrome();
                    break;
                default:
                    throw new Exception("Unknown browser:" + EnvironmentConfig.ConfigurationWrapper.Browser());

            }

            driver.Manage().Window.Maximize();
            //EXTENT
            report = ExtentReporting.CreateHTMLReport();



        }









        public static IWebDriver GetWebDriverFromConfig()
        {

            
            IWebDriver driver;
            switch (EnvironmentConfig.ConfigurationWrapper.Browser())
            {
                case "FireFox":
                    driver = GetWebDriverFireFox();
                    break;
                case "IE":
                    driver = GetWebDriverFireIE();
                    break;
                case "Chrome":
                    driver = GetWebDriverForChrome();
                    break;
                case "Headless":
                    driver = GetHeadlessWebDriverForChrome();
                    break;
                default:
                    throw new Exception("Unknown browser:" + EnvironmentConfig.ConfigurationWrapper.Browser());

            }


            

            driver.Manage().Window.Maximize();

           
            driver.Url = EnvironmentConfig.ConfigurationWrapper.GetURLFromEnvironmentKey();
            return driver; //???? Just kept in to stop existing tests from failing to complile. Can be taken out once refactoring done
        }

        public static void goToDashboardPage()
        {
            string target = EnvironmentConfig.ConfigurationWrapper.GetURLFromEnvironmentKey();
            navigateTo(target);
        }


        public static void navigateTo(string target)
        {
            driver.Navigate().GoToUrl(target);
        }

        public static void waitForElementByXpath(string elementLoc)
        {
            int timeToWait = EnvironmentConfig.ConfigurationWrapper.WebDriverTimeout();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => driver.FindElement(By.XPath(elementLoc)));
        }

        //Override that returns the element waited for
        public static IWebElement waitForAndReturnElementByXpath(string elementLoc)
        {
            int timeToWait = EnvironmentConfig.ConfigurationWrapper.WebDriverTimeout();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(driver => driver.FindElement(By.XPath(elementLoc)));
            IWebElement ele = driver.FindElement(By.XPath(elementLoc));
            return ele;
        }

        public static void waitForElement(IWebElement element)
        {
            int timeToWait = EnvironmentConfig.ConfigurationWrapper.WebDriverTimeout();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public static void waitForElementToDisappearByXpath(string elementLoc)
        {
            int timeToWait = EnvironmentConfig.ConfigurationWrapper.WebDriverTimeout();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(elementLoc)));

        }

        private static IWebDriver GetWebDriverForChrome()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            return driver;
        }
        private static IWebDriver GetHeadlessWebDriverForChrome()
        {
            IWebDriver driver;
            driver = new ChromeDriver();
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            return driver;
        }
        private static IWebDriver GetWebDriverFireFox()
        {
            IWebDriver driver;
            driver = new FirefoxDriver();
            return driver;
        }

        private static IWebDriver GetWebDriverFireIE()
        {
            IWebDriver driver;
            driver = new InternetExplorerDriver();
            return driver;
        }

        public static void pause(int time)
        {
            Thread.Sleep(time);
        }

        public static void cleanUp()
        {
            report.Flush();
            driver.Quit();
        }
    }
}
