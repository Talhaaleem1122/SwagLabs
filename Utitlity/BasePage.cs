using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using System.IO;


namespace SeleniumTest.Utitlity
{
    public class BasePage
    {
        protected IWebDriver driver;
        // reading json file data named Login.json
        string LoginData = File.ReadAllText("../../TestData/Login.json");

        [SetUp]
        public void SetupTest()
        {
            // Parse the JSON data
            JObject jsonObject = JObject.Parse(LoginData);

            // Extract the "browser" values from the "bowser" object
            JObject bowser = (JObject)jsonObject["bowser"];
            string bowsername = (string)bowser["bowser"];

            if (bowsername == "chrome")
            {

                new DriverManager().SetUpDriver(new ChromeConfig());
                driver = new ChromeDriver();

            }
            else if (bowsername == "firefox")
            {

                new DriverManager().SetUpDriver(new FirefoxConfig());
                driver = new FirefoxDriver();
            }

            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            //maximizing the browser window
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDownTest()
        {
            driver.Quit();
        }
    }
}
