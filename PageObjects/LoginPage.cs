using OpenQA.Selenium;

namespace PageObjects;

public class LoginPage : BasePage , IPage
{

    public LoginPage(IWebDriver driver) : base(driver)
    {
        
    }
    
    public void GoTo()
    {
        string url = "https://www.saucedemo.com/";
        try
        {
            Driver.Navigate().GoToUrl(url);
            Thread.Sleep(10000);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Unable to navigate to url {url} due to exception:{ex.Message}");
            throw;
        }
   
    }
    
}