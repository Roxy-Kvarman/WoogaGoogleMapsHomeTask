using OpenQA.Selenium;

namespace WoogaGoogleMapsHomeTask.Pages
{
    /// <summary>
    /// This class represents a base page for web automation, 
    /// providing access to WebDriver functionality
    /// </summary>
    public class BasePage
    {
        public IWebDriver _driver;

        public BasePage(IWebDriver driver)
        {
            if (driver != null)
            {
                _driver = driver;
            }
        }
    }
}
