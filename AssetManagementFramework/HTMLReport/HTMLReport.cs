using AssetManagementFramework.APIController;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagementFramework.HTMLReport
{
    public class HTMLReporter
    {
        private static ExtentReports Report { get; set; }

        private static ExtentTest ReportTestClass { get; set; }

        private static ExtentTest ReportTestNode { get; set; }

        public static ExtentReports createReport(string path)
        {
            if (Report == null)
            {
                Report = createInstance(path);
            }
            return Report;
        }
        private static ExtentReports createInstance(string path)
        {
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.DocumentTitle = "HoangQuyDao-Exercise";
            htmlReporter.Config.ReportName = "Automation-Report";
            htmlReporter.Config.Theme = Theme.Standard;
            htmlReporter.Config.Encoding = "UTF-8";

            ExtentReports report = new ExtentReports();
            report.AttachReporter(htmlReporter);
            return report;
        }

        public static ExtentTest createTest(string className, string classDescription = "")
        {
            ReportTestClass = Report.CreateTest(className, classDescription);
            return ReportTestClass;
        }

        public static ExtentTest createNode(string className, string testcase, string description = "")
        {
            if (ReportTestClass == null)
            {
                ReportTestClass = createTest(className);
            }
            ReportTestNode = ReportTestClass.CreateNode(testcase, description);
            return ReportTestNode;
        }
        public static void Pass(string des)
        {
            ReportTestNode.Pass(des);
        }
        public static void Pass(APIRequest request, APIResponse response)
        {
            ReportTestNode.Pass(MarkupHelperPlus.CreateRequestInfor(request, response));
        }
        public static void PassCodeBlockJson(string codeblock)
        {
            ReportTestNode.Pass(MarkupHelper.CreateCodeBlock(codeblock, CodeLanguage.Json));
        }
        public static void Fail(string des)
        {
            ReportTestNode.Fail(MarkupHelper.CreateLabel(des, ExtentColor.Red));
        }
        public static void Fail(string des, string ex, string path = "")
        {
            ReportTestNode.Fail(des).Fail(ex).AddScreenCaptureFromPath(path);
        }
        public static void Fail(string des, string path = "")
        {
            ReportTestNode.Fail(MarkupHelper.CreateLabel(des, ExtentColor.Red)).AddScreenCaptureFromPath(path);
        }
        public static void Info(string des)
        {
            ReportTestNode.Info(des);
        }
        public static void Warning(string des)
        {
            ReportTestNode.Warning(des);
        }
        public static void Skip(string des)
        {
            ReportTestNode.Skip(des);
        }
        public static void Flush()
        {
            Report.Flush();
        }
    }
}
