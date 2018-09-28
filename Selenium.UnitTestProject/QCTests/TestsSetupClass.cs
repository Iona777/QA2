using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Selenium.UnitTestProject.WebDriverManager;

namespace Selenium.UnitTestProject.QCTests
{
    [SetUpFixture]
    public class TestsSetupClass
    {
        [SetUp]
        void GlobalSetup()
        {
            //Do setup stuff from Hooks here
            MyDriverManager.NewGetWebDriverFromConfig();
        }

        [TearDown]
        void GlobalTearDown()
        {
            //Do teardown stuff from Hooks here
            MyDriverManager.cleanUp();
        }

    }
}
