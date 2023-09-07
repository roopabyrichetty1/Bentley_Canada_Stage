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
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestScript
{
    [TestFixture]
    public class TestCase14: BrowserStackNUnitTest
    {
        public TestCase14() : base() { }

        [Test]
        public void CheckSubHeaderNavigationExists()
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
            string output_message = "";

           // try
            {
                ReadOnlyCollection<IWebElement> item = driver.FindElements(By.CssSelector("#mega-menu-item-32275 > a"));

                for (int i = 0; i < item.Count; i++)
                {
                    
                    if (item[i].Text != "")
                    {
                        item[i].Click();
                        Thread.Sleep(2000);


                        // ReadOnlyCollection<IWebElement> item_submenu = driver.FindElements(By.CssSelector("#mega-menu-item-15230 > a"));
                        ReadOnlyCollection<IWebElement> item_submenu = driver.FindElements(By.XPath("//*[@id=\"mega-menu-item-32275\"]"));
                        Console.WriteLine("elements count is - " + item_submenu.Count);
                        foreach(IWebElement item_submenu_item in item_submenu)
                        {
                            Console.WriteLine("These are submenu items" + item_submenu_item.Text);
                            if (item_submenu_item.Text.Contains("Roads and Bridges"))
                            {
                    
                                output_message = "Roads and Bridges";
                            }                             
                        }
                        
                        
                        
                        
                    }
                }




            }
           // catch (Exception ex)
            {


            }



            if (output_message == "Roads and Bridges")
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \"Menu item on header loaded succesful!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \"Header menu item not available \"}}");
            }
            Assert.AreEqual("Roads and Bridges", output_message);

        }
    }
}
