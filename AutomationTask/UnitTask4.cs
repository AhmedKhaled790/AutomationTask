using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTask
{
    public class Test4
    {
        WebDriver driver;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Console.WriteLine("Database Setup ....");
        }
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login"); //base URL for the tests

        }
        [Test, Order(1)]
        [Category("valid")]
        [Category("Smoke")]
        public void login()
        {
            driver.FindElement(By.Id("username")).SendKeys("tomsmith");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.ClassName("radius")).Click();
            Assert.AreEqual("https://the-internet.herokuapp.com/secure", driver.Url, "Url is not as expected");

        }
        [Test, Order(2)]
        [Category("invalid")]
        [Category("Smoke")]
        public void loginInvalid()
        {
            driver.FindElement(By.Id("username")).SendKeys("invalidUser");
            driver.FindElement(By.Id("password")).SendKeys("SuperSecretPassword!");
            driver.FindElement(By.ClassName("radius")).Click();
            string errorMessage = driver.FindElement(By.Id("flash")).Text;
            Assert.True(errorMessage.Contains("Your username is invalid!"), "Error message is not appeared");
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Database Cleanup ....");
        }
    }
}

