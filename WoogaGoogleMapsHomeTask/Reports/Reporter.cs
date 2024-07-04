using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;

namespace WoogaGoogleMapsHomeTask.Reports
{
    /// <summary>
    /// This is helper class for generating detailed test reports using ExtentReports
    /// </summary>
    public class Reporter
    {
        private const string _reportsFolderName = "Reports";
        private const string _testsResultsFolderName = "TestResults";

        private ExtentReports _extentReports;
        private ExtentTest _extentTest;

        /// <summary>
        /// Constructor to initialize the ExtentReports instance
        /// </summary>
        public Reporter()
        {
            string reportPath = string.Empty;
#if DEBUG
            reportPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, @"..\..\..\", _reportsFolderName, _testsResultsFolderName);
#else
            reportPath = Path.Combine(TestContext.CurrentContext.WorkDirectory, _reportsFolderName, _testsResultsFolderName);
#endif
            string fileName = $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            string fullPath = Path.Combine(reportPath, fileName);
            var htmlReporter = new ExtentSparkReporter(fullPath);
            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        /// <summary>
        /// This method starts a new test with the specified test name
        /// </summary>
        public void StartTest(string testName)
        {
            _extentTest = _extentReports.CreateTest(testName);
        }

        /// <summary>
        /// This method logs an informational message in the current test
        /// </summary>
        public void LogInfo(string message)
        {
            _extentTest.Info(message);
        }

        /// <summary>
        /// This method logs a fail status message in the current test
        /// </summary>
        public void LogFail(string message)
        {
            _extentTest.Fail(message);
        }

        /// <summary>
        /// This method logs a screenshot taken during the current test.
        /// </summary>
        /// <param name="message">The message describing the screenshot.</param>
        /// <param name="image">The base64-encoded string representation of the screenshot image.</param>
        public void LogScreenShot(string message, string image)
        {
            _extentTest.Info(message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

        /// <summary>
        /// This method ends the reporting process and flushes all accumulated data to the output file
        /// </summary>
        public void EndReporting()
        {
            _extentReports.Flush();
        }
    }
}

