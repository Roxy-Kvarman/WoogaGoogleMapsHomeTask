using OpenQA.Selenium;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// This interface represents a factory interface for creating WebDriver instances
    /// </summary>
    public interface IDriverFactory
    {
        /// <summary>
        /// This method creates and returns an instance of the WebDriver
        /// </summary>
        IWebDriver CreateDriver();
    }
}
