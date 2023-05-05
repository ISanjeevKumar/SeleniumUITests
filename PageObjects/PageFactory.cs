using OpenQA.Selenium;

namespace PageObjects;

public class PageFactory
{
    public T CreatePage<T>(IWebDriver driver) where T : IPage, new()
    {
        var pageObject = new T();
        return pageObject;
    }

}