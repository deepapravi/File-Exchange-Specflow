using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
namespace Aspire_RS_FileExchangeTest
{
    [Binding]
    public sealed class Hooks1
    {
        WebConnector web;
        public Hooks1(WebConnector web)
        {

            this.web = web;
        }

        private static ExtentTest featureName;

        private static ExtentReports extent;
        private static ExtentTest scenario;

        [BeforeTestRun]

        public static void InitializeReport()
        {


            string reportFile = DateTime.Now.ToString().Replace("/", "_").Replace(":", "_").Replace(" ", "_") + ".html";
            //  var htmlReporter = new ExtentHtmlReporter(@"C:\Deepa\Reports\" + reportFile);
            var htmlReporter = new ExtentV3HtmlReporter(@"\\mimas.fft.local\tfs-build-reports\Testresults\FileExchangeUI-TestReport\" + reportFile);

            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();

            extent.AttachReporter(htmlReporter);


        }
        [AfterTestRun]

        public static void TeardownReort()
        {

            extent.Flush();
            Email.sendMail();

        }

        [BeforeFeature]

        public static void BeforeFeature()
        {

            // featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            featureName = extent.CreateTest<Scenario>(FeatureContext.Current.FeatureInfo.Title);


        }

        [AfterStep]

        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {

                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).ToString();
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);

                else if (stepType == "When")

                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);

            }

            else if (ScenarioContext.Current.TestError != null)
            {
                scenario.Log(Status.Info, "Test has failed");
                var mediaEntity = web.CaptureScreenshotAndReturnModel(ScenarioContext.Current.ScenarioInfo.Title.Trim());
                scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, mediaEntity);
            }

        }
        [BeforeScenario]

        public void BeforeScenario()
        {

            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("skip"))
            {

                scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title).Skip("Skippeing the Test");
                Assert.Ignore();

            }
            else
                scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void quit()
        {



            if (web.getDriver() != null)
                web.getDriver().Quit();
        }
    }
}
