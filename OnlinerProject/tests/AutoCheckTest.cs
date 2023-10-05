using OnlinerProject.pageObject;
using OnlinerProject.utilities;

namespace OnlinerProject;
[Parallelizable(ParallelScope.Self)]
public class AutoCheckTest : Base
{
    [Test]
    public void CheckAuto()
    {
        
         ExtentReporting.LogInfo("Starting test - getting car details");
         HomePage homePage = new HomePage(getDriver()); 
         DetailedAutoPage detailedAutoPage = homePage.ClickToAuto();
         detailedAutoPage.SelectBrand();
         string storeCarTitle1 = detailedAutoPage.GetCarTitle();
         string storeCarEngine1 = detailedAutoPage.GetCarEngine();
         string storeCarTransmission1 = detailedAutoPage.GetCarTransmission();
         string storeCarType1 = detailedAutoPage.GetCarType();
         string storeCarHp1 = detailedAutoPage.GetCarHP();
         string storeCarChassis1 = detailedAutoPage.GetCarChassis();
         detailedAutoPage.ClickToCar();
         Thread.Sleep(3000);

         ExactCarBrandPage exactCarBrandPage = new ExactCarBrandPage(getDriver());
         string storeCarTitle2 = exactCarBrandPage.GetCarTitle();
         string storeCarEngine2 = exactCarBrandPage.GetCarEngine();
         string storeCarTransmission2 = exactCarBrandPage.GetCarTransmission();
         string storeCarType2 = exactCarBrandPage.GetCarType();
         string storeCarHp2 = exactCarBrandPage.GetCarHP();
         string storeCarChassis2 = exactCarBrandPage.GetCarChassis();
         
         Assert.AreEqual(storeCarTitle1, storeCarTitle2);
         Assert.AreEqual(storeCarEngine1, storeCarEngine2);
         Assert.AreEqual(storeCarTransmission1, storeCarTransmission2);
         Assert.AreEqual(storeCarType1, storeCarType2);
         Assert.AreEqual(storeCarHp1, storeCarHp2);
         Assert.AreEqual(storeCarChassis1, storeCarChassis2);


         Thread.Sleep(3000);
    }
}