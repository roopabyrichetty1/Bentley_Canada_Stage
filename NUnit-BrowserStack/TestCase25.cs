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
    public class TestCase25 : BrowserStackNUnitTest
    {
        public TestCase25() : base() { }

        [Test]
        public void CheckYoutubeVideo()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com/software/projectwise/");
            driver.Manage().Window.Maximize();
            bool iframeexists = false;
            string error_message = "Iframe does not exist";
            Thread.Sleep(2000);

            try
            {

                Actions a = new Actions(driver);
                for (int i = 0; i < 10; i++)
                {
                    new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();

                }
                WebElement iframe_youtube = (WebElement)driver.FindElement(By.CssSelector("#section-tzoid-0-1ee09766 > div > div.computer > iframe"));
                                 
                               
                if (iframe_youtube.Displayed)
                {
                    iframeexists = true;
                }
                else
                {
                    error_message = "Iframe does not exist";
                }
            }
            catch (Exception ex)
            {
                iframeexists = false;
                error_message = ex.Message;

            }

           

            if (iframeexists == false)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Iframe with youtube loaded succesfully!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Iframe with youtube failed to load!\"}}");
            }
            Assert.Equals(false, iframeexists);

        }
    }
}
