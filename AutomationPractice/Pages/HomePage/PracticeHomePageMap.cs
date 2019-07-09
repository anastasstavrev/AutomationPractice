namespace AutomationPractice.Pages.HomePage
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public partial class PracticeHomePage
    {
        public IWebElement ShopButton => Driver.FindElement(By.Id("menu-item-40"));

        public IWebElement LogoSite => Driver.FindElement(By.Id("site-logo"));

        public IWebElement PhotoSelenium => Driver.FindElement(By.XPath("//*[@id=\"n2-ss-6\"]/div[1]/div/div/div[1]/div[1]/img"));

        public IWebElement PhotoHTML => Driver.FindElement(By.XPath("//*[@id=\"n2-ss-6\"]/div[1]/div/div/div[2]/div[1]/img"));

        public IWebElement PhotoJavaScript => Driver.FindElement(By.XPath("//*[@id=\"n2-ss-6\"]/div[1]/div/div/div[2]/div[1]/img"));

        public IWebElement Slider => Driver.FindElement(By.XPath("//*[@id=\"n2-ss-6-arrow-next\"]/img"));

        public IWebElement SeleniumArrivals => Driver.FindElement(By.XPath("//*[@id=\"text-22-sub_row_1-0-2-0-0\"]/div/ul/li/a[1]/img"));

        public IWebElement HTMLArrivals => Driver.FindElement(By.XPath("//*[@id=\"text-22-sub_row_1-0-2-1-0\"]/div/ul/li/a[1]/img"));

        public IWebElement JavaScriptArrivals => Driver.FindElement(By.XPath("//*[@id=\"text-22-sub_row_1-0-2-2-0\"]/div/ul/li/a[1]/img"));

        
    }
}
