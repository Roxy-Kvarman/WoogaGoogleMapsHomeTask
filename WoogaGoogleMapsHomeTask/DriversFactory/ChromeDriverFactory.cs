using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// This class implements IDriverFactory for creating ChromeDriver instances with custom configurations
    /// </summary>
    public class ChromeDriverFactory : IDriverFactory
    {
        /// <summary>
        /// This method creates and returns an instance of ChromeDriver with specified options and configurations
        /// </summary>
        public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArguments("--disable-popup-blocking");
            options.AddArgument("--disable-notifications");
            options.AddArguments("--disable-infobars");
            options.AddArguments("--no-sandbox");
            options.AddArgument("--incognito");
#if RELEASE
            options.AddArgument("--headless");
#endif
            return new ChromeDriver(options);
        }
    }
}
