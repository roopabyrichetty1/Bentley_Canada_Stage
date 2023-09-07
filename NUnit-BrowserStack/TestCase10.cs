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
    public class TestCase10: BrowserStackNUnitTest
    {
        public TestCase10() : base() { }

        [Test]
        public void ScrollToTop()
        {
            int offset_Value = 130;
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
            //driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
            driver.Manage().Window.Maximize();
            for (int i = 0; i < 10; i++)
            {
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();
            }
            Thread.Sleep(1000);
            try
            {
                //IWebElement backtotop = driver.FindElement(By.ClassName("generate-back-to-top"));
                IWebElement backtotop = driver.FindElement(By.CssSelector("body > a.generate-back-to-top.generate-back-to-top__show"));
                backtotop.Click();
                Thread.Sleep(1000);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                long value = (long)js.ExecuteScript("return window.pageYOffset;");
                Console.WriteLine("Y offset value " + value);
                offset_Value = (int)value;
                int yposition = (int)value;
            }
            catch (Exception ex)
            {

            }

            if (offset_Value == 0)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Scroll to Top functionality works!\"}}");

            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Scroll to Top functionality does not work.  \"}}");
            }

            Assert.AreEqual(0, offset_Value);

        }
    }
}
