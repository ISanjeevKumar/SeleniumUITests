using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHelper;

public static class WebElementFinder
{
    /// <summary>
    /// Get First Matching Element
    /// </summary>
    /// <param name="driver">Selenium WebDriver Instance</param>
    /// <param name="elementLocator">Locator Value</param>
    /// <param name="timeOutInSecs">Time to wait for an element in seconds</param>
    /// <returns>First matching element</returns>
    /// <exception cref="WebDriverTimeoutException">TimeoutException</exception>
    public static IWebElement GetElement(IWebDriver driver , By elementLocator,  int timeOutInSecs=30)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecs));
            WebDriverWaitCondition(wait);
            return wait.Until(d=>FindVisibleAndEnabledElement(d,elementLocator));
        }
        catch (WebDriverTimeoutException ex)
        {
            throw new WebDriverTimeoutException($"Unable to find WebElement {elementLocator} due to: " + ex.Message);
        }
    }
    
    private static IWebElement FindVisibleAndEnabledElement(ISearchContext searchContext,By elementLocator)
    {
        IWebElement element = searchContext.FindElement(elementLocator);

        if (element.Displayed && element.Enabled)
        {
            return element;
        }
        throw new ElementNotVisibleException($"WebElement with locator {elementLocator} is not visible.");
    }
    
    private static readonly Action<WebDriverWait> WebDriverWaitCondition = (wait) =>
    {
        wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        wait.IgnoreExceptionTypes(typeof(ElementNotVisibleException));
    };
}