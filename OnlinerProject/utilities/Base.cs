using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

namespace OnlinerProject.utilities;

public class Base
{
    //public IWebDriver driver;
    public ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


    [SetUp]
    public void Setup()
    {
        ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
        
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
        driver.Value = new ChromeDriver();
        
        driver.Value.Manage().Window.Maximize();
        driver.Value.Url = "https://www.onliner.by/";
    }

    public IWebDriver getDriver()
    {
        return driver.Value;
    }

    [TearDown]
    public void TearDown()
    {
        EndTest();
        ExtentReporting.EndReporting();
        driver.Value.Quit();
    }
    
    private void EndTest()
    {
        var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
        var message = TestContext.CurrentContext.Result.Message;
        switch (testStatus)
        {
            case TestStatus.Failed:
                ExtentReporting.LogFail($"Test has failed {message}");
                break;
            case TestStatus.Skipped:
                ExtentReporting.LogInfo($"Test skipped {message}");
                break;
            default:
                break;  
        }
        ExtentReporting.LogScreenshot("End test", GetScreenshot());
    }
    
    public string GetScreenshot()
    {
        var file = ((ITakesScreenshot)driver.Value).GetScreenshot();
        var img = file.AsBase64EncodedString;

        return img;
    }
    
}