using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace AppiumCSLearning
{
	public class AppiumTests
	{
        AppiumDriver<IWebElement> driver;
        AppiumServiceBuilder serviceBuilder;
        AppiumLocalService appiumService;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestContext.Progress.WriteLine("Staring Service..");
            serviceBuilder = new AppiumServiceBuilder();
             appiumService = serviceBuilder.Build();
             appiumService.Start();
            TestContext.Progress.WriteLine(appiumService.ServiceUrl);
        }

        [SetUp]
        public void Setup()
        {
            
            string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string appPath = projectDirectory + "/apps/Android-MyDemoAppRN.1.3.0.build-244.apk";
            AppiumOptions options = new AppiumOptions();
            options.AddAdditionalCapability("appium:platformName", "Android");
            options.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            options.AddAdditionalCapability("appium:deviceName", "Pixel7");
            options.AddAdditionalCapability("appium:app", appPath);
            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723"), options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        [Test]
        public void Test1()
        {
            TestContext.Progress.WriteLine("App Launched...");
            Thread.Sleep(2000);
            IWebElement item = driver.FindElementByXPath("//*[@content-desc=\"store item\"]//*[@text='Sauce Labs Backpack']");
            Thread.Sleep(2000);
            MobileGestures.PerformTapByTA(driver, item);
            Thread.Sleep(5000);
        }
       // [Test]
        public void Test2()
        {
            TestContext.Progress.WriteLine("App Launched...");
            Thread.Sleep(2000);
            IWebElement item = driver.FindElementByAccessibilityId("sort button");
            Thread.Sleep(2000);
            MobileGestures.PerformDoubleTapByTA(driver, item);
            Thread.Sleep(5000);
        }
        //[Test]
        public void Test3()
        {
            TestContext.Progress.WriteLine("App Launched...");
            driver.BackgroundApp();
            Thread.Sleep(5000);
            MobileGestures.PerformSwipeDownByTA(driver);
            TestContext.Progress.WriteLine("Swiped Down");
            Thread.Sleep(5000);

            
        }
        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
        [OneTimeTearDown]
        public void OnetimeTearDown()
        {
            appiumService.Dispose();
        }
    }
}

