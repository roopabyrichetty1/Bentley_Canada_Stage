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
    public class TestCase24 : BrowserStackNUnitTest
    {
        public TestCase24() : base() { }

        [Test]
        public void AccessibilityWidgetFontSizeCheck()
        {
            bool widget_works = false;
            driver.Navigate().GoToUrl("https://bentleycastg.wpengine.com/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(6000);
            Actions a = new Actions(driver);
            for (int i = 0; i < 20; i++)
            {
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowDown).Perform();

            }
            for (int i = 0; i < 20; i++)
            {
                new Actions(driver).SendKeys(OpenQA.Selenium.Keys.ArrowUp).Perform();

            }
            Console.WriteLine("Zoom set to before" + driver.FindElement(By.CssSelector("body > div.uw-sl")).GetCssValue("zoom").ToString());

            string font_size_before = driver.FindElement(By.CssSelector("body > div.uw-sl")).GetCssValue("zoom").ToString();
            Thread.Sleep(3000);
            WebElement Accessibility_icon = (WebElement)driver.FindElement(By.Id("userwayAccessibilityIcon"));
            Accessibility_icon.Click();
            Thread.Sleep(5000);
            WebElement iframe_acc = (WebElement)driver.FindElement(By.CssSelector("body > div.uwy.uon.userway_p6 > div:nth-child(2) > iframe"));
            driver.SwitchTo().Frame(iframe_acc);
            driver.FindElement(By.Id("btn-s4")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.CssSelector("body > main > div > div > div:nth-child(1) > div > button")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().DefaultContent();

            string font_size_after = driver.FindElement(By.CssSelector("body > div.uw-sl")).GetCssValue("zoom").ToString();
            Console.WriteLine("Zoom set to after" + driver.FindElement(By.CssSelector("body > div.uw-sl")).GetCssValue("zoom").ToString());
            Thread.Sleep(3000);

            if (font_size_before != font_size_after)
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
            Assert.Equals(true, widget_works);

        }
    }
}
