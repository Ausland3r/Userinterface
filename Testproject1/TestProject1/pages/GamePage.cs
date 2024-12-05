using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Browsers;


namespace TestProject1.Pages
{
    public class GamePage : Form
    {
        private ILabel TimerLabel => ElementFactory.GetLabel(By.XPath("//*[contains(@class, 'timer')]"), "Timer");
        private IButton AcceptCookie => ElementFactory.GetButton(By.XPath("//*[@type= 'button' and contains(text(), 'Not really, no')]"), "Accept cookie button");
        public GamePage() : base(By.XPath("//*[contains(@class, 'login-form')]"), "GamePage"){}

        public string GetTimerText()
        {
            return TimerLabel.Text;
        }

        public void ClickAcceptCookie()
        {
            AcceptCookie.Click();
        }

        public bool IsCookieOpened()
        {
            return AcceptCookie.State.WaitForDisplayed();
        }
    }
}
