namespace AutomationPractice.Pages
{
    using AutomationPractice.Pages.ProductPageRuby;
    using OpenQA.Selenium;
    using System;

    public class BasePage
    {
        public IWebDriver Driver { get; }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo(string url)
        {
            this.Driver.Url = url;
        }

        public void AddText(IWebElement element, string text)
        {
            element.SendKeys(text);
        }
    }
}
