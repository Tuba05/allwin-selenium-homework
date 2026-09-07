using OpenQA.Selenium;

namespace selenium_test.Pages;

public class InventoryPage : BasePage
{
    private readonly By _hamburgerMenu = By.Id("react-burger-menu-btn");
    private readonly By _resetAppStateButton = By.Id("reset_sidebar_link");
    private readonly By _hamburgerMenuCloseButton = By.Id("react-burger-cross-btn");

    private readonly By _shoppingCart = By.Id("shopping_cart_container");

    private readonly By _addedItemName = By.CssSelector("[data-test='inventory-item-name']");
    private readonly By _quantityLabel = By.CssSelector("[data-test='cart-quantity-label']");
    private readonly By _descriptionLabel = By.CssSelector("[data-test='cart-desc-label']");
    private readonly By _itemQuantityLabel = By.CssSelector("[data-test='item-quantity']");
    private readonly By _sortDropdown = By.ClassName("product_sort_container");
    private readonly By _checkOutButton = By.Id("checkout");
    private readonly By _firstNameInput = By.Id("first-name");
    private readonly By _lastNameInput = By.Id("last-name");
    private readonly By _postalCodeInput = By.Id("postal-code");

    private readonly By _continueButton = By.CssSelector("[data-test='continue']");

    private readonly By _errorMessage = By.CssSelector("[data-test='error']");

    public InventoryPage(IWebDriver driver) : base(driver)
    {
    }

    public void ResetAppState()
    {
        Find(_hamburgerMenu).Click();
        Find(_resetAppStateButton).Click();
        Find(_hamburgerMenuCloseButton).Click();
    }

    public void AddProductToCart(string productName)
    {
        var product = By.CssSelector($"[data-test='add-to-cart-sauce-labs-{productName}']");

        Find(product).Click();
    }

    public void SortBy(string option)
    {
        var dropdown = Find(_sortDropdown);
        dropdown.Click();

        dropdown.FindElement(By.XPath($"./option[@value='{option}']")).Click();
    }

    public void OpenCart()
    {
        Find(_shoppingCart).Click();
    }

    public void removeProductFromCartByName(string productName)
    {
        var product = By.CssSelector($"[data-test='remove-sauce-labs-{productName}']");

        Find(product).Click();
    }

    public void assertProductRemoveButtonIsVisible(string productName)
    {
        var product = By.CssSelector($"[data-test='remove-sauce-labs-{productName}']");

        Assert.True(Find(product).Displayed);
    }

    public void quantityLabelIsVisible()
    {
        Assert.True(Find(_quantityLabel).Displayed);
    }

    public void descriptionLabelIsVisible()
    {
        Assert.True(Find(_descriptionLabel).Displayed);
    }

    public void itemQuantityLabelIsVisible()
    {
        Assert.True(Find(_itemQuantityLabel).Displayed);
    }

    public string GetAddedItemName()
    {
        return Find(_addedItemName).Text;
    }

    public void assertAddedItemNameIsVisible(string productName)
    {
        Assert.Equal(productName, GetAddedItemName());
    }

    public void assertAddedItemNameIsNotVisible(string productName)
    {

        var product = By.CssSelector($"[data-test='remove-sauce-labs-{productName}']");
        Assert.Empty(Driver.FindElements(product));
    }

    public void ClickCheckout()
    {
        Find(_checkOutButton).Click();
    }


    public void EnterFirstName(string firstName)
    {
        Find(_firstNameInput).SendKeys(firstName);
    }

    public void EnterLastName(string lastName)
    {
        Find(_lastNameInput).SendKeys(lastName);
    }

    public void EnterPostalCode(string postalCode)
    {
        Find(_postalCodeInput).SendKeys(postalCode);
    }

    public void ClickContinue()
    {
        Find(_continueButton).Click();
    }

    public string GetErrorMessage()
    {
        return Find(_errorMessage).Text;
    }
    
    public void assertErrorMessageIsVisible(string expectedErrorMessage)
    {
        Assert.Equal(expectedErrorMessage, GetErrorMessage());
    }

}