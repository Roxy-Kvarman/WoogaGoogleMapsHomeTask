using Newtonsoft.Json;

namespace WoogaGoogleMapsHomeTask.TestsData
{
    /// <summary>
    /// This class represents valid test data with expected full and short addresses
    /// </summary>
    public class ValidData
    {
        [JsonProperty(PropertyName = "expected_full_address")]
        public string FullAddress { get; set; }

        [JsonProperty(PropertyName = "expected_short_address")]
        public string ShortAddress { get; set; }
    }

    /// <summary>
    /// This class represents invalid test data with an address and the expected error message
    /// </summary>
    public class InvalidData
    {
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "error_message")]
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// This class contains collections of valid and invalid test data
    /// </summary>
    public class TestData
    {
        [JsonProperty(PropertyName = "Valid data")]
        public List<ValidData> ValidData { get; set; }

        [JsonProperty(PropertyName = "Invalid data")]
        public List<InvalidData> InvalidData { get; set; }
    }
}
