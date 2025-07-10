using Docker.DotNet.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutomationTask
{
    public class Tests
    {
        WebDriver driver;
        WebDriverWait wait;

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

        [Test]
        public void dummyTicket()
        {
            By dateOfBirth = By.Id("dob");
            By DepartureDate = By.Id("departon");
            By country = By.CssSelector("select#billing_country");
            By State = By.CssSelector("select#billing_state");

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.dummyticket.com/dummy-ticket-for-visa-application/");
            driver.Manage().Window.Maximize();
            // Fill in the form fields
            driver.FindElement(By.Name("travname")).SendKeys("Test");
            driver.FindElement(By.Name("travlastname")).SendKeys("QA");
            driver.FindElement(dateOfBirth).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.XPath("//option[text()='1997']")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            driver.FindElement(By.XPath("//option[text()='Aug']")).Click();
            driver.FindElement(By.XPath("//a[text()='29']")).Click();
            driver.FindElement(By.Id("sex_1")).Click();
            driver.FindElement(By.Id("traveltype_1")).Click();
            driver.FindElement(By.Id("fromcity")).SendKeys("Cairo");
            driver.FindElement(By.Id("tocity")).SendKeys("London");
            driver.FindElement(DepartureDate).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-year")).Click();
            driver.FindElement(By.XPath("//option[text()='2025']")).Click();
            driver.FindElement(By.CssSelector(".ui-datepicker-month")).Click();
            driver.FindElement(By.XPath("//option[text()='Sep']")).Click();
            driver.FindElement(By.XPath("//a[text()='1']")).Click();
            driver.FindElement(By.Id("billing_phone")).SendKeys("1118765817");
            driver.FindElement(By.Id("billing_email")).SendKeys("Test123@test.com");
            new SelectElement(driver.FindElement(country)).SelectByText("Egypt");
            driver.FindElement(By.CssSelector("input#billing_address_1")).SendKeys("123 Test St");
            driver.FindElement(By.CssSelector("input#billing_address_2")).SendKeys("Test 4B");
            driver.FindElement(By.CssSelector("input#billing_city")).SendKeys("Cairo");
            new SelectElement(driver.FindElement(State)).SelectByText("Cairo");
            driver.FindElement(By.CssSelector("input#billing_postcode")).SendKeys("12345");
            //switch to the iframe for card details
            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("iframe[name^='__privateStripeFrame']")));
            driver.FindElement(By.CssSelector("input#Field-numberInput")).SendKeys("4242424242424242");
            driver.FindElement(By.CssSelector("input#Field-expiryInput")).SendKeys("12/30");
            driver.FindElement(By.CssSelector("input#Field-cvcInput")).SendKeys("123");
            // Switch back to the main content
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("place_order")).Click();
        }
        [Test]
        public void uploadFile()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://aa-practice-test-automation.vercel.app/Pages/uploadFile.html");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement fileInput = wait.Until(drv => drv.FindElement(By.CssSelector("input#regularFileInput")));
            fileInput.SendKeys(@"C:\Users\Ahmed.khalid\Desktop\Dummy screenshot.png");
        }

        [Test]
        public void locateButton()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
            IWebElement addButton = driver.FindElement(By.CssSelector("button[onclick='addElement()']"));
            Console.WriteLine("Button 'onclick' attribute: " + addButton.GetAttribute("onclick"));
            Console.WriteLine("Button text: " + addButton.Text);
            addButton.Click();

            //print location
            var location = addButton.Location;
            Console.WriteLine($"Button Location - X: {location.X}, Y: {location.Y}");

            //Print Size
            var size = addButton.Size;
            Console.WriteLine($"Button Size - Width: {size.Width}, Height: {size.Height}");

            driver.Quit();
        }

        [Test]
        public void checkboxSelected()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://aa-practice-test-automation.vercel.app/Pages/checkbox_Radio.html");
            IWebElement checkbox = driver.FindElement(By.CssSelector("input[type='checkbox']"));
            // Check if the checkbox is selected
            bool isSelected = checkbox.Selected;
            Console.WriteLine("Checkbox selected: " + isSelected);
            Console.WriteLine("Selected checkbox value: " + checkbox.GetAttribute("value"));
            driver.Quit();
        }

        [Test]
        public void shadowDom()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/shadowdom");
            string shadowDomText = driver.FindElement(By.TagName("my-paragraph")).GetShadowRoot().FindElement(By.CssSelector("[name=\"my-text\"]")).Text;
            Console.WriteLine("Shadow DOM Text: " + shadowDomText);
            driver.Quit();
        }

        [Test]
        public void Synchronizations()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/dynamic_loading/2");
            driver.FindElement(By.TagName("button")).Click();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.FindElement(By.CssSelector("#finish h4")).Displayed);
            string txt = driver.FindElement(By.CssSelector("#finish h4")).Text;
            Console.WriteLine("Text: " + txt);
            driver.Quit();
        }

        [Test]
        public void HandlingWindows()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            driver.FindElement(By.CssSelector(".example > a")).Click();
            driver.SwitchTo().Window(driver.WindowHandles.Last());
            string txt = driver.FindElement(By.CssSelector(".example > h3")).Text;
            Console.WriteLine("Text of the new window: " + txt);
            driver.Quit();
        }
        [Test]
        public void frames() { 
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/iframe");
            driver.SwitchTo().Frame("mce_0_ifr");
            IWebElement edit = driver.FindElement(By.Id("tinymce"));
            edit.Clear();
            edit.SendKeys("Frames");
            driver.SwitchTo().DefaultContent();
            driver.Quit();
        }

        [Test]  
        public void nestedFrames()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/nested_frames");
            driver.SwitchTo().Frame("frame-top");
            driver.SwitchTo().Frame("frame-left");
            Console.WriteLine("Left Frame: " + driver.FindElement(By.TagName("body")).Text);
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("frame-middle");
            Console.WriteLine("Middle Frame: " + driver.FindElement(By.Id("content")).Text);
            driver.SwitchTo().ParentFrame();
            driver.SwitchTo().Frame("frame-right");
            Console.WriteLine("Right Frame: " + driver.FindElement(By.TagName("body")).Text);
            driver.SwitchTo().DefaultContent();
            driver.SwitchTo().Frame("frame-bottom");
            Console.WriteLine("Bottom Frame: " + driver.FindElement(By.TagName("body")).Text);
            driver.Quit();
        }

    }


}