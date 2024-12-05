using TestProject1.Pages;

namespace TestProject1.Tests
{
    public class TestCase3 : BaseTest
    {
        [Test]
        public void AcceptCookieTest()
        {
            var mainPage = new MainPage();
            var gamePage = new GamePage();
            
            Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Главная страница не открыта");
            
            mainPage.ClickStartLink();
            Assert.That(gamePage.State.WaitForDisplayed(), Is.True, "Страница с формой не открыта");

            gamePage.ClickAcceptCookie();
            Assert.That(gamePage.IsCookieOpened(), Is.False, "Куки не были приняты");
        }
    }
}
