using OpenQA.Selenium;
using SeleniumHelper;

namespace PageObjects;

public class App : IDisposable
{
    private IWebDriver  Driver {  get; }

    public App()
    {
        Driver = DriverFactory.CreateDriver();
    }
    
    public T GetPage<T>() where T : IPage
    {
        T page = (T)Activator.CreateInstance(typeof(T), Driver);
        return page;
    }
    
    public void Dispose()
    {
        Driver.Quit();
    }
}