using TestProject1.Pages;
using TestProject1.Utils;

namespace TestProject1.Tests
{
    public class TestCase1 : BaseTest
    {
        [Test]
        public void LoginFormTest()
        {
            var mainPage = new MainPage();
            var gamePage = new GamePage();
            var regForm = new RegForm();
            
            Assert.That(mainPage.State.WaitForDisplayed(), Is.True, "Главная страница не открыта");
            
            mainPage.ClickStartLink();
            Assert.That(gamePage.State.WaitForDisplayed(), Is.True, "Страница с формой не открыта");

            Assert.That(regForm.IsPasswordFormDisplayed(), Is.True, "Форма установки пароля не открыта");

            var (localPart, randomDomain, password) = DataUtils.GenerateEmailDomainAndPassword();
            regForm.EnterPassword(password);
            regForm.EnterMail(localPart, randomDomain);
            regForm.SelectRandomDomain();
            regForm.ClickTermsCheckbox();
            regForm.ClickNextButton();
            Assert.That(regForm.IsAvatarFormDisplayed(), Is.True, "Форма выбора интересов не открыта");

            regForm.ClickUnselectInterests();
            regForm.SelectRandomInterests();
            regForm.UploadAvatar();
            regForm.ClickNextButton();
            Assert.That(regForm.IsPersonalDetailFormDisplayed(), Is.True, "Форма заполнения персональных данных не открыта");
        }
    }
}
