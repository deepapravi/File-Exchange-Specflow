using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using NUnit.Framework;
using BoDi;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using OpenQA.Selenium.Interactions;
//using AventStack.ExtentReports.Configuration;

namespace Aspire_RS_FileExchangeTest
{
    [Binding]
    public class WebConnector
    {
        //Selenium code
        public ChromeDriver driver = null;
        private readonly IObjectContainer objectContainer;
        public WebConnector(IObjectContainer objectContainer)
        {

            this.objectContainer = objectContainer;

        }
        public IWebDriver getDriver()
        {

            return driver;
        }

        public void openBrowser(string bType)
        {


            if (bType.Equals("Chrome"))
            {
                String dir = AppDomain.CurrentDomain.BaseDirectory;
                FileInfo fileInfo = new FileInfo(dir);
                DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
                string parentDirName = currentDir.FullName;
                driver = new ChromeDriver(parentDirName + "\\Chrome");
                driver.Manage().Window.Maximize();
            }
            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);



        }
        public void navigate(string url)
        {
            driver.Url = System.Configuration.ConfigurationManager.AppSettings[url];

        }
        public void click(string xpathExpKey)
        {


            getElement(xpathExpKey).Click();


        }



        public void type(string xpathExpKey, string data)
        {

            getElement(xpathExpKey).SendKeys(data);
        }

        public bool isElementPresent(string locatorkey)
        {
            IList<IWebElement> elementList = null;
            try
            {


                if (locatorkey.EndsWith("_Xpath"))
                {
                    elementList = driver.FindElements(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    elementList = driver.FindElements(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    elementList = driver.FindElements(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {
                    elementList = driver.FindElements(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Class"))
                {
                    elementList = driver.FindElements(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));

                }
                else
                {

                    // reportFailure("Locator is not correct" + locatorkey);
                    Assert.Fail("Locator not correct" + locatorkey);

                }
            }
            catch (Exception ex)
            {

                //fail test and report the error
                //  reportFailure(ex.Message);
                Assert.Fail("Fail the Test-" + ex.Message);

            }

            if (elementList.Count == 0)

                return false;
            else
                return true;
        }


        public bool IsElementVisible(string locatorkey)

        {
            IWebElement element = getElement(locatorkey);

            bool b = element.Displayed;

            if (b.Equals(true))
            {
                return true;
            }

            return false;
        }

        public bool CheckforElement(string locatorkey)
        {

            IWebElement e = null;
            try
            {
                if (locatorkey.EndsWith("_Xpath"))
                {
                    e = driver.FindElement(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    e = driver.FindElement(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    e = driver.FindElement(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {

                    e = driver.FindElement(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));
                }
                else if (locatorkey.EndsWith("_Class"))
                {

                    e = driver.FindElement(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));

                }




            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }


        public bool CheckforElementExist(string locator)
        {

            IWebElement e = null;
            try
            {

                e = driver.FindElement(By.XPath(locator));

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public IWebElement getElement(string locatorkey)
        {
            IWebElement e = null;
            try
            {
                if (locatorkey.EndsWith("_Xpath"))
                {
                    e = driver.FindElement(By.XPath(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_Id"))
                {
                    e = driver.FindElement(By.Id(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_name"))
                {
                    e = driver.FindElement(By.Name(ConfigurationManager.AppSettings[locatorkey]));

                }
                else if (locatorkey.EndsWith("_link"))
                {

                    e = driver.FindElement(By.LinkText(ConfigurationManager.AppSettings[locatorkey]));
                }
                else if (locatorkey.EndsWith("_Class"))
                {

                    e = driver.FindElement(By.ClassName(ConfigurationManager.AppSettings[locatorkey]));

                }
                else
                {

                    // reportFailure("Locator is not correct" + locatorkey);
                    Assert.Fail("Locator not correct" + locatorkey);

                }
            }
            catch (Exception ex)
            {

                //fail test and report the error
                // reportFailure(ex.Message);
                Assert.Fail("Fail the Test-" + ex.Message);

            }
            return e;
        }

        public string getElementText(string locatorkey)
        {
            IWebElement element = null;
            try
            {
                element = driver.FindElement(By.XPath(locatorkey));
            }
            catch (Exception e)
            {
                Assert.Fail("Fail the Test-");
            }

            return element.Text;

        }

        public void explicitWait(string locator)
        {
            try
            {

                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
                // waitForElement.Until(ExpectedConditions.ElementIsVisible(By.XPath(locator)));
                waitForElement.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath(ConfigurationManager.AppSettings[locator])));
            }

            catch (Exception e)
            {
                //reportFailure(e.Message);
                Assert.Fail("Fail the Test-" + e.Message);

            }
        }

        public void ElementInvisibleExplicitWait(string locator)
        {
            try
            {


                WebDriverWait waitForElement = new WebDriverWait(driver, TimeSpan.FromSeconds(16));
                waitForElement.Until(
                   ExpectedConditions.InvisibilityOfElementLocated(By.XPath(ConfigurationManager.AppSettings[locator])));


            }

            catch (Exception e)
            {
                //reportFailure(e.Message);
                Assert.Fail("Fail the Test-" + e.Message);

            }
        }

        public void scrollDown(int height)
        {

            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("window.scrollBy(0," + height + ")");
            // js1.ExecuteScript("window.scrollBy(0,500)");
        }

        public MediaEntityModelProvider CaptureScreenshotAndReturnModel(string Name)
        {


            Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            string screenshotFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".png";
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;

            file.SaveAsFile(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile, ScreenshotImageFormat.Png);

            return MediaEntityBuilder.CreateScreenCaptureFromPath(@"\\mimas.fft.local\tfs-build-reports\Testresults\Screenshots\" + screenshotFile, Name).Build();


        }



        public void doLogin(string username, string password)
        {
            openBrowser("Chrome");
            navigate("appurl");
            type("Username_Id", username);
            type("Password_Id", password);
            click("LoginButton_Id");



        }

        public bool VerifyFileDownload(string FilePath)

        {
            string profile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            // string expectedFilePath = profile + "\\Downloads\\2021KS4bse.xlsx";

            string expectedFilePath = profile + FilePath;

            bool fileExist = false;
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", profile + "\\Downloads");

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until<bool>(x => fileExist = File.Exists(expectedFilePath));
                FileInfo fileInfo = new FileInfo(expectedFilePath);
                //  Assert.AreEqual(fileInfo.FullName, profile + "\\Downloads\\2021KS4bse.xlsx");

                Assert.AreEqual(fileInfo.FullName, profile + FilePath);
            }
            catch (Exception e)
            {
                // reportFailure(e.Message);
                return false;

            }
            finally
            {
                if (File.Exists(expectedFilePath))
                    File.Delete(expectedFilePath);

            }
            return true;
        }

        public void scrolldown(string locatorkey)
        {
            // IWebElement s = driver.FindElement(By.XPath(locatorkey)); 
            IWebElement s = getElement(locatorkey);
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
            je.ExecuteScript("arguments[0].scrollIntoView(true);", s);
            //return this;
        }

        public void scrollPageDown()
        {
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)driver;
            js1.ExecuteScript("window.scrollBy(0,900)");
        }


        public void MovetoElement(string locatorkey)
        {

            IWebElement s = getElement(locatorkey);
            Actions actions = new Actions(driver);
            actions.MoveToElement(s).Perform();

        }


        public void JavaScriptExecutor(string locatorkey)
        {
            IWebElement e = getElement(locatorkey);

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;

            executor.ExecuteScript("arguments[0].click();", e);


        }
    }
}
