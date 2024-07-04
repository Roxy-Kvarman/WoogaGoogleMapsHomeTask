using System.Text.Json.Serialization;
using WoogaGoogleMapsHomeTask.DriversFactory;

namespace WoogaGoogleMapsHomeTask.Configuration
{
    /// <summary>
    /// This class represents configuration data
    /// </summary>
    public class Config
    {
        /// <summary>
        /// This property tets or sets the browser type specified in the configuration
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("browser")]
        public BrowserType Browser { get; set; }
    }
}
