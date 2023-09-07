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
using OpenQA.Selenium.Support.UI;
using BrowserStack;

namespace TestScript
{
    [TestFixture]
    public class TestCase23 : BrowserStackNUnitTest
    {
        public TestCase23() : base() { }

        [Test]
        public void AccessibilityWidgetCheck()
        {
            bool widget_works = false;
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com");
             driver.Manage().Window.Maximize();
            Thread.Sleep(3000);
            Actions a = new Actions(driver);
            for (int i = 0; i < 10; i++)
            {
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();

            }
           
            string word_spacing_before = driver.FindElement(By.TagName("h6")).GetCssValue("word-spacing").ToString();
            Thread.Sleep(3000);
            WebElement Accessibility_icon = (WebElement)driver.FindElement(By.Id("userwayAccessibilityIcon"));
            Accessibility_icon.Click();
            Thread.Sleep(5000);
            WebElement iframe_acc = (WebElement)driver.FindElement(By.CssSelector("body > div.uwy.userway_p6.uon > div:nth-child(2) > iframe"));
            driver.SwitchTo().Frame(iframe_acc);
            driver.FindElement(By.Id("btn-s14")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("body > main > div > div > div:nth-child(1) > div > button")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();
           
            string word_spacing_after = driver.FindElement(By.TagName("h6")).GetCssValue("word-spacing").ToString();

            Thread.Sleep(3000);

            if(word_spacing_before != word_spacing_after)
            {
                widget_works = true;
            }

            if (widget_works == true)
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"passed\", \"reason\": \" Accessibility Widget works as expected!\"}}");
            }
            else
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" Accessibility Widget functionality failed! \"}}");
            }
            Assert.AreEqual(true, widget_works);

        }
    }
}
