using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selenium_test.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    protected IWebElement Find(By locator)
    {
        return Driver.FindElement(locator);
    }
}