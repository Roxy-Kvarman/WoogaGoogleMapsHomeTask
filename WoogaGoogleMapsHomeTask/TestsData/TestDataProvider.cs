using WoogaGoogleMapsHomeTask.Utilities;

namespace WoogaGoogleMapsHomeTask.TestsData
{
    /// <summary>
    /// This class provides test data for tests from a JSON file
    /// </summary>
    public class TestDataProvider
    {
        private const string _fileName = "testData";
        private const string _folderName = "TestsData";

        /// <summary>
        /// Retrieves valid test data from a JSON file
        /// </summary>
        /// <returns>An enumerable collection of <see cref="TestCaseData"/> 
        public static IEnumerable<TestCaseData> GetValidData()
        {
            var testData = FileHandler.GetFileData<TestData>(_folderName, _fileName);

            foreach (var data in testData.ValidData)
            {
                yield return new TestCaseData(data.FullAddress, data.ShortAddress);
            }
        }

        /// <summary>
        /// Retrieves invalid test data from a JSON file
        /// </summary>
        /// <returns>An enumerable collection of <see cref="TestCaseData"/> 
        public static IEnumerable<TestCaseData> GetInvalidData()
        {
            var testData = FileHandler.GetFileData<TestData>(_folderName, _fileName);

            foreach (var data in testData.InvalidData)
            {
                yield return new TestCaseData(data.Address, data.ErrorMessage);
            }
        }      
    }
}
