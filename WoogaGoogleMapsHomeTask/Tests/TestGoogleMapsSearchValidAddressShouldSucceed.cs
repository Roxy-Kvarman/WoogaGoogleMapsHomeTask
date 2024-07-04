using WoogaGoogleMapsHomeTask.Pages;
using WoogaGoogleMapsHomeTask.TestsData;

namespace WoogaGoogleMapsHomeTask.Tests
{
    [TestFixture]
    public class TestGoogleMapsSearchValidAddressShouldSucceed : TestBase
    {
        /// <summary>
        /// This test method verifies valid address on Google maps.
        /// It uses parameterized approach and receives test data from testData.json
        /// ! Important ! -  1 pair of test data is prepared to fail 
        /// in order to show screenshot capture in case of test failure 
        /// for the purpose of this home task.
        /// </summary>
        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetValidData))]
        public void TestGoogleMapsSearchValidAddressShouldSucceed_1(string expectedFullAddress, string expectedShortAddress)
        {
            var errorList = new List<string>();

            _reporter.LogInfo($"Home page -> Search address [ {expectedFullAddress} ]");

            var homePage = new HomePage(_driver);
            var addressPanePage = homePage.SearchAddress(expectedFullAddress);

            _reporter.LogInfo($"Address pane page -> Get info for address [ {expectedFullAddress} ]");

            var (actualShortAddress, actualFullAddress) = addressPanePage.GetAddressInfo();

            _reporter.LogInfo($"Address pane page -> Verify address [ {expectedFullAddress} ]");

            if (actualShortAddress != expectedShortAddress)
            {
                errorList.Add($"Actual short address is not as expected. " +
                                   $"Actual: [ {actualShortAddress} ], expected: [ {expectedShortAddress} ]");
            }
            if (actualFullAddress != expectedFullAddress)
            {
                errorList.Add($"Actual full address is not as expected. " +
                                   $"Actual: [ {actualFullAddress} ], expected: [ {expectedFullAddress} ]");
            }

            Assert.That(!errorList.Any(), string.Join(", ", errorList));
        }
    }
}
