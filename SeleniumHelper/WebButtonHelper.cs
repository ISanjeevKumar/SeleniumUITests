using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;

namespace SeleniumHelper;

public static class WebButtonHelper
{
    public static void ClickElement(IWebElement element)
    {
        try
        {
            element.Click();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to click on element: {ex.Message}");
        }
    }
    
    public static void ClickWithActions(IWebElement element)
    {
        try
        {
            Actions action = new Actions(((IWrapsDriver)element).WrappedDriver);
            action.MoveToElement(element).Click().Perform();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to click on element with Actions: {ex.Message}");
        }
    }

}