using Aquality.Selenium.Browsers;
using TestProject1.Utils;
using TestProject1.Models;

namespace TestProject1.Tests
{
    public class BaseTest
    {
        protected TestData? TestData;

        [SetUp]
        public void SetUp()
        {
            TestData = TestDataProvider.Load();
            var browser = AqualityServices.Browser;
            browser = AqualityServices.Browser;
            browser.Maximize();
            browser.GoTo(TestData.Url);
        }

        [TearDown]
        public void TearDown()
        {
            var browser = AqualityServices.Browser;
            browser.Quit();
        }
    }
}
