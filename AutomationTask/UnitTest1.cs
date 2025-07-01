using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutomationTask
{
    public class Tests
    {
        WebDriver driver;
        
        [Test]
        public void BasicMethods()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.saucedemo.com/v1/");
            //Get the page Title and orint it
            string title = driver.Title;
            Console.WriteLine("Page Title: " + title);
            //Get the page URL and print it
            string url = driver.Url;
            Console.WriteLine("Page URL: " + url);

            driver.Navigate().GoToUrl("https://www.selenium.dev");
            // Go back to the previous page, then forward again, then refresh the page
            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();
            //Print the current browser window's size and position on the screen.
            var size = driver.Manage().Window.Size;
            Console.WriteLine($"Width: {size.Width}, Height: {size.Height}");
            var postion = driver.Manage().Window.Position;
            Console.WriteLine($"X: {postion.X}, Y: {postion.Y}");
            //Resize the browser window to Width = 1024, Height = 768.
            driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
            //Move the browser window to position X = 200, Y = 150 on the screen.
            driver.Manage().Window.Position = new System.Drawing.Point(200, 150);
            //Maximize the browser window, then switch to full screen.
            driver.Manage().Window.Maximize();
            driver.Manage().Window.FullScreen();
            driver.Close();
            driver.Navigate().GoToUrl("https://example.com");
            driver.Quit();
        }

        [Test]
        public void Locators()
        {
            By firstName = By.Name("firstname");
            By lastName = By.Name("lastname");
            By day = By.Id("day");
            By month = By.Name("birthday_month");
            By year = By.Id("year");
            By email = By.CssSelector("input[name='reg_email__']");
            By password = By.XPath("//input[@id='password_step_input']");


            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/r.php?entry_point=login");
            driver.FindElement(firstName).SendKeys("Ahmed");
            driver.FindElement(lastName).SendKeys("Khaled");
            new SelectElement(driver.FindElement(day)).SelectByText("22");
            new SelectElement(driver.FindElement(month)).SelectByText("Aug");
            new SelectElement(driver.FindElement(year)).SelectByText("2000");
            driver.FindElement(By.CssSelector("input[name='sex'][value='2']")).Click(); //Select male
            //driver.FindElement(By.CssSelector("input[name='sex'][value='1']")).Click(); // Select female
            driver.FindElement(email).SendKeys("Test@test.com");
            driver.FindElement(password).SendKeys("Test@1234");
            Thread.Sleep(3000);

        }
    }
}