using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace OnlinerProject.pageObject;

public class ProductsPage
{
    public IWebDriver driver;
    public ProductsPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.XPath, Using = "//div[@class='product-aside__offers-list']/div[@class='product-aside__offers-item product-aside__offers-item_primary']//a[starts-with(@href, 'https://catalog.onliner.by/mobile/')]")]
    private IWebElement expectedCost;
    
    [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Перейти в корзину')]")]
    private IWebElement cardButton;

    [FindsBy(How = How.XPath, Using = "//span[@class='button-style button-style_another button-style_base product-aside__button']")]
    private IWebElement confirmLocation;


    public string GetExpectedCost()
    {
        return expectedCost.Text;
    }

    public CardPage AddToCard()
    {
        confirmLocation.Click();
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            By.CssSelector(".product-aside__control a:nth-child(2)"))).Click();
        Thread.Sleep(3000);
        cardButton.Click();

        return new CardPage(driver);
    }

}