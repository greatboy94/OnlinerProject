using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OnlinerProject.pageObject;

public class ExactCarBrandPage
{
    
    public IWebDriver driver;
    
    public ExactCarBrandPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__description_premium-additional")]
    private IWebElement clickToCar;
    
    [FindsBy(How = How.XPath, Using = "//h1[@class='vehicle-form__title vehicle-form__title_big-alter vehicle-form__title_condensed-other']")]
    private IWebElement getCarTitle;
    
    [FindsBy(How = How.CssSelector, Using = ".jest-engine")]
    private IWebElement getCarEngine;
    
    [FindsBy(How = How.CssSelector, Using = ".jest-transmission")]
    private IWebElement getCarTransmission;
    
    [FindsBy(How = How.CssSelector, Using = ".jest-body-type")]
    private IWebElement getCarType;
    
    [FindsBy(How = How.CssSelector, Using = ".vehicle-form__parameter-item:nth-child(6) div:nth-child(2) div")]
    private IWebElement getCarHP;
    
    [FindsBy(How = How.CssSelector, Using = ".jest-drivetrain")]
    private IWebElement getCarChassis;

    public string GetCarTitle()
    {
        return getCarTitle.Text;
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

}