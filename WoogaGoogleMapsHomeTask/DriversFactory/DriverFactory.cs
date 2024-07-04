using OpenQA.Selenium;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// This is factory class for creating WebDriver instances based on specified browser types
    /// </summary>
    public class DriverFactory
    {

        private static readonly Dictionary<BrowserType, IDriverFactory> _driverFactories = new()
        {
            {BrowserType.ChromeDriver, new ChromeDriverFactory() },
            {BrowserType.FirefoxDriver, new FirefoxDriverFactory() },
            {BrowserType.EdgeDriver, new EdgeDriverFactory() }
        };

        /// <summary>
        /// This method creates a new WebDriver instance based on the specified browser type
        /// </summary>
        /// <param name="browserType">The type of browser for which to create a WebDriver instance.</param>
        /// <returns>A new instance of the WebDriver for the specified browser.</returns>
        /// <exception cref="NotImplementedException">Thrown if the specified browser type is not supported.</exception>
        public static IWebDriver CreateDriver(BrowserType browserType)
        {
            if (_driverFactories.TryGetValue(browserType, out var factory))
            {
                return factory.CreateDriver();
            }

            throw new NotImplementedException($"browser type [{typeof(BrowserType).FullName} is not supported!]");
        }
    }
}
