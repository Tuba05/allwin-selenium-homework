using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using selenium_test.Pages;

namespace selenium_test.Tests;

public class ProductTests
{
    [Fact]
    public void UserCanAddProductToCart()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            var inventoryPage = loginPage.ClickLogin();

            inventoryPage.AddProductToCart("backpack");
            inventoryPage.OpenCart();

            inventoryPage.quantityLabelIsVisible();
            inventoryPage.descriptionLabelIsVisible();
            inventoryPage.itemQuantityLabelIsVisible();
            inventoryPage.assertProductRemoveButtonIsVisible("backpack");
            inventoryPage.assertAddedItemNameIsVisible("Sauce Labs Backpack");
        }
        finally
        {
            driver.Quit();
        }
    }

    [Fact]
    public void UserRemoveProductFromCart()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            var inventoryPage = loginPage.ClickLogin();

            inventoryPage.AddProductToCart("backpack");
            inventoryPage.OpenCart();

            inventoryPage.assertProductRemoveButtonIsVisible("backpack");

            inventoryPage.removeProductFromCartByName("backpack");
            inventoryPage.assertAddedItemNameIsNotVisible("Sauce Labs Backpack");
        }
        finally
        {
            driver.Quit();
        }
    }

    [Fact]
    public void mandatoryFields()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            var inventoryPage = loginPage.ClickLogin();

            inventoryPage.ResetAppState();

            inventoryPage.AddProductToCart("backpack");
            inventoryPage.OpenCart();

            inventoryPage.assertProductRemoveButtonIsVisible("backpack");

            inventoryPage.ClickContinue();
            inventoryPage.assertErrorMessageIsVisible("Error: First Name is required");
        }
        finally
        {
            driver.Quit();
        }
    }

    [Fact]
    public void UserCanSortProductsByPriceLowToHigh()
    {
        IWebDriver driver = new ChromeDriver();

        try
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            var loginPage = new LoginPage(driver);

            loginPage.EnterUsername("standard_user");
            loginPage.EnterPassword("secret_sauce");

            var inventoryPage = loginPage.ClickLogin();

            inventoryPage.SortBy("lohi");

            var prices = driver
                .FindElements(By.ClassName("inventory_item_price"))
                .Select(element => decimal.Parse(
                    element.Text.Replace("$", "")
                ))
                .ToList();

            var sortedPrices = prices
                .OrderBy(price => price)
                .ToList();

            Assert.Equal(sortedPrices, prices);
        }
        finally
        {
            driver.Quit();
        }
    }
}
