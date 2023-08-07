using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace OnlinerProject.utilities;

public class Base
{
    public IWebDriver driver;
    public ExtentReports extent;
    public ExtentTest test;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        string reportPath = projectDirectory + "//index.html";
        var htmlReporter = new ExtentHtmlReporter(reportPath);
        extent = new ExtentReports();
        extent.AttachReporter(htmlReporter);
        extent.AddSystemInfo("Username: ", "Buiukbek");
        extent.AddSystemInfo("Environment : ", "Production");
        extent.AddSystemInfo("Hostname : ", "Localhost");
        
    }
    
    [SetUp]
    public void Setup()
    {
        test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver = new ChromeDriver();
        
        driver.Manage().Window.Maximize();
        driver.Url = "https://www.onliner.by/";
    }

    public IWebDriver getDriver()
    {
        return driver;
    }

    [TearDown]
    public void TearDown()
    {
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = TestContext.CurrentContext.Result.StackTrace;
        DateTime time=DateTime.Now;
        string filename = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
        if (status==TestStatus.Failed)
        {
            test.Fail("Test failed", captureScreenShot(driver, filename));
            test.Log(Status.Fail, "test failed with logtrace" + stackTrace);
        }
        else if (status==TestStatus.Passed)
        {
            test.Pass("Test passed");
        }
        //extent.Flush();
        driver.Quit();
    }

    public MediaEntityModelProvider captureScreenShot(IWebDriver driver, string screenShotName)
    {
        ITakesScreenshot ts = (ITakesScreenshot)driver;
        var screenshot = ts.GetScreenshot().AsBase64EncodedString;
        return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenShotName).Build();
    }
}