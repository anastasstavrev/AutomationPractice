namespace AutomationPractice
{
    using AutomationPractice.Pages.HomePage;
    using AutomationPractice.Pages.ProductPageHTML;
    using AutomationPractice.Pages.ProductPageJavaScript;
    using AutomationPractice.Pages.ProductPageRuby;
    using AutomationPractice.Pages.ShoppingCart;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    [Category("Home Page")]
    public partial class AutomationTestingPractice
    {
        private IWebDriver _driver;
        private PracticeHomePage practiceHomePage;
        private PageRuby pageRuby;
        private PageHTML pageHTML;
        private ShoppingBasket shoppingBasketPage; 
        private PageJavaScript pageJavaScript;
        private IJavaScriptExecutor javaScript;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            pageHTML = new PageHTML(_driver);
            pageRuby = new PageRuby(_driver);
            shoppingBasketPage = new ShoppingBasket(_driver);
            pageJavaScript = new PageJavaScript(_driver);
            practiceHomePage = new PracticeHomePage(_driver);
            practiceHomePage.NavigateTo("http://practice.automationtesting.in/");
            javaScript = (IJavaScriptExecutor)_driver;
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        // Scenarip: Home page with three Sliders only
        public void HomePageWithThreeSlidersOnly()
        { 
            practiceHomePage.ShopButton.Click();
            practiceHomePage.LogoSite.Click();
            var slider3 = practiceHomePage.PhotoSelenium.Displayed;
            Assert.True(slider3);
            
            practiceHomePage.Slider.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var slider1 = practiceHomePage.PhotoHTML.Displayed;
            Assert.True(slider1);

            practiceHomePage.Slider.Click();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var slider2 = practiceHomePage.PhotoJavaScript.Displayed;
            Assert.True(slider2);
        }

        [Test]
        // Scenario: Home page with three Arrivals only
        public void HomePageWithThreeArrivalsOnly()
        {
            practiceHomePage.ShopButton.Click();
            practiceHomePage.LogoSite.Click();

            var firstArrival = practiceHomePage.SeleniumArrivals.Displayed;
            var secondArrival = practiceHomePage.HTMLArrivals.Displayed;
            var thirdArrival = practiceHomePage.JavaScriptArrivals.Displayed;

            Assert.IsTrue(firstArrival);
            Assert.IsTrue(secondArrival);
            Assert.IsTrue(thirdArrival);
            
        }

        [Test]
        // Scenario: Home page - Images in Arrivals should navigate
        public void ImagesInArrivalsShouldNavigateToNextPage()
        {
            practiceHomePage.SeleniumArrivals.Click();
            var url = practiceHomePage.Driver.Url;
            Assert.AreEqual("http://practice.automationtesting.in/product/selenium-ruby/", url);
            
            javaScript.ExecuteScript("window.history.go(-1)");
            practiceHomePage.HTMLArrivals.Click();
            var url2 = practiceHomePage.Driver.Url;
            Assert.AreEqual("http://practice.automationtesting.in/product/thinking-in-html/", url2);

            javaScript.ExecuteScript("window.history.go(-1)");
            practiceHomePage.JavaScriptArrivals.Click();
            var url3 = practiceHomePage.Driver.Url;
            Assert.AreEqual("http://practice.automationtesting.in/product/mastering-javascript/", url3);
            
        }

        [Test]
        // Scenario: Home page - Arrivals-Images-Description
        public void UserShouldBeAbleToAddBookToHisBasketAfterClickingTheArrivalsImages()
        {
            practiceHomePage.SeleniumArrivals.Click();
            var buttonsSelenium = pageRuby.ButtonList; 
            foreach (var button in buttonsSelenium)
            {
                if (button != null && button.GetAttribute("type") != null)
                {
                    if (button.GetAttribute("type").Contains("submit")) 
                    {
                        button.Click();
                    }
                }
            }
            
            practiceHomePage.NavigateTo("http://practice.automationtesting.in/");
            practiceHomePage.HTMLArrivals.Click();
            var buttonsHTML = pageHTML.ButtonList;
            foreach (var button in buttonsHTML)
            {
                if (button != null && button.GetAttribute("type") != null)
                {
                    if (button.GetAttribute("type").Contains("submit"))
                    {
                        button.Click();
                    }
                }
            }
        }
        [Test]
        // Scenario: Home page - Arrivals-Images-Description
        public void UserShouldBeAbleToSeeRubyProductDescriptionAfterClickingArrivalsImage()
        {
            practiceHomePage.SeleniumArrivals.Click();
            var descriptionText = pageRuby.DescriptionText.Displayed;
            var descriptionTitle = pageRuby.DescriptionTitle.Displayed;
            
            Assert.IsTrue(descriptionText);
            Assert.IsTrue(descriptionTitle);
        }

        [Test]
        // Scenario: Home page - Arrivals-Images-Description
        public void UserShouldBeAbleToSeeJavaScriptProductDescriptionAfterClickingArrivalsImage()
        {
            practiceHomePage.JavaScriptArrivals.Click();
            var descriptionText = pageJavaScript.DescriptionText.Displayed;
            var descriptionTitle = pageJavaScript.DescriptionTitle.Displayed;

            Assert.IsTrue(descriptionText);
            Assert.IsTrue(descriptionTitle);
        }
        [Test]
        // Scenario: Home page - Arrivals-Images-Description
        public void UserShouldBeAbleToSeeHTMLProductDescriptionAfterClickingArrivalsImage()
        {
            practiceHomePage.HTMLArrivals.Click();
            var descriptionText = pageHTML.DescriptionText.Displayed;
            var descriptionTitle = pageHTML.DescriptionTitle.Displayed;

            Assert.IsTrue(descriptionText);
            Assert.IsTrue(descriptionTitle);
        }
        [Test]
        // Scenario: Home page - Arrivals-Images-Reviews
        public void ReviewShouldBeVisibleForSeleniumRubyProduct()
        {
            practiceHomePage.SeleniumArrivals.Click();
            pageRuby.Review.Click();

            var reviewTitle = pageRuby.ReviewTitle.Displayed;
            var reviewComments = pageRuby.ReviewComments.Displayed;

            Assert.IsTrue(reviewTitle);
            Assert.IsTrue(reviewComments);
        }

        [Test]
        // Scenario: Home page - Arrivals-Images-Reviews
        public void ReviewShouldBeVisibleForHTMLProduct()
        {
            practiceHomePage.HTMLArrivals.Click();
            pageHTML.Review.Click();

            var reviewTitle = pageHTML.ReviewTitle.Displayed;
            var reviewComments = pageHTML.ReviewComments.Displayed;

            Assert.IsTrue(reviewTitle);
            Assert.IsTrue(reviewComments);
        }

        [Test]
        // Scenario: Home page - Arrivals-Images-Reviews
        public void ReviewSchouldBeVisibleForJavaScriptProduct()
        {
            practiceHomePage.JavaScriptArrivals.Click();
            pageJavaScript.Review.Click();

            var reviewTitle = pageJavaScript.ReviewTitle.Displayed;
            var reviewComments = pageJavaScript.ReviewComments.Displayed;

            Assert.IsTrue(reviewTitle);
            Assert.IsTrue(reviewComments);
        }

        [Test]
        public void UserShouldBeAbleToAddCouponToHisBasket()
        {
            practiceHomePage.SeleniumArrivals.Click();
            var buttonsSelenium = pageRuby.ButtonList;

            foreach (var button in buttonsSelenium)
            {
                if (button != null && button.GetAttribute("type") != null)
                {
                    if (button.GetAttribute("type").Contains("submit"))
                    {
                        button.Click();
                    }
                }
            }

            pageRuby.ShoppingCart.Click();
            practiceHomePage.AddText(shoppingBasketPage.ShoppingCart, "krishnasakinala");
            shoppingBasketPage.ApplyCoupon.Click();
        }
    }
}
