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
    public class TestCase13: BrowserStackNUnitTest
    {
        public TestCase13() : base() { }

        [Test]
        public void CheckHeaderNavigationExists()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
            driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            string output_message = "";
            //try
            {

                IList<IWebElement> all = driver.FindElements(By.CssSelector("#mega-menu-item-5830 > a"));
                foreach (IWebElement element in all)
                {
                    if (element.Text.Contains("Software"))
                    {
                        Console.WriteLine("a hrefs " + element.Text);
                        output_message = element.Text;
                        element.Click();
                    }

                }

            }
            //catch (Exception ex)
            {

                //output_message = ex.Message;
            }



            if (output_message == "Software")
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Menu item on header loaded succesful!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Menu item on header not loaded.\"}}");
            }
            Assert.Equals("Software", output_message);

        }
    }
}
