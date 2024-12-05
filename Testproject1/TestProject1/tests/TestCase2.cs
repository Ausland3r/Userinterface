using TestProject1.Pages;

namespace TestProject1.Tests
{
    public class TestCase2 : BaseTest
    {
        [Test]
        public void CloseHelpFormTest()
        {
            var mainPage = new MainPage();
            var gamePage = new GamePage();
            var formPage = new HelpForm();
            
            Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Главная страница не открыта");
            
            mainPage.ClickStartLink();
            Assert.That(gamePage.State.WaitForDisplayed(), Is.True, "Страница с формой не открыта");

            formPage.CloseForm();
            Assert.That(formPage.IsFormHidden(), Is.True, "Форма не была закрыта");
        }
    }
}
