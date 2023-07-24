using Newtonsoft.Json.Linq;
using NUnit.Framework;
using SeleniumTest.Pages;
using SeleniumTest.Utitlity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SeleniumTest.Tests
{
    [TestFixture]
    public class TestClass : BasePage
    {
        private LoginPage loginPage;
        private CartPage cartPage;
        private CheckoutPage checkoutPage;
        // reading json file data named Login.json
        string LoginData = File.ReadAllText("../../TestData/Login.json");
        // reading json file data named Cart.json
        string CartData = File.ReadAllText("../../TestData/Cart.json");

        [SetUp]
        public void Initialize()
        {

            loginPage = new LoginPage(driver);
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);

        }


        [Test]
        public void ExecuteTest()
        {

            //Login to the application
            loginPage.Login();

            // Extract the items values from the "Items" object
            JObject jsonObject1 = JObject.Parse(CartData);
            JObject Items = (JObject)jsonObject1["Items"];
            string items = (string)Items["Items"];
            Console.WriteLine("items from json file: " + items);

            string[] individual_items = items.Split(',');
            foreach (string individual_item in individual_items)
            {
            //Adding items to the cart 
            cartPage.AddItemTOCart(individual_item);
     
            }
            //Proceeding to checkout page
            cartPage.GoToCartPage();
            cartPage.RemoveItemFromTOCart("Sauce Labs Backpack");
            cartPage.GoToCheckoutPage();

            //Filling checkout form with user details
            checkoutPage.AddCheckoutDetails("First Name", "John");
            checkoutPage.AddCheckoutDetails("Last Name", "Stephen");
            checkoutPage.AddCheckoutDetails("Zip/Postal Code", "5401");
            checkoutPage.ClickContinueButton();

            //Verifying sum of all the items that are being added to the cart
            checkoutPage.VerifyTotalAmount();


        }
        static void Main(string[] args)
        {
        }
    }
}
