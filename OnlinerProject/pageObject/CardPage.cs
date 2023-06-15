using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;

namespace OnlinerProject.pageObject;

public class CardPage
{
    public IWebDriver driver;
    
    public CardPage(IWebDriver driver)
    {
        this.driver = driver;
        PageFactory.InitElements(driver, this);
    }
    
    [FindsBy(How = How.CssSelector, Using = ".cart-form__button_increment")]
    private IWebElement incrementButton;
    
    [FindsBy(How = How.CssSelector, Using = ".helpers_hide_tablet div")]
    private IWebElement actualCost;
    
    [FindsBy(How = How.CssSelector, Using = ".cart-form__description_nowrap")]
    private IWebElement incrementText;
    
    [FindsBy(How = How.CssSelector, Using = ".cart-form__button_remove")]
    private IWebElement moveToDeleteButton;
    
    [FindsBy(How = How.CssSelector, Using = ".cart-form__button_remove")]
    private IWebElement clickToDeleteButton;

    public string GetActualCost()
    {
        return actualCost.Text;
    }

    public void ClickToIncrement()
    {
        incrementButton.Click();
        Actions act = new Actions(driver);
        act.MoveToElement(moveToDeleteButton).Perform();
        clickToDeleteButton.Click();
        
    }
    
    public string IncrementText()
    {
        return incrementText.Text;
    }
    

}