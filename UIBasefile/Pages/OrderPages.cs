using OpenQA.Selenium;

namespace MySeleniumWebProject.UIBasefile.Pages
{
    public class OrderPage
    {
        private readonly IWebDriver driver;

        public OrderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsAtOrderPage()
        {
            // Example check, replace with actual logic
            return driver.Url.Contains("order");
        }

        public void SelectProduct(string productName)
        {
            // Example selector, replace with actual one
            driver.FindElement(By.Id("productDropdown")).SendKeys(productName);
        }

        public void EnterQuantity(int quantity)
        {
            driver.FindElement(By.Id("quantity")).Clear();
            driver.FindElement(By.Id("quantity")).SendKeys(quantity.ToString());
        }

        public void PlaceOrder()
        {
            driver.FindElement(By.Id("placeOrderButton")).Click();
        }

        public bool IsOrderSuccess()
        {
            // Example check, replace with actual logic
            return driver.PageSource.Contains("Order placed successfully");
        }
    }
}