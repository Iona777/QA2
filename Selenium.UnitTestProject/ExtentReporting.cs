using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Runtime.Remoting.Contexts;

namespace Selenium.UnitTestProject
{
    public static class ExtentReporting
    {

        public static ExtentReports report;

        public static ExtentReports CreateHTMLReport()
        {
            //Using the @ symbol avoid need to use \ escape character in path
            //consider changing path to equivalent of @C:\TFS\Branches\SPVersion_3_0\Corp.QC.WebUI\Selenium.UnitTestProject\testreport.html
            //using relative paths
            
            string reportPath = @"C:\TFS\Branches\SPVersion_3_0\Corp.QC.WebUI\Selenium.UnitTestProject\Reports\testReport.html";

            ExtentReports myExtentReports = new ExtentReports();
            ExtentHtmlReporter myHTMLReporter = new ExtentHtmlReporter(reportPath);
            myExtentReports.AttachReporter(myHTMLReporter);

            return myExtentReports;
        }

        public static void InitTestSuite(Context testContext)
        {
            //ClassInitialize needs this testContent variable
            var context = testContext;
            // Creates a new ExtentReport
            report = CreateHTMLReport();
        }
    }
}
