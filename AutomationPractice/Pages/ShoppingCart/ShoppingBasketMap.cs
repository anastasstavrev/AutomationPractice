namespace AutomationPractice.Pages.ShoppingCart
{
    using OpenQA.Selenium;

    public partial class ShoppingBasket
    {
        public IWebElement ShoppingCart => Driver.FindElement(By.Id("coupon_code"));

        public IWebElement ApplyCoupon => Driver.FindElement(By.XPath("//*[@id=\"page-34\"]/div/div[1]/form/table/tbody/tr[2]/td/div/input[2]"));
    }
}
