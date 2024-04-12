using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.iOS;

namespace AppiumCSLearning
{
	public class IOSTests
	{
        AppiumDriver<IWebElement> driver;

        [SetUp]
        public void Setup()
        {
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string appPath = projectDirectory + "/apps/iOS-Simulator-MyRNDemoApp.1.3.0-162.zip";
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("appium:platformName", "iOS");
            options.AddAdditionalCapability("appium:automationName", "XCUITest");
            options.AddAdditionalCapability("appium:deviceName", "iPhone 15 Pro Max");
            options.AddAdditionalCapability("appium:app", appPath);
            options.AddAdditionalCapability("appium:newCommandTimeout", "120000");
            driver = new IOSDriver<IWebElement>(new Uri("http://127.0.0.1:4723"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void IOSTest1()
        {
            TestContext.Progress.WriteLine("App Launched...");
            IWebElement item = driver.FindElementByName("Sauce Labs Backpack");
            Thread.Sleep(2000);
            MobileGestures.PerformTapByTA(driver,item);
            Thread.Sleep(5000);
        }
        [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("App Launched...");
            driver.TerminateApp("com.saucelabs.mydemoapp.rn");
            Thread.Sleep(5000);
            MobileGestures.PerformSwipeDownByTA(driver);
            TestContext.Progress.WriteLine("Swiped Down");
            Thread.Sleep(5000);
        }
        [TearDown]
        public void Teardown()
        {
            //driver.TerminateApp("com.saucelabs.mydemoapp.rn");
            driver.Quit();
        }
    }
}

