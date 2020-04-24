using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SpecflowBDD.Utilities;
using NUnit.Framework;

namespace SpecflowBDD.BaseTest
{
    public class TestBase
    {
        protected static IWebDriver driver;
        protected static WebDriverWait wait;
        public static string browser;
        public static string url;

        private ScreenshotUtil ScreenshotUtil { get; set; }
        internal void InitializeTest()
        {
            ReportUtil.AddTestcaseDetailsToExtentReport();
            browser = ConfigurationManager.AppSettings["Browser"].ToLower();
            url = ConfigurationManager.AppSettings["URL"];
            switch (browser)
             {
                 case "chrome":
                     driver = new ChromeDriver();
                     break;
                 case "firefox":
                     driver = new FirefoxDriver();
                     break;
                 case "ie":
                     driver = new InternetExplorerDriver();
                     break;
                 default:
                     throw new Exception("Browser name is not properly mentioned in the App.config file.");
             }
            driver.Manage().Window.Maximize();
            driver.Url = url;
            int waitTime = Convert.ToInt32(ConfigurationManager.AppSettings["WaitTime"]);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            ScreenshotUtil = new ScreenshotUtil(driver);
        }
        internal void CleanupTest()
        {
            try
            {
                TakeScreenshotForTestFailure();
            }
            finally
            {
                driver.Quit();
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if(ScreenshotUtil != null)
            {
                ScreenshotUtil.CreateScreenshotIfTestFailed();
                ReportUtil.ReportTestOutcome( ScreenshotUtil.ScreenshotFilePath);
            }
            else
            {
                ReportUtil.ReportTestOutcome("");
            }
        }

    }
}
