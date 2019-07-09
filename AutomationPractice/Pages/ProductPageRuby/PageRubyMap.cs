namespace AutomationPractice.Pages.ProductPageRuby
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class PageRuby
    {
        public IWebElement Content => Driver.FindElement(By.Id("content"));

        public List<IWebElement> ButtonList => Content.FindElements(By.TagName("button")).ToList();

        public IWebElement ProductDescriptionDiv => Driver.FindElement(By.Id("tab-description"));

        public IWebElement DescriptionTitle => ProductDescriptionDiv.FindElement(By.TagName("h2"));

        public IWebElement DescriptionText => ProductDescriptionDiv.FindElement(By.TagName("p"));

        public IWebElement Review => Driver.FindElement(By.XPath("//*[@id=\"product-160\"]/div[3]/ul/li[2]"));

        public IWebElement ReviewDiv => Driver.FindElement(By.Id("reviews"));

        public IWebElement ReviewTitle => ReviewDiv.FindElement(By.TagName("h2"));

        public IWebElement ReviewComments => Driver.FindElement(By.Id("comments"));

        public IWebElement ShoppingCart => Driver.FindElement(By.Id("wpmenucartli"));
    }
}
