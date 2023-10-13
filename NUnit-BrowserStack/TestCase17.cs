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
    public class TestCase17 : BrowserStackNUnitTest
    {
        public TestCase17() : base() { }

        [Test]
        public void PageLoadTime()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");

            var time1 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            string pageloaded = "Webpage load not complete.";
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            string checkpageloadstatus = (string)js.ExecuteScript("return document.readyState");
            Console.WriteLine("Page load status = " + checkpageloadstatus);
            if (checkpageloadstatus == "complete")
            {
                var time2 = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                Console.WriteLine("Pageload time = " + (time2 - time1));
                pageloaded = "Page loaded in " + (time2 - time1).ToString() + " millisecs";
            }


                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" " + pageloaded + "\"}}");
            Assert.Equals("complete", checkpageloadstatus);

        }
    }
}
