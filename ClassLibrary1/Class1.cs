using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml;
using ClassLibrary1.Object_Repository;
using ClassLibrary1.Configuration;
using log4net;
using System.Threading;


namespace ClassLibrary1
{
    [TestFixture]
    public class Class1
    {
        IWebDriver driver;
        ObjectRepository OR = new ObjectRepository();
        Config cf = new Config();
        ILog log;
        #region Webelements
        IWebElement search_textbox, search_button;
        #endregion

        [SetUp]
        public void initialize()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            //driver.Navigate().GoToUrl("http://www.w3schools.com/html/tryit.asp?filename=tryhtml_checkbox");
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
 
        }
        [Test]
        public void VerifyCorrectTitle()
        {
            string title = driver.Title;
            Assert.AreEqual("Google", title);
            //WritetoXML("Hello");

        }
        [Test]
        public void verifySearch()
        {
            try
            {
                search_textbox = driver.FindElement(By.Id(OR.readXMLFile("Google Search", "Search", "search_textbox", "ObjectRepository.xml")));

                search_textbox.Clear();
                String Searchterm = "Saturday";
                search_textbox.SendKeys(Searchterm);
                search_button = driver.FindElement(By.Name(OR.readXMLFile("Google Search", "Search", "search_button", "ObjectRepository.xml")));
                search_button.Click();
                Thread.Sleep(5000);

                cf.WritetoXML("Google Search", "Search keywords", "searchterm", Searchterm);
                log.Info(Searchterm);
              
                
            }
            catch (Exception e)
            {
                //log.Info(e.Message);
 
            }
           

        }
        [Test]
        public void handlingCheckboxes()
        {
            try
            {
               

                IWebElement frameResult= driver.FindElement(By.Name("iframeResult"));
                driver.SwitchTo().Frame(frameResult);

                IList<IWebElement> Checkboxes= driver.FindElements(By.Name("vehicle"));
                IWebElement vehicleCheckbox;
                
                int vehiclecount = Checkboxes.Count;
                int i = 1;
                Boolean bvalue = false;
                 foreach(IWebElement vehicle in Checkboxes)
                {

                    vehicleCheckbox = driver.FindElement(By.XPath("/html/body/form/input[" + i + "]"));
                     
                    
                    bvalue = Checkboxes.ElementAt(i-1).Selected;
                    if (!bvalue)
                    {
                        vehicleCheckbox.Click();
                    }
                    
                 i++;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        [TearDown]
        public void close()
        {
            driver.Quit();

        }
    }
}
