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
    public class TestCase26 : BrowserStackNUnitTest
    {
        public TestCase26() : base() { }

        [Test]
        public void CheckChatonPLAXIS()
        {
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com/software/plaxis-designer/");
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
                WebElement iframe_chat = (WebElement)driver.FindElement(By.CssSelector("#hubspot-conversations-iframe"));
                driver.SwitchTo().Frame(iframe_chat);
                try
                {
                    driver.FindElement(By.CssSelector("body > div.widget > div:nth-child(1) > div > span:nth-child(3) > span > div > button")).Click();
                }
                catch(Exception ex)
                { }
                string chattext = driver.FindElement(By.CssSelector("#current-view-component > div > div > div > div > div.ThreadHistoryFetcher__ScrollToWrapper-mpap2q-1.kYFmaz.messages-scroll-container-utv > div > section > div > div:nth-child(1) > div > div > div.PrimaryMessageContent__PrimaryMessageContentWrapper-sc-9irv5-0.cIzKfF > div > div > div > div > div")).Text;
                Console.WriteLine("Text in chat" + chattext );



                if (chattext.Contains("PLAXIS"))
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
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Chat loaded succesfully and contains PLAXIS!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Chat failed to load!\"}}");
            }
            Assert.Equals(false, iframeexists);

        }
    }
}
