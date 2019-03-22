using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTest
{
    class SeleniumDemo
    {
        IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"ChromeWebdriver");
            driver = new ChromeDriver(path);
        }

        [Test]
        public void OpenGoogle()
        {
            driver.Url = "https://www.google.co.uk";
            driver.Manage().Window.Maximize();
            Assert.IsTrue(driver.Url == "https://www.google.co.uk/");
        }

        [Test]
        public void ClickLinkBBc()
        {
            driver.Url = "https://www.bbc.co.uk/news";
            driver.Manage().Window.Maximize();
            IWebElement link = driver.FindElement(By.XPath("//a[@id='idcta-link']"));
            link.Click();
            Assert.IsTrue(driver.Url == "https://account.bbc.com/signin");
        }

        [Test]
        public void TestLoginBbc()
        {
            driver.Url = "https://www.bbc.co.uk/news";
            driver.Manage().Window.Maximize();
            IWebElement link = driver.FindElement(By.XPath("//a[@id='idcta-link']"));
            link.Click();
            Assert.IsTrue(driver.Url == "https://account.bbc.com/signin");
            IWebElement usernameBox = driver.FindElement(By.Id("user-identifier-input"));
            IWebElement passwordBox = driver.FindElement(By.Id("password-input"));
            IWebElement signinButton = driver.FindElement(By.Id("submit-button"));
                        
            usernameBox.SendKeys("dev_test_2@outlook.com");
            passwordBox.SendKeys("Spectrum1234");
            signinButton.Click();

            Assert.IsTrue(driver.Url == "https://www.bbc.co.uk/news");

            IWebElement usernameSpan = driver.FindElement(By.Id("idcta-username"));
            var usernameLoggedIn = usernameSpan.Text;

            Assert.IsTrue(usernameLoggedIn.ToLower() == "dev_test_2");
        }

        [Test]
        public void ClickButtonInput()
        {
            driver.Url = "https://www.google.co.uk";
            driver.Manage().Window.Maximize();
            List<IWebElement> links = driver.FindElements(By.XPath("//input[@name='btnI']")).ToList();
            foreach (var link in links)
            {
                if (link.Displayed == true)
                    link.Click();
            }
            Assert.IsTrue(driver.Url == "https://www.google.com/doodles");
        }

        [Test]
        public void ExecuteJavaScript()
        {
            this.driver.Navigate().GoToUrl(@"https://www.google.co.uk");
            this.WaitUntilLoaded();
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            string title = (string)js.ExecuteScript("return document.title");
            Assert.IsTrue(title == "Google");
        }

        private void WaitUntilLoaded()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until((x) =>
            {
                return ((IJavaScriptExecutor)this.driver)
                .ExecuteScript("return document.readyState").Equals("complete");
            });
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
