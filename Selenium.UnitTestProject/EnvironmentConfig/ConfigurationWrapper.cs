using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Selenium.UnitTestProject.EnvironmentConfig
{
    public static class ConfigurationWrapper
    {

        //NEW METHODS
        public static string GetEnvironmentFromConfig()
        {
            return (GetValueFromConfigKey("Environment"));
        }


      

        //********************************************


        public static string GetURLFromEnvironmentKey()
        {
            return GetValueFromConfigKey(GetValueFromConfigKey("Environment"));
        }
        public static string Environment()
        {
            return GetValueFromConfigKey("Environment");
        }
        public static string ManagerUserName()
        {
            return GetValueFromConfigKey("ManagerUserName");
        }

        public static string ManagerFullName()
        {
            return GetValueFromConfigKey("ManagerFullName");
        }
        

        public static string SalespersonUserName()
        {
            return GetValueFromConfigKey("SalespersonUserName");
        }
        public static string ContactUserName()
        {
            return GetValueFromConfigKey("ContactUserName");
        }
        public static int WebDriverTimeout()
        {
            return Convert.ToInt32(GetValueFromConfigKey("WebDriverTimeout"));
        }

        public static string Browser()
        {
            return GetValueFromConfigKey("Browser");
        }
        
        public static string UrlPasswordStaging()
        {
            return GetValueFromConfigKey("UrlPasswordStaging");
        }

        public static string UrlPassword29Staging()
        {
            return GetValueFromConfigKey("UrlPassword29Staging");
        }
        public static string UrlNoPasswordStaging()
        {
            return GetValueFromConfigKey("UrlNoPasswordStaging");
        }
        public static string Live()
        {
            return GetValueFromConfigKey("Live");
        }

        private static string GetValueFromConfigKey(string Key)
        {
            return System.Configuration.ConfigurationManager.AppSettings[Key];
        }

        public static string MyQAAccountLogin()
        {
            return GetValueFromConfigKey("MyQAAccountLogin");
        }

        public static string PSPLiveAccountLogin()
        {
            return GetValueFromConfigKey("PSPLiveAccountLogin");
        }
    }
}
