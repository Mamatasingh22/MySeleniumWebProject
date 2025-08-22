using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MySeleniumWebProject.UITestFile
{
    [TestClass]
    public class NewBaseType
    {
        protected static IWebDriver driver;

        [ClassInitialize]
        public static void ClassSetUp(TestContext context)
        {
            var options = new ChromeOptions();
            // Add any desired options here, e.g., headless mode
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://yourwebsite.com"); // Replace with your target URL
        }

        [ClassCleanup]
        public static void ClassTearDown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }
    }

    [TestClass]
    public class OrderTest : NewBaseType
    {

        [TestMethod]
        public void PlaceOrder_ShouldSucceed()
        {
            // Example: Login
            driver.FindElement(By.Id("username")).SendKeys("testuser");
            driver.FindElement(By.Id("password")).SendKeys("password");
            driver.FindElement(By.Id("loginButton")).Click();

            // Example: Navigate to order page
            driver.FindElement(By.Id("orderPageLink")).Click();

            // Example: Fill order form
            driver.FindElement(By.Id("product")).SendKeys("Sample Product");
            driver.FindElement(By.Id("quantity")).SendKeys("2");
            driver.FindElement(By.Id("placeOrderButton")).Click();

            // Example: Assert order confirmation
            var confirmation = driver.FindElement(By.Id("orderConfirmation")).Text;
            Assert.IsTrue(confirmation.Contains("Order placed successfully"), "Order was not placed successfully");
        }
    }
}