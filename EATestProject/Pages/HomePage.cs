using EATestFramework.Driver;
using EATestFramework.Extensions;

namespace EATestProject.Pages;

public interface IHomePage
{
    void CreateProduct();
    void PerformClickOnSpecialValue(string name, string operation = "Details");
}

public class HomePage : IHomePage
{
    private readonly IWebDriver driver;

    public HomePage(IDriverFixture driver) => this.driver = driver.Driver;

    IWebElement lnkProduct => driver.FindElement(By.LinkText("Product List"));
    IWebElement lnkCreate => driver.FindElement(By.LinkText("Create New"));
    IWebElement tblList => driver.FindElement(By.CssSelector(".table"));

    public void CreateProduct()
    {
        lnkProduct.Click();
        lnkCreate.Click();
    }

    public void PerformClickOnSpecialValue(string name, string operation = "Details")
    {
        tblList.PerformActionOnCell("5", "Name", name, operation);
    }
}
