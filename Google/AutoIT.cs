using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Xml;
using log4net;
using System.Threading;
using NUnit.Framework;
using AutoIt;

namespace Google
{
   [TestFixture]
    class AutoIT
    {
       IWebDriver driver;

       String driverName, driverPath;

       [SetUp]
       public void setUp()
       {
           driverName = "webdriver.ie.driver";                                                      // Driver name for IE

           driverPath ="D:\\GitHubRep\\MultipleProject\\MultipleProject\\Google\\bin\\Debug\\IEDriverServer.exe";                                       // Path for IE Driver

           Console.WriteLine("Driver Path:" + driverPath);

           System.Environment.SetEnvironmentVariable(driverName, driverPath);

           InternetExplorerOptions opt = new InternetExplorerOptions();                             // Ensuring Clean IE session

           opt.EnablePersistentHover = true;

           opt.EnsureCleanSession = true;                                                           // The amount of time the driver will attempt to look for a newly launched instance of Internet Explorer

           opt.BrowserAttachTimeout = TimeSpan.FromSeconds(120);

           driver = new InternetExplorerDriver(opt);                                                // Initialize IE driver  

           driver.Manage().Cookies.DeleteAllCookies();

           IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;


           driver.Navigate().GoToUrl("http://192.168.2.74/iettvadmin/AccountMgmt.aspx");
          
       }
       [Test]
       public void accessAdminPortal()
       {

           AutoItX.WinWaitActive("Windows Security");

           Console.WriteLine("Window found");

           AutoItX.Send("Manisa.Maji");
           AutoItX.Send("{TAB}");
           Thread.Sleep(2000);
           AutoItX.Send("Sep@2018");
           AutoItX.Send("{TAB}");
           AutoItX.Send("{TAB}");
           AutoItX.Send("{ENTER}");

           Console.WriteLine("Logged in credentials entered");

       }
       [TearDown]
       public void tearDown()
       {
           driver.Quit();

       }
    }
}
