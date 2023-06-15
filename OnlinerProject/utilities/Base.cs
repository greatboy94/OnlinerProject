using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;

namespace OnlinerProject.utilities;

public class Base
{
    public IWebDriver driver;
    
    [SetUp]
    public void Setup()
    {
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
        driver.Quit();
    }
}