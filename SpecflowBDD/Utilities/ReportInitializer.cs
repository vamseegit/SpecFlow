using SpecflowBDD.Utilities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowBDD
{
    [Binding]
    public class ReportInitializer
    {
        [BeforeTestRun]
        public static void InitializeExtentReport()
        {
            ReportUtil.StartReporter();
        }
    }
}
