using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace BrowserStack
{
  [TestFixture]
  public class BrowserStackNUnitTest
  {
    protected RemoteWebDriver driver;

    public BrowserStackNUnitTest()
    {
    }

    [SetUp]
    public void Init()
    {
      DriverOptions capability = new OpenQA.Selenium.Chrome.ChromeOptions();

      capability.BrowserVersion = "latest";

      capability.AddAdditionalOption("bstack:options", capability);
      driver = new RemoteWebDriver(
        new Uri("https://bentleycastg.wpengine.com"),
        capability
      );
    }

    [TearDown]
    public void TearDown()
        {
      driver.Quit();
    }
  }
}
