using System.Collections;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace OnlinerProject.pageObject;

public class HomePage
{

    private IWebDriver driver;
    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    
    [FindsBy(How = How.CssSelector, Using = ".fast-search__input")]
    private IWebElement searchInput;
    
    [FindsBy(How = How.XPath, Using = "//div[@class='product__title'][1]")]
    private IWebElement clickToPhone;


    public ProductsPage searchForPhone(string phoneName)
    {
        searchInput.SendKeys(phoneName);
        driver.SwitchTo().Frame(driver.FindElement(By.XPath("//iframe[@class='modal-iframe']")));
        Thread.Sleep(3000);
        clickToPhone.Click();

        return new ProductsPage(driver);
    }

}