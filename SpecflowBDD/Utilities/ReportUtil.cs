using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using TechTalk.SpecFlow;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecflowBDD.Utilities
{
    public static class ReportUtil
    {
        private static ExtentReports ReportManager { get; set; }
        private static string ExtentReporFulltPath { get; set; }
        internal static ExtentTest ExtentTest { get; set; }
        internal static string LatestResultReportFolder { get; set; }

        public static void StartReporter()
        {
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(ExtentReporFulltPath);
            ReportManager = new ExtentReports();
            ReportManager.AttachReporter(htmlReporter);

        }

        private static void CreateReportDirectory()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.FullName;
            string reporterPath = Path.GetFullPath(projectDirectory + @"\TestReports");
            LatestResultReportFolder = Path.Combine(reporterPath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultReportFolder);
            ExtentReporFulltPath = LatestResultReportFolder + @"\TestResult.html";
        }
        public static void AddTestcaseDetailsToExtentReport()
        {
          //  ExtentTest = ReportManager.CreateTest(TestContext.CurrentContext.Test.Name);
          ExtentTest = ReportManager.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

        }
        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMessage = TestContext.CurrentContext.Result.Message;
            switch (status)
            {
                case TestStatus.Failed:
                    ExtentTest.Log(Status.Fail, "Test Failed <br/>" + errorMessage);
                    ExtentTest.AddScreenCaptureFromPath(screenshotPath);
                    break;
                case TestStatus.Inconclusive:
                    ExtentTest.AddScreenCaptureFromPath(screenshotPath);
                    ExtentTest.Warning("Inconclusive");
                    break;
                case TestStatus.Skipped:
                    ExtentTest.Skip("Test Skipped");
                    break;
                case TestStatus.Passed:
                    ExtentTest.Pass("Test Passed");
                    break;
                default:
                    ExtentTest.Pass("Test Passed");
                    break;
            }
            ReportManager.Flush();
        }
    }
}
