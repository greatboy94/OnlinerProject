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
    
    [FindsBy(How = How.CssSelector, Using = ".product-aside__offers-flex a:nth-child(1)")]
    private IWebElement expectedCost;
    
    [FindsBy(How = How.XPath, Using = "//a[contains(text(), 'Перейти в корзину')]")]
    private IWebElement cardButton;


    public string GetExpectedCost()
    {
        return expectedCost.Text;
    }

    public CardPage AddToCard()
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5)); 
        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
            By.CssSelector(".product-aside__control a:nth-child(2)"))).Click();
        Thread.Sleep(3000);
        cardButton.Click();

        return new CardPage(driver);
    }

}