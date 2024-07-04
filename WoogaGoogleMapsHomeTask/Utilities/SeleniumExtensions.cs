using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace WoogaGoogleMapsHomeTask.Utilities
    {
    /// <summary>
    /// This class provides extension methods for Selenium WebDriver to facilitate common actions
    /// </summary>
    public class SeleniumExtensions
    {
        /// <summary>
        /// This method waits until a specified condition is met 
        /// or the timeout period elapses
        /// </summary>
        public static void WaitUntil<T>(IWebDriver driver, Func<IWebDriver, T> condition, int timeToWait = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeToWait));
            wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until(condition);
        }

        /// <summary>
        /// This method waits until a web element specified by the given selector is visible 
        /// or the timeout period elapses
        /// </summary>
        public static void WaitUntilElementLoad(IWebDriver driver, By by, int timeToWait = 30)
        {
            WaitUntil(driver, ExpectedConditions.ElementIsVisible(by), timeToWait);
        }

        /// <summary>
        /// This method waits until the specified element is clickable 
        /// and then clicks it
        /// </summary>
        public static void ClickByElement(IWebDriver driver, IWebElement element, int timeToWait = 30)
        {
            WaitUntil(driver, ExpectedConditions.ElementToBeClickable(element), timeToWait);
            element.Click();
        }

        /// <summary>
        /// This method clicks the specified web element, 
        /// clears any existing text, and enters the provided text
        /// </summary>
        public static void EnterText(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// This method finds a web element using the specified selector, 
        /// waiting up to the specified time for it to appear
        /// </summary>
        public static IWebElement FindElement(IWebDriver driver, By by, int timeToWait = 30)
        {
            try
            {
                WaitUntil(driver, d => d.FindElement(by), timeToWait);
            }
            catch (TimeoutException)
            {
                return null;
            }

            return driver.FindElement(by);
        }

        /// <summary>
        /// This method takes a screenshot of the current browser window 
        /// and returns it as a Base64 encoded string
        /// </summary>
        public static string TakeScreenshot(IWebDriver driver)
        {
            var file = ((ITakesScreenshot)driver).GetScreenshot();
            var img = file.AsBase64EncodedString;
            return img;
        }
    }
}
