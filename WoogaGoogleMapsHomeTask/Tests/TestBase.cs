using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using WoogaGoogleMapsHomeTask.Configuration;
using WoogaGoogleMapsHomeTask.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WoogaGoogleMapsHomeTask.DriversFactory;
using WoogaGoogleMapsHomeTask.Reports;
using WoogaGoogleMapsHomeTask.Utilities;

namespace WoogaGoogleMapsHomeTask.Tests
{
    /// <summary>
    /// This is base class for all test classes, 
    /// providing common setup and teardown functionality
    /// </summary>
    [TestFixture]
    public class TestBase
    {
        private const string _mainUrl = "https://www.google.com/maps?hl=en";
        private const string _mainTitle = "Google Maps";
        private const string _configFolderName = "Configuration";
        private const string _configFileName = "config";

        public IWebDriver _driver;
        public Reporter _reporter;
        protected IServiceProvider ServiceProvider;
        private Config _config;

        /// <summary>
        /// This is one-time setup method for the test run
        /// Initializes dependency injection and reporting
        /// </summary>
        [OneTimeSetUp]
        public void TestRunSetUp()
        {
            ServiceProvider = TestDependencyInjection.ServiceProvider;
            _reporter = ServiceProvider.GetService<Reporter>();
        }

        /// <summary>
        /// This is setup method for each test
        /// Initializes the web driver, navigates to the main URL, 
        /// and maximizes the browser window
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            _reporter.StartTest(TestContext.CurrentContext.Test.MethodName);
#if DEBUG
            _reporter.LogInfo("SetUp -> Reading config file");
            _config = FileHandler.GetFileData<Config>(_configFolderName, _configFileName);
            var browserType = _config.Browser;

            _reporter.LogInfo("SetUp -> Getting browser type from environment variable");
            var browser = Environment.GetEnvironmentVariable("BROWSER_TYPE");
            browserType = (BrowserType)Enum.Parse(typeof(BrowserType), browser);
#else
            _reporter.LogInfo("SetUp -> Getting browser type from environment variable");
            var browserType = Environment.GetEnvironmentVariable("BROWSER_TYPE");
#endif
            _reporter.LogInfo($"SetUp -> Creating driver [ {browserType} ]");
            _driver = DriverFactory.CreateDriver(browserType);

            _reporter.LogInfo($"SetUp -> Going to url [ {_mainUrl} ]");
            _driver.Url = _mainUrl;
            _driver.Manage().Window.Maximize();

            SeleniumExtensions.WaitUntil(_driver, ExpectedConditions.TitleContains(_mainTitle));
        }

        /// <summary>
        /// This is teardown method for each test
        /// Closes and quits the web driver and logs the test results
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            EndTest();
            _driver.Close();
            _driver.Quit();            
        }

        /// <summary>
        /// This is one-time teardown method for the test run
        /// Ends the reporting
        /// </summary>
        [OneTimeTearDown]
        public void TestRunTearDown()
        {
            _reporter.EndReporting();
        }

        /// <summary>
        /// This methods ends the current test, logs the test result 
        /// and takes a screenshot if the test failed
        /// </summary>
        private void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;
            switch (testStatus)
            {
                case TestStatus.Failed:
                    _reporter.LogFail($"Tear down -> Test failed: [ {message} ]");
                    _reporter.LogScreenShot("Tear down -> Taking screenshot -> click the img button to open screenshot",
                                                    SeleniumExtensions.TakeScreenshot(_driver));
                    break;
                case TestStatus.Skipped:
                    _reporter.LogFail($"Tear down -> Test skipped: [ {message} ]");
                    break;
                default:
                    break;
            }
            _reporter.LogInfo("Tear down -> Ending test");
        }       
    }
}
