using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Selenium.UnitTestProject.WebDriverManager; //Because MyDriverManager in a separate namespace

namespace Selenium.UnitTestProject
{
    public class Hooks
    {
        [SetUp]
        public void Initialize()
        {
            
            //Consider adding code here so that it sets the environment value in AppConfig so that you can have a suite
            //of tests per environment.
            MyDriverManager.NewGetWebDriverFromConfig();

            
        }

        [TearDown]
        public void EndTest()
        {
            //Write to file
            

            MyDriverManager.cleanUp();
        }
    }
}
