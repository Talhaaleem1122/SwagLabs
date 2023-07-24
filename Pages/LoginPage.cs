using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement UsernameField => driver.FindElement(By.Id("user-name"));
        public IWebElement PasswordField => driver.FindElement(By.Name("password"));
        public IWebElement LoginButton => driver.FindElement(By.Id("login-button"));
        public IWebElement Username => driver.FindElement(By.XPath("//h4[text()='Accepted usernames are:']/parent::div"));
        public IWebElement Password => driver.FindElement(By.XPath("//h4[text()='Password for all users:']/parent::div"));

        public void Login()
        {
            //Gettting user name displayed on the page and assigning it to variable
            string text = Username.Text;
            string[] username = text.Split(':');
            string[] username1  = username[1].Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            Console.WriteLine(" >>>>>>username: " + username1[1]);

            //Gettting user name displayed on the page and assigning it to variable
            string textt = Password.Text;
            string[] password = textt.Split(':');
            Console.WriteLine(" >>>>>>password: " + password[1]);

            // add username to the username field
            UsernameField.SendKeys(username1[1]);
            // add password to the password field
            PasswordField.SendKeys(password[1]);
            //clicking on the login button
            LoginButton.Click();
        }
    }
}
