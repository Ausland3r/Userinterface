using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace TestProject1.Pages
{
    public class MainPage : Form
    {
        private ILink StartLink => ElementFactory.GetLink(By.XPath("//*[contains(@class, 'start__link')]"), "Please click HERE to GO to the next page");
        public MainPage() : base(By.XPath("//*[contains(@class, 'start__button')]"), "MainPage"){}

        public void ClickStartLink()
        {
            StartLink.Click();
        }
    }
}
