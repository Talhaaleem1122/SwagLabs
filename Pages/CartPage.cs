using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement YourCartIcon => driver.FindElement(By.ClassName("shopping_cart_link"));
        public IWebElement RemoveFromCartBtn => driver.FindElement(By.XPath("//div[text()='Sauce Labs Backpack']/parent::a/parent::div//button"));
        public IWebElement CheckoutButton => driver.FindElement(By.Id("checkout"));

        public void AddItemTOCart(string itemname)
        {
            //adding item to the cart by clicking on add to the cart button with by the item name in xpath
            Console.WriteLine(">>>>>>>>>: " + itemname);
            IWebElement AddToCartBtn = driver.FindElement(By.XPath("//div[text()='" + itemname + "']/parent::a/parent::div/parent::div//button"));
            AddToCartBtn.Click();
        }

        public void RemoveItemFromTOCart(string itemname)
        {
            //removing item from the cart by clicking on remove to the cart button by specifying the item name in xpath
            IWebElement RemoveFromCartBtn = driver.FindElement(By.XPath("//div[text()='" + itemname + "']/parent::a/parent::div//button"));
            RemoveFromCartBtn.Click();
        }
        public void GoToCartPage()
        {

            YourCartIcon.Click();
        }

        public void GoToCheckoutPage()
        {

            CheckoutButton.Click();
        }
    }
}
