
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;

namespace OnlinerProject.utilities
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\results\";

            if (extentReports==null)
            {
                Directory.CreateDirectory(path);
                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);
                
                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }
        
        public static void CreateTest(string TestName)
        {
            extentTest = StartReporting().CreateTest(TestName);
        }

        public static void EndReporting()
        {
            StartReporting().Flush();
        }
        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }
        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }
        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }   
}