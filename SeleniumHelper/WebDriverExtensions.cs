using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHelper;

public static class WebDriverExtensions
{
    public static void WaitForPageReady(this IWebDriver driver, int timeoutInSeconds= 60)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(d =>
        {
            var isAjaxFinished = (bool)((IJavaScriptExecutor)d).ExecuteScript("return jQuery.active == 0");
            var isDocumentReady = ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete");
            var isNetworkIdle = (bool)((IJavaScriptExecutor)driver).ExecuteScript("return window.performance.getEntriesByType('resource').filter(r => r.initiatorType !== 'xmlhttprequest' && r.duration === 0).length === 0");
            return isAjaxFinished && isDocumentReady && isNetworkIdle;
        });
    }

    public static void WaitForUrl(this IWebDriver driver,string url ,int timeOutInSecs = 20)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutInSecs));
         wait.Until(d => d.Url.Contains(url));
    }
   
    public static void WaitForCustomCondition(this IWebDriver driver, int timeoutInSeconds, Func<IWebDriver, bool> condition)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        wait.Until(condition);
    }
}