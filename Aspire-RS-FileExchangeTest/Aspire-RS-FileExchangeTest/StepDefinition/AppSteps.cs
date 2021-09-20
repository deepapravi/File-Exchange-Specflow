using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Aspire_RS_FileExchangeTest.StepDefinition
{
    [Binding]
    class AppSteps
    {
        WebConnector web;
        public AppSteps(WebConnector web)
        {

            this.web = web;
        }




        [Then(@"I should be able to view the RS Homepage ""(.*)""")]
        public void ThenIShouldBeAbleToViewTheRSHomepage(string expectedResult)
        {
            bool result = web.isElementPresent("RSHomepage_Xpath");
            string actualResult = null;
            if (result)
                actualResult = "Successful";
            else
                actualResult = "Failure";
            Assert.AreEqual(expectedResult, actualResult);
        }


        [Given(@"I login to Aspire as User \(""(.*)"",""(.*)""\) with pemission to Manage Data with ADX status enabled")]
        public void GivenILoginToAspireAsUserWithPemissionToManageDataWithADXStatusEnabled(string username, string password)
        {


            web.doLogin(username, password);
            web.explicitWait("RSHomepage_Xpath");

        }


        [Then(@"I should be able to access the Result Service Module")]
        public void ThenIShouldBeAbleToAccessTheResultServiceModule()
        {
            web.scrollPageDown();
            bool result = web.isElementPresent("Gettemplate_Xpath");
            if (result.Equals(false))
                Assert.Fail("Rs Service Module is not shown");
        }



        [Given(@"I login to Aspire as User \(""(.*)"",""(.*)""\) with pemission to Manage Data with no Setup and ADX status enabled")]
        public void GivenILoginToAspireAsUserWithPemissionToManageDataWithNoSetupAndADXStatusEnabled(string username, string password)
        {
            web.doLogin(username, password);
            web.explicitWait("RSHomepage_Xpath");
        }


        [Given(@"I login to Aspire as User \(""(.*)"",""(.*)""\) without having pemission to Manage Data and ADX status enabled")]
        public void GivenILoginToAspireAsUserWithoutHavingPemissionToManageDataAndADXStatusEnabled(string username, string password)
        {

            web.doLogin(username, password);
            web.explicitWait("RSHomepage_Xpath");
        }

        [Given(@"I login to Aspire as User \(""(.*)"",""(.*)""\) having Manage Data but no ADX status enabled")]
        public void GivenILoginToAspireAsUserHavingManageDataButNoADXStatusEnabled(string username, string password)
        {
            web.doLogin(username, password);
            web.explicitWait("RSHomepage_Xpath");
        }


        [Then(@"I should be able to see the validation ""(.*)""")]
        public void ThenIShouldBeAbleToSeeTheValidation(string Expectedvalidation)
        {
            web.scrollDown(1300);
            Thread.Sleep(2000);
            string Actualvalidation = null;
            if (Expectedvalidation.Equals("Manage Data permissions required"))
                Actualvalidation = web.getElement("ManageDataValidation_Xpath").Text;

            if (Expectedvalidation.Equals("To use this service, you must have Aspire Data Exchange set up by the date shown."))
                Actualvalidation = web.getElement("ValidateADXLabel_Xpath").Text;

            Assert.AreEqual(Expectedvalidation, Actualvalidation);

        }
    }
}