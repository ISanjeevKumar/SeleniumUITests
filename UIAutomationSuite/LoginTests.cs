using PageObjects;

namespace UIAutomationSuite;

public class LoginTests
{
    
    [Fact]
    public void ShouldBeAbleToLogin()
    {
        using var app = new App();
        var isUserLoggedIn = app.GetPage<LoginPage>().GoTo()
            .EnterUsername("standard_user")
            .EnterPassword("secret_sauce")
            .ClickOnLoginButton()
            .IsUserLoggedIn();
        Assert.True(isUserLoggedIn,"User should be logged in successfully");
        
    }
}