using OpenQA.Selenium;

namespace PageObjects;

public class BasePage
{
    protected readonly IWebDriver Driver;

    protected BasePage(IWebDriver driver)
    {
        this.Driver = driver;
    }
}