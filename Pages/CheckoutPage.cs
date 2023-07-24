using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.Pages
{
    internal class CheckoutPage
    {
        private IWebDriver driver;
        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContinueButton => driver.FindElement(By.Id("continue"));
        public void AddCheckoutDetails(string placeholdername, string inputtext)

        {
            IWebElement InputField = driver.FindElement(By.XPath("//input[@placeholder='" + placeholdername + "']"));
            InputField.SendKeys(inputtext);
        }

        public void ClickContinueButton()

        {
            ContinueButton.Click();
        }

        public void VerifyTotalAmount()

        {
            IReadOnlyCollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class=\"inventory_item_price\"]"));
            decimal expectedtotalamount = 0;
            for (int i = 1; i <= elements.Count; i++)
            {
                Console.WriteLine(i);
                //Getting price of each individual item added on the cart page
                string xpath = "(//div[@class=\"inventory_item_price\"])[" + i + "]";
                IWebElement ItemPrice = driver.FindElement(By.XPath(xpath));
                string text = ItemPrice.Text;
                Console.WriteLine(" Value: " + text);
                //Removing $ sign in price of item
                String text1 = text.Replace("$", "");
                Console.WriteLine(" Value: " + text1);
                //Converting price from string to decimal
                decimal text2 = decimal.Parse(text1);
                expectedtotalamount = expectedtotalamount + text2;
                Console.WriteLine("expected total amount: " + expectedtotalamount);

            }

            // Getting total price of all items displayed on the cart page
            string totalamount = driver.FindElement(By.ClassName("summary_subtotal_label")).Text;
            //Removing $ sign in total price
            string[] words = totalamount.Split('$');
            decimal actualtotalamount = decimal.Parse(words[1]);
            //Printing total price on the console
            Console.WriteLine("actual total amount: " + actualtotalamount);
            //added assertion to check the expected and actual total proice of items
            Assert.AreEqual(expectedtotalamount, actualtotalamount);


        }
    }
}
