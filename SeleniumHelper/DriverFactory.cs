using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumHelper;

public static class DriverFactory
{
    public static IWebDriver CreateDriver()
    {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized"); // Maximize the browser window on startup
        chromeOptions.AddArgument("--disable-extensions"); // Disable browser extensions
        chromeOptions.AddArgument("--disable-popup-blocking"); // Disable popup blocking
        chromeOptions.AddArgument("--disable-default-apps"); // Disable default apps
        chromeOptions.AddArgument("--disable-infobars"); // Disable infobars
        chromeOptions.AddArgument("--incognito"); // Start the browser in incognito mode
        chromeOptions.AddArgument("--disable-notifications"); // Disable notifications

        // Uncomment the following line to run tests in headless mode
        //chromeOptions.AddArgument("--headless");
        return new ChromeDriver(chromeOptions);
    }
}