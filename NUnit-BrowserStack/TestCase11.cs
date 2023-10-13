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
    public class TestCase11: BrowserStackNUnitTest
    {
        public TestCase11() : base() { }

        [Test]
        public void CheckHeaderExists()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(6000);
            for (int i = 0; i < 10; i++)
            {
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
            }
            Thread.Sleep(1000);
            bool headerexists = false;


            ReadOnlyCollection<IWebElement> item = driver.FindElements(By.CssSelector("#post-10411 > div > div > div"));
            if (item.Count > 0)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Header Section Exists!\"}}");
                headerexists = true;
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Header section unavailable \"}}");
            }
            //Assert.AreEqual(true, headerexists);

            Assert.Equals(true, headerexists);

        }
    }
}
