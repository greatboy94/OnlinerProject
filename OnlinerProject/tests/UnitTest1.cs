using OnlinerProject.pageObject;
using OnlinerProject.utilities;

namespace OnlinerProject;
[Parallelizable]
public class Tests : Base
{
    [Test]
    [Parallelizable]
    public void ValidTest()
    {
        ExtentReporting.LogInfo("Starting test - Checking for valid product");
        string expectedIncrement = "за 2 товара";

        HomePage homePage = new HomePage(getDriver());
        ProductsPage productsPage= homePage.searchForPhone("Смартфон Samsung Galaxy A52");
        string val1 = productsPage.GetExpectedCost();
        CardPage cardPage= productsPage.AddToCard();
        string val2 = cardPage.GetActualCost();
        Assert.AreEqual(val1, val2);
        cardPage.ClickToIncrement();
        Thread.Sleep(3000);

    }
    
    [Test]
    [Parallelizable]
    public void InValidTest()
    {
        ExtentReporting.LogInfo("Starting test - Checking for invalid product");
        string expectedIncrement = "за 2 товара";
        string expCost = "200р";
        
        HomePage homePage = new HomePage(getDriver());
        ProductsPage productsPage= homePage.searchForPhone("Смартфон Samsung Galaxy A52 SM-A525F/DS 6GB/128GB (черный)");
        CardPage cardPage= productsPage.AddToCard();
        string val2 = cardPage.GetActualCost();
        Assert.AreEqual(expCost, val2);
        cardPage.ClickToIncrement();
        Thread.Sleep(3000);

    }
}