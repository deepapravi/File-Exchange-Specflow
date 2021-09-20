using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using System.Globalization;
using System.Threading;


namespace Aspire_RS_FileExchangeTest.StepDefinition
{
    [Binding]
    class DownloadTemplateSteps
    {
        WebConnector web;
        public DownloadTemplateSteps(WebConnector web)
        {

            this.web = web;
        }



        [Then(@"I should  go to the download Template section and should able to download the  GCSE Template")]
        public void ThenIShouldGoToTheDownloadTemplateSectionAndShouldAbleToDownloadTheGCSETemplate()
        {

            web.scrolldown("DownloadGCSEBtn_Xpath");
            web.click("DownloadGCSEBtn_Xpath");
            web.ElementInvisibleExplicitWait("DownloadProcessing_Xpath");
            if (web.VerifyFileDownload("\\Downloads\\2021KS4GRS.xlsx").Equals(false))
            {

                Assert.Fail("Export is not working");

            }

        }

        [Then(@"I should  go to the download Template section and should able to download the  Non-GCSE Template")]
        public void ThenIShouldGoToTheDownloadTemplateSectionAndShouldAbleToDownloadTheNon_GCSETemplate()
        {
            web.scrolldown("DownloadNonGCSEBtn_Xpath");
            web.click("DownloadNonGCSEBtn_Xpath");
            web.ElementInvisibleExplicitWait("DownloadProcessing_Xpath");
            if (web.VerifyFileDownload("\\Downloads\\2021KS4NRS.xlsx").Equals(false))
            {

                Assert.Fail("Export is not working");

            }
        }


        [Given(@"I go to the Download Template section")]
        public void GivenIGoToTheDownloadTemplateSection()
        {
            web.scrolldown("DownloadGCSEBtn_Xpath");

          //  web.click("Downloadsection_Xpath");

        }

        [Then(@"I should be able to see the Last download date and time on screen if the user has done so previously")]
        public void ThenIShouldBeAbleToSeeTheLastDownloadDateAndTimeOnScreenIfTheUserHasDoneSoPreviously()
        {
            Thread.Sleep(1000);
          
            bool result = web.isElementPresent("Lastdownload_Xpath");

            if (result.Equals(false))
                Assert.Fail(" Last download date and time not shown");

        }

        [Given(@"I download the Template for GCSE")]
        public void GivenIDownloadTheTemplateForGCSE()
        {
            web.scrolldown("DownloadGCSEBtn_Xpath");
            web.click("DownloadGCSEBtn_Xpath");

            Thread.Sleep(1000);
          //  web.ElementInvisibleExplicitWait("DownloadProcessing_Xpath");

        }

        [Given(@"I download the Template for Non-GCSE")]
        public void GivenIDownloadTheTemplateForNon_GCSE()
        {
            web.scrolldown("DownloadNonGCSEBtn_Xpath");
            web.click("DownloadNonGCSEBtn_Xpath");

            Thread.Sleep(1000);
        }


        [Then(@"After the Download I should be able to see the updated date and time in the last downloded section")]
        public void ThenAfterTheDownloadIShouldBeAbleToSeeTheCurrentDateAndTimeInTheLastDownlodedSection()
        {
           
           
            DateTime date = DateTime.Now;
            CultureInfo frC = new CultureInfo("fr-FR");
            string CurrentDate = date.ToString("d", frC);
            string CurrentTime = date.ToString("t", frC);
            string ExpectedDate = CurrentDate + " " + CurrentTime;
            string OnscreenDate_Xpath = "//p[contains(text()," + "'" + ExpectedDate + "'" + ")]";

          /*  if (web.VerifyFileDownload("\\Downloads\\2021KS4GRS.xlsx").Equals(false))
            {

                Assert.Fail("Export is not working");

            }*/

          //  web.click("Downloadsection_Xpath");
            Thread.Sleep(2000);
            //  string OnscreenDate_Xpath = "//p[contains(text(),"+"'"+ ExpectedDate+"'"+")]";

            bool result = web.CheckforElementExist(OnscreenDate_Xpath);

            if (result.Equals(false))
                Assert.Fail(" Last download date and time not shown");
           // string onscreenDate = web.getElement("DownloadGCSEDateTime_Xpath").Text;

         //   Assert.AreEqual(ExpectedDate, onscreenDate, "Last download date has not been updated");

        }


    }



}
