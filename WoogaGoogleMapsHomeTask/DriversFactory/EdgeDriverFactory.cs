using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using OpenQA.Selenium.Edge;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// This class implements IDriverFactory for creating EdgeDriver instances with custom configurations
    /// </summary>
    public class EdgeDriverFactory : IDriverFactory
    {
        /// <summary>
        /// This method creates and returns an instance of EdgeDriver with specified options and configurations
        /// </summary>
        public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            EdgeOptions options = new EdgeOptions();
#if RELEASE
            options.AddArgument("--headless");
#endif
            return new EdgeDriver(options);
        }
    }
}
