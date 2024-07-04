using WoogaGoogleMapsHomeTask.Pages;
using WoogaGoogleMapsHomeTask.TestsData;

namespace WoogaGoogleMapsHomeTask.Tests
{
    [TestFixture]
    public class TestGoogleMapsSearchInvalidAddressShouldDisplayCorrectError : TestBase
    {
        /// <summary>
        /// This test method verifies correct error in case of searching not existing address on Google maps.
        /// It uses parameterized approach and receives test data from testData.json
        /// </summary>
        [Test, TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.GetInvalidData))]
        public void TestGoogleMapsSearchInvalidAddressShouldDisplayCorrectError_2(string address, string errorMessage)
        {
            _reporter.LogInfo($"Home page -> Search address [ {address} ]");

            var homePage = new HomePage(_driver);
            var addressPanePage = homePage.SearchAddress(address);

            _reporter.LogInfo($"Address pane page -> Get and verify error");

            var actualErrorMessage = addressPanePage.GetSearchAddressError();            

            Assert.That(actualErrorMessage, Is.EqualTo(errorMessage));
        }
    }
}
