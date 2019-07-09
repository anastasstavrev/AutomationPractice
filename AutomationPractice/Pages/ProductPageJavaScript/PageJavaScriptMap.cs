namespace AutomationPractice.Pages.ProductPageJavaScript
{
    using OpenQA.Selenium;

    public partial class PageJavaScript
    {
        public IWebElement ProductDescriptionDiv => Driver.FindElement(By.Id("tab-description"));

        public IWebElement DescriptionTitle => ProductDescriptionDiv.FindElement(By.TagName("h2"));

        public IWebElement DescriptionText => ProductDescriptionDiv.FindElement(By.TagName("p"));

        public IWebElement Review => Driver.FindElement(By.XPath("//*[@id=\"product-165\"]/div[3]/ul/li[2]"));

        public IWebElement ReviewDiv => Driver.FindElement(By.Id("reviews"));

        public IWebElement ReviewTitle => ReviewDiv.FindElement(By.TagName("h2"));

        public IWebElement ReviewComments => Driver.FindElement(By.Id("comments"));
    }
}
