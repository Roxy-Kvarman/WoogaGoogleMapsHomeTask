using OpenQA.Selenium;
using WoogaGoogleMapsHomeTask.Utilities;

namespace WoogaGoogleMapsHomeTask.Pages
{
    /// <summary>
    /// This class represents the home page of the application, 
    /// inheriting from <see cref="BasePage"/>.
    /// </summary>
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        /// <summary>
        /// This method searches for an address on the Google Maps home page
        /// </summary>
        /// <param name="address">The address to search for</param>
        /// <returns>AddressPanePage instance</returns>
        public AddressPanePage SearchAddress(string address)
        {
            var searchField = SeleniumExtensions.FindElement(_driver, By.Id("searchbox"));
            var inputField = searchField.FindElement(By.XPath("./form/input"));

            SeleniumExtensions.EnterText(inputField, address);

            var searchIcon = SeleniumExtensions.FindElement(_driver, By.XPath("//button[@aria-label='Search']"));

            SeleniumExtensions.ClickByElement(_driver, searchIcon);
            SeleniumExtensions.WaitUntilElementLoad(_driver, By.XPath("//div[@role='main']"));

            return new AddressPanePage(_driver);
        }
    }
}
