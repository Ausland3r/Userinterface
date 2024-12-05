using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using TestProject1.Utils;

namespace TestProject1.Pages
{

    public class HelpForm : Form
    {
        private const string HiddenClass = "is-hidden";
        private IButton SendToBottom => ElementFactory.GetButton(By.XPath("//*[contains(@class, 'send-to-bottom-button')]"), "Send to bottom");
        private ILabel HelpFormContainer => ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'help-form') and .//*[@class='help-form__container']]"), "Help Form Container");

         public HelpForm() : base(By.XPath("//*[@class='help-form__container']"), "Help Form") {}

        public void CloseForm()
        {
            SendToBottom.Click();
        }

        public bool IsFormHidden()
        {
            return HelpFormContainer.HasClass(HiddenClass);
        }

    }
}
