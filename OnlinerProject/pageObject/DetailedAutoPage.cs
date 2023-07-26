using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace OnlinerProject.pageObject;

public class DetailedAutoPage
{
    public IWebDriver driver;
    
    public DetailedAutoPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "(//div[@type='[object Object]'])[4]")]
    private IWebElement clickToMark;
    
    [FindsBy(How = How.XPath, Using = "//ul[@class='dropdown-style__list dropdown-style__list_brand']/li[@title='BMW']")]
    private IWebElement clickToBrand;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__offers-part_title div div")]
    private IWebElement getCarTitle;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__offers-part_parameter div:nth-child(1)")]
    private IWebElement getCarEngine;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__offers-part_parameter div:nth-child(2)")]
    private IWebElement getCarTransmission;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__offers-part_parameter div:nth-child(3)")]
    private IWebElement getCarType;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__description_horse:nth-child(1)")]
    private IWebElement getCarHP;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__description_chassis")]
    private IWebElement getCarChassis;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__description_premium-additional")]
    private IWebElement clickToCar;

    public void SelectBrand()
    {
        clickToMark.Click();
        Thread.Sleep(3000);
        clickToBrand.Click();
        Thread.Sleep(5000);
    }

    public string GetCarEngine()
    {
        return getCarEngine.Text;
    }
    
    public string GetCarTransmission()
    {
        return getCarTransmission.Text;
    }
    
    public string GetCarType()
    {
        return getCarType.Text;
    }
    
    public string GetCarHP()
    {
        return getCarHP.Text;
    }
    
    public string GetCarChassis()
    {
        return getCarChassis.Text;
    }
    
    public string GetCarTitle()
    {
        return getCarTitle.Text;
    }

    public ExactCarBrandPage ClickToCar()
    {
        clickToCar.Click();
        return new ExactCarBrandPage(driver);
    }
    
    
}