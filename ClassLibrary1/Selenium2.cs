using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace ClassLibrary1
{
    [TestFixture]
    class Selenium2
    {

        IWebDriver driver = new ChromeDriver();
        IWebElement firstName, LastName, Gender, YrsofExp, Date, ProfessionM,ProfessionA, AutomationTool, Continents, SeleniumCommands;

        

        

        [SetUp]
        public void initialize()
        {
            driver.Navigate().GoToUrl("http://toolsqa.wpengine.com/automation-practice-form/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);


       }

        [Test]
        public void verifyTitle()
        {
            String title = driver.Title;
            Console.WriteLine("Title of the Page   " + title);
            Assert.AreEqual("Google1", title);
        }

        [Test]
        public void VerifyAutomationPracticeform()
        {
            //Applying Inplicit wait- wait for all the elements for the specified time if not immediately present
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));


            //Applying Explicit wait

            WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(By.Name("lastname")));  // waits for the specified time , until the expected conditions are met.



            firstName = driver.FindElement(By.Name("firstname"));
            firstName.SendKeys("Manisa");

            LastName = driver.FindElement(By.Name("lastname"));
            LastName.SendKeys("Maji");

           // Handling Radiobuttons

            Gender = driver.FindElement(By.Id("sex-1"));
            Gender.Click(); //select gender female

            YrsofExp = driver.FindElement(By.Id("exp-3"));
            YrsofExp.Click(); // select years of experience as 3

            // Handling Checkboxes

            ProfessionM = driver.FindElement(By.Id("profession-0"));
            ProfessionA = driver.FindElement(By.Id("profession-1"));

            //Single select drodown
            new SelectElement(driver.FindElement(By.Id("continents"))).SelectByText("Europe");

            //multiple select dropdown

            new SelectElement(driver.FindElement(By.Id("selenium_commands"))).SelectByText("Browser Commands");
            new SelectElement(driver.FindElement(By.Id("selenium_commands"))).SelectByText("Switch Commands");
            Thread.Sleep(5000);
            
            
        }


        

        [TearDown]
        public void close()
        {
            driver.Quit();
        }

    }
}
