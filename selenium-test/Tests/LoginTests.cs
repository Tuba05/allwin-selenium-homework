using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_test.Pages;

namespace selenium_test.Tests;

public class LoginTests
{
    private readonly IWebDriver _driver;

    public LoginTests()
    {
        _driver = new ChromeDriver();
    }

    [Fact]
    public void UserCanLogin()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        var loginPage = new LoginPage(_driver);

        loginPage.EnterUsername("standard_user");
        loginPage.EnterPassword("secret_sauce");
        loginPage.ClickLogin();

        Assert.Contains("inventory", _driver.Url);

        _driver.Quit();
    }
}