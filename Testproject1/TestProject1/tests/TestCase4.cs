using Aquality.Selenium.Browsers;
using NUnit.Framework;
using TestProject1.Pages;

namespace TestProject1.Tests
{
    public class TestCase4 : BaseTest
    {
        [Test]
        public void TimerStartTimeCorrectTest()
        {
            var mainPage = new MainPage();
            var gamePage = new GamePage();
            
            Assert.That(mainPage.State.WaitForDisplayed(), Is.True,"Главная страница не открыта");
            
            mainPage.ClickStartLink();
            Assert.That(gamePage.State.WaitForDisplayed(), Is.True, "Страница с формой не открыта");

            string startTime = gamePage.GetTimerText();
            Assert.That(startTime, Is.EqualTo(TestData?.StartTime), "Таймер начинается не с 00:00:00");
        }
    }
}
