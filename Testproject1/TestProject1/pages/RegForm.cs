using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Browsers;
using TestProject1.Utils;

namespace TestProject1.Pages
{
    public class RegForm : Form
    {
        private ITextBox PasswordField => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'Choose Password')]"), "Password Field");
        private ITextBox EmailLocalField => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'Your email')]"), "Email Field");
        private ITextBox EmailDomainField => ElementFactory.GetTextBox(By.XPath("//*[contains(@placeholder, 'Domain')]"), "Domain Field");
        private IButton DropdownMenu => ElementFactory.GetButton(By.XPath("//*[contains(@class, 'dropdown__field')]"), "Dropdown Menu");
        private IList<ILabel> DomainOptions => ElementFactory.FindElements<ILabel>(By.XPath("//*[@class='dropdown__list-item' and not(text()='other')]"), "Domain Options");
        private ICheckBox AcceptTerms => ElementFactory.GetCheckBox(By.XPath("//*[contains(@class, 'checkbox__label')]"), "Accept Terms&Conditions");
        private IButton NextButton => ElementFactory.GetButton(By.XPath("//*[contains(@class, 'button') and contains(text(), 'Next')]"), "Next Button");
        private IButton UploadImage => ElementFactory.GetButton(By.XPath("//*[contains(@class, 'button') and contains(text(), 'upload')]"), "Upload image button");
        private ICheckBox UnselectAll => ElementFactory.GetCheckBox(By.XPath("//*[contains(@class, 'checkbox small')]//*[contains(@for, 'interest_unselectall')]"), "Unselet all interests");
        private ILabel PersonalDetailsTable => ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'personal-details__form-table')]"),"Personal Details Form Table");


        public RegForm() : base(By.XPath("//*[contains(@class, 'login-form__container')]"), "Registration Form"){}
        public void EnterPassword(string password)
        {
            PasswordField.ClearAndType(password);
        }

        public void EnterMail(string localPart, string randomDomain)
        {
            EmailLocalField.ClearAndType(localPart);
            EmailDomainField.ClearAndType(randomDomain);
        }

        public void ClickTermsCheckbox()
        {
            AcceptTerms.Click();
        }

        public void ClickNextButton()
        {
            NextButton.Click();
        }

        public void ClickUploadButton()
        {
            UploadImage.Click();
        }
        public bool IsPasswordFormDisplayed()
        {
            return PasswordField.State.WaitForDisplayed();
        }

        public bool IsAvatarFormDisplayed()
        {
            return UploadImage.State.WaitForDisplayed();
        }

        public bool IsPersonalDetailFormDisplayed()
        {
            return PersonalDetailsTable.State.WaitForDisplayed();
        }

        public void ClickUnselectInterests()
        {
            UnselectAll.Click();
        }

        public void SelectRandomDomain()
        {
            DropdownMenu.Click();
            if (!DropdownMenu.State.WaitForDisplayed())
            {
                throw new NoSuchElementException("Dropdown menu did not open.");
            }

            if (DomainOptions.Any())
            {
                var randomOption = DomainOptions.ElementAt(new Random().Next(DomainOptions.Count));
                randomOption.Click();
            }
            else
            {
                throw new NoSuchElementException("No domain options available to select.");
            }
        }

        public void SelectRandomInterests()
        {
            var testData = TestDataProvider.Load();
            var interestOptions = AqualityServices.Browser.Driver
                    .FindElements(By.XPath("//div[contains(@class, 'avatar-and-interests__interests-list__item')]//*[contains(@class, 'checkbox__box')]"))
                    .ToList();
            interestOptions.RemoveAll(option => option.FindElement(By.XPath("ancestor::label")).GetAttribute("for") == "interest_selectall");
            interestOptions.RemoveAt(interestOptions.Count - 1);
            var random = new Random();
            interestOptions
                .OrderBy(_ => random.Next())
                .Take(testData.InterestsNumber)
                .ToList()
                .ForEach(option => option.Click());
        }

        public void UploadAvatar()
        {
            var testData = TestDataProvider.Load();
            if (string.IsNullOrEmpty(testData.Avatar))
            {
                throw new InvalidOperationException("Avatar path is not specified in test data.");
            }
            var filePath = Path.Combine(AppContext.BaseDirectory, "resources", testData.Avatar);
            var fileBytes = File.ReadAllBytes(filePath);
            var base64Image = Convert.ToBase64String(fileBytes);

            ExecuteFileUploadScript(base64Image);
        }

        private void ExecuteFileUploadScript(string base64Image)
        {
            var testData = TestDataProvider.Load();
            if (string.IsNullOrEmpty(testData.UploadAvatarScript))
            {
                throw new InvalidOperationException("Java script function path is not specified in test data.");
            }
            var jsExecutor = (IJavaScriptExecutor)AqualityServices.Browser.Driver;
            var jsFilePath = Path.Combine(AppContext.BaseDirectory, "resources", "uploadAvatar.js");
            var jsCode = File.ReadAllText(jsFilePath);
            jsExecutor.ExecuteScript($"{jsCode}", base64Image);
        }
    }
}
