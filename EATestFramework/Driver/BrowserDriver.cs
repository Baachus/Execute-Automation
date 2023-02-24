using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace EATestFramework.Driver;

public class BrowserDriver : IBrowserDriver
{
    public IWebDriver GetChromeDriver()
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        return new ChromeDriver();
    }
    public IWebDriver GetFirefoxDriver()
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        return new FirefoxDriver();
    }
    public IWebDriver GetEdgeDriver()
    {
        new DriverManager().SetUpDriver(new EdgeConfig());
        return new EdgeDriver();
    }
}

public enum BrowserType
{
    Chrome,
    Firefox,
    Edge,
    Safari
}
