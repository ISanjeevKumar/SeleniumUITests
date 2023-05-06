using OpenQA.Selenium;
using SeleniumHelper;

namespace PageObjects;

public class LoginPage : BasePage , IPage
{
    private IWebElement UsernameInput => WebElementFinder.GetElement(Driver, By.Id("user-name"));
    private IWebElement PasswordInput =>WebElementFinder.GetElement(Driver, By.Id("password"));
    private IWebElement LoginBtn =>WebElementFinder.GetElement(Driver, By.Id("login-button"));
    public LoginPage(IWebDriver driver) : base(driver)
    {
        
    }
    
    public LoginPage GoTo()
    {
        string url = "https://www.saucedemo.com/";
        try
        {
            Driver.Navigate().GoToUrl(url);
            return this;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unable to navigate to url {url} due to exception:{ex.Message}");
            throw;
        }
   
    }

    public LoginPage EnterUsername(string username)
    {
        try
        {
            UsernameInput.SendKeys(username);
            return this;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    public LoginPage EnterPassword(string password)
    {
        try
        {
            PasswordInput.SendKeys(password);
            return this;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
    public LoginPage ClickOnLoginButton()
    {
        try
        {
            WebButtonHelper.ClickWithActions(LoginBtn);
            return this;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public bool IsUserLoggedIn()
    {
        return Driver.Url.Contains("inventory.html");
    }
    
}