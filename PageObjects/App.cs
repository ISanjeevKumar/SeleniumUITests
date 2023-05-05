using OpenQA.Selenium;

namespace PageObjects;

public class App : IDisposable
{
    private IWebDriver  Driver {  get; }

    public App(IWebDriver driver)
    {
        Driver = driver;
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