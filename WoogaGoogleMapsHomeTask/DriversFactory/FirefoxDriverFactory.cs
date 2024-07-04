using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Firefox;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// This class implements IDriverFactory for creating FirefoxDriver instances with custom configurations
    /// </summary>
    public class FirefoxDriverFactory : IDriverFactory
    {
        /// <summary>
        /// This method creates and returns an instance of FirefoxDriver with specified options and configurations
        /// </summary>
        public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            FirefoxOptions options = new FirefoxOptions();
#if RELEASE
            options.AddArgument("--headless");
#endif
            return new FirefoxDriver(options);
        }
    }
}
