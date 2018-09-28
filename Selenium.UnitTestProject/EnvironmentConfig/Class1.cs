using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace Selenium.UnitTestProject.EnvironmentConfig
{
    class environmentConfig
    {

        //note in order for the App.config file to pick up the correct environment variable
        //you need to add it in here first with the same name so it can get picked up

        //------------QC Environments-------------------

        //Password gets around the initial AD login popup on Staging
        public static String UrlNoPasswordStaging()
        {
            String UrlNoPasswordStaging = "http://10.20.23.56/Home/ShowDashboard#/";
            return UrlNoPasswordStaging;
        }

        //NoPassword version in case the AD login popup isn't a problem in future
        public static String UrlPasswordStaging()
        {
            String UrlPasswordStaging = "http://bmarshall:Weekend30@10.20.23.56/Home/ShowDashboard#/";
            return UrlPasswordStaging;
        }

        //Password gets around the initial AD login popup on Staging
        public static String UrlPassword29Staging()
        {
            String UrlPassword29Staging = "http://bmarshall:Weekend30@10.20.23.72/Home/ShowDashboard#/";
            return UrlPassword29Staging;
        }

        
        public static String UrlNoPassword28Staging()
        {
            String UrlNoPassword28Staging = "http://10.20.23.56:28100/Home/ShowDashboard#/";
            return UrlNoPassword28Staging;
        }

        //NoPassword version in case the AD login popup isn't a problem in future
        public static String UrlPassword28Staging()
        {
            String UrlPassword28Staging = "http://bmarshall:Weekend30@10.20.23.56:28001/Home/ShowDashboard#/";
            return UrlPassword28Staging;
        }

        //Live URL - note no AD password prompt
        public static String UrlLive()
        {
            String UrlLive = "http://sp.qa.com";
            return UrlLive;
        }

        //Live URL for 2.8 release - note no AD password prompt
        public static String Url2Live()
        {
            String UrlLive2 = "http://sp2.qa.com";
            return UrlLive2;
        }

        //Live URL for 2.9 merged database release - note no AD password prompt
        public static String Url3Live()
        {
            String UrlPasswordMerged29Staging = "http://bmarshall:Weekend30@10.20.23.78/Home/ShowDashboard#/";
            return UrlPasswordMerged29Staging;
        }

        // ----------------------MyQA Environments--------------------

        public static String MyQAAccountLogin()
        {
            String MyQAAccountLogin = "https://www.qa.com/account/login";
            return MyQAAccountLogin;
        }

        // ----------------------PSP Environments--------------------

        public static String PSPLive()
        {
            String PSPLive = "http://psp/Courses";
            return PSPLive;
        }

    }
}
