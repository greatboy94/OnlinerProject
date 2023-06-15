using OnlinerProject.pageObject;
using OnlinerProject.utilities;
using OpenQA.Selenium;

namespace OnlinerProject;

public class Tests : Base
{

    [Test]
    public void Test1()
    {
        string expectedIncrement = "за 2 товара";
        
        HomePage homePage = new HomePage(getDriver());
        ProductsPage productsPage= homePage.searchForPhone("Смартфон Samsung Galaxy A52 SM-A525F/DS 6GB/128GB (черный)");
        CardPage cardPage= productsPage.AddToCard();
        //Assert.AreEqual(productsPage.GetExpectedCost(), cardPage.GetActualCost());
        cardPage.ClickToIncrement();
        Thread.Sleep(3000);

    }
}