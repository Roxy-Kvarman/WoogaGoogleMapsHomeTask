using OpenQA.Selenium;
using WoogaGoogleMapsHomeTask.Utilities;

namespace WoogaGoogleMapsHomeTask.Pages
{
    /// <summary>
    /// This class represents the address pane page on the application, 
    /// inheriting from <see cref="BasePage"/>.
    /// </summary>
    public class AddressPanePage : BasePage
    {
        public AddressPanePage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// This method retrieves the short and full address information displayed on the address pane
        /// </summary>
        public (string, string) GetAddressInfo()
        {
            var pane = GetAddressPane();
            var shortAddress = pane.FindElement(By.TagName("h1")).Text;
            var fullAddress = pane.FindElement(By.XPath(".//div[contains(@aria-label,'Address')]//span/span")).Text;

            return (shortAddress, fullAddress);
        }

        /// <summary>
        /// This method retrieves the error message displayed when a search address fails
        /// </summary>
        public string GetSearchAddressError()
        {
            var pane = GetAddressPane();
            var text = pane.Text;
            return text.Split("\r\n")[0];
        }

        /// <summary>
        /// This method retrieves the address pane element from the page
        /// </summary>
        /// <returns>The address pane as an <see cref="IWebElement"/>.</returns>
        private IWebElement GetAddressPane()
        {
            return SeleniumExtensions.FindElement(_driver, By.XPath("//div[@role='main']"));
        }
    }
}
