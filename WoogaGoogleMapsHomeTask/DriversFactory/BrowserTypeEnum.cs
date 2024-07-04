using System.Runtime.Serialization;

namespace WoogaGoogleMapsHomeTask.DriversFactory
{
    /// <summary>
    /// Enum defining different types of web browsers supported for WebDriver instantiation
    /// </summary>
    public enum BrowserType
    {
        [EnumMember(Value = "chrome")]
        ChromeDriver,

        [EnumMember(Value = "firefox")]
        FirefoxDriver,

        [EnumMember(Value = "edge")]
        EdgeDriver
    }
}
