using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace UIAutomationSuite;

public class LoginTests
{
    
    [Fact]
    public void ShouldBeAbleToLogin()
    {
        IWebDriver driver = new ChromeDriver();
        using var app = new App(driver);
        var isUserLoggedIn = app.GetPage<LoginPage>().GoTo()
            .EnterUsername("standard_user")
            .EnterPassword("secret_sauce")
            .ClickOnLoginButton()
            .IsUserLoggedIn();
        Assert.True(isUserLoggedIn,"User should be logged in successfully");
        
    }
}