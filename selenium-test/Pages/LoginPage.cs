using OpenQA.Selenium;

namespace selenium_test.Pages;

public class LoginPage : BasePage
{
    private readonly By UsernameInput = By.Id("user-name");
    private readonly By PasswordInput = By.Id("password");
    private readonly By LoginButton = By.Id("login-button");

    public LoginPage(IWebDriver driver) : base(driver)
    {
    }

    public void EnterUsername(string username)
    {
        Find(UsernameInput).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        Find(PasswordInput).SendKeys(password);
    }

    public InventoryPage ClickLogin()
    {
        Find(LoginButton).Click();

        return new InventoryPage(Driver);
    }
}