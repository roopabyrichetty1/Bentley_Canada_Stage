using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BrowserStack;
namespace TestScript
{
    [TestFixture]
    public class TestCase9: BrowserStackNUnitTest
    {
        public TestCase9() : base() { }

        [Test]
        public void CheckLogoloaded()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
            driver.Manage().Window.Maximize();

            bool logoexists = false;
            Thread.Sleep(3000);
            string output_message = " Logo does not load on Homepage.";
            try
            {
                if (driver.FindElement(By.CssSelector("#site-navigation > div > div.navigation-branding > div > a > img")).Displayed)
                {
                    Console.WriteLine("Logo is displayed");
                    new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                    logoexists = true;
                }

            }
            catch (Exception ex)
            {
                logoexists = false;
                output_message = ex.Message;
            }

            string script_message = "browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" " + output_message + " \"}}";
            if (logoexists)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Home page logo loaded succesfully!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript(script_message);
            }
            Assert.AreEqual(true, logoexists);

        }
    }
}
