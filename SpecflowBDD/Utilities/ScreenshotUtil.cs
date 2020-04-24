using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowBDD.Utilities
{
    public class ScreenshotUtil
    {
        private IWebDriver _driver;
        //private TestContext _testContext;
        internal string ScreenshotFilePath { get; set; }
        private string ScreenshotFileName { get; set; }

        public ScreenshotUtil(IWebDriver driver)
        {
            if (driver == null)
                return;
            _driver = driver;
            ScreenshotFileName = TestContext.CurrentContext.Test.Name;
        }

        public void CreateScreenshotIfTestFailed()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            if (testStatus == TestStatus.Failed ||
                testStatus == TestStatus.Inconclusive)
                TakeScreenshotOnFailure();
        }

        public bool TakeScreenshotOnFailure()
        {
            ScreenshotFileName = $"FAIL_{ ScreenshotFileName}";
            var screenshot = GetScreenshot();
            var successfullySaved = TrytoSaveScreenshot(ScreenshotFileName, screenshot);
            if (successfullySaved)
                return successfullySaved;
            else
                return false;
        }

        private bool TrytoSaveScreenshot(string screenshotFileName, Screenshot screenshot)
        {
            try
            {
                SaveScreenshot(screenshotFileName, screenshot);
                return true;
            }
            catch(Exception e)
            {
               return false;
            }
        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();
        }
        private void SaveScreenshot(string screenshotName, Screenshot screenshot)
        {
            if (screenshot == null)
                return;
            ScreenshotFilePath = $"{ ReportUtil.LatestResultReportFolder}\\{screenshotName}.jpg";
            screenshot.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Jpeg);
        }
    }
}
