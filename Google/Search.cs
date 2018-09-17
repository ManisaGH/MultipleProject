using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using log4net;
using System.Threading;
using ClassLibrary1;


namespace Google
{
    [TestFixture]
    public class Search
    {

        IWebDriver driver = new ChromeDriver();

        [SetUp]
        public void ChromeSetUp()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

        }

         [Test]
        public void verifySearchGoogle()
        {
                IWebElement search_textbox = driver.FindElement(By.Id("lst-ib"));
                search_textbox.Clear();
                String Searchterm = "Saturday";
                search_textbox.SendKeys(Searchterm);
                search_textbox.SendKeys(OpenQA.Selenium.Keys.Enter);
                Console.WriteLine("Clicked on Searched button");
                Thread.Sleep(5000);

          }

        [TearDown]
        public void close()
        {
            driver.Quit();

        }
    }
}
