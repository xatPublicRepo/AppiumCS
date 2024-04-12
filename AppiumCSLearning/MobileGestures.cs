using System;
using System.Drawing;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AppiumCSLearning
{
	public class MobileGestures
	{
		public static Point GetCenterOfElement(IWebElement element)
		{
			return new Point((element.Location.X + element.Size.Width) / 2, (element.Location.Y + element.Size.Height) / 2);
		}

		public static void PerformTapByTA(AppiumDriver<IWebElement> driver,IWebElement element)
		{
			
			TouchAction touchAction = new TouchAction(driver);
			touchAction.Tap(element).Perform();


		}
        public static void PerformDoubleTapByTA(AppiumDriver<IWebElement> driver, IWebElement element)
        {
            //Point centerElement = GetCenterOfElement(element);
            new TouchAction(driver).Tap(element).Tap(element).Perform();
            /*Dictionary<string, object> elemeDetails = new Dictionary<string, object>();
            elemeDetails.Add("x", centerElement.X);
            elemeDetails.Add("y", centerElement.Y);
            driver.ExecuteScript("mobile: doubleTap", elemeDetails);*/


        }
        public static void PerformSwipeDownByTA(AppiumDriver<IWebElement> driver)
        {
            Size scr = driver.Manage().Window.Size;
            TestContext.Progress.WriteLine("Height is "+ scr.Height +" Width "+ scr.Width);
            //MultiAction act = new MultiAction(driver);
            TouchAction ta1 = new TouchAction(driver);
            TestContext.Progress.WriteLine("Start "+ scr.Width / 0.8+" , "+scr.Height / 10);
            TestContext.Progress.WriteLine("End  " + scr.Width / 0.8+" , "+ scr.Height / 0.9);
            ta1.Press(scr.Width / 0.8, 20).Wait(1000).MoveTo(scr.Width / 0.8, (scr.Height / 0.9)).Release().Perform();
            



        }

        public static void PerformTapByCommand(AppiumDriver<IWebElement> driver, IWebElement element)
        {
			Point centerOfElement = GetCenterOfElement(element);
			if(driver.GetType().Name.Contains("IOSDriver"))
			{
				TestContext.Progress.WriteLine("Inside IOS");
                Dictionary<string, object> elemeDetails = new Dictionary<string, object>();
                elemeDetails.Add("x", element.Location.X);
                elemeDetails.Add("y", element.Location.Y);

                driver.ExecuteScript("mobile: doubleTap", elemeDetails);
            }
			else
			{
				Dictionary<string, object> elemeDetails = new Dictionary<string, object>();
				elemeDetails.Add("x", element.Location.X);
                elemeDetails.Add("y", element.Location.Y);

                driver.ExecuteScript("mobile: click", elemeDetails);
            }
        }
    }
}

