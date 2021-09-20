using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

using TechTalk.SpecFlow.Assist;

namespace Aspire_RS_FileExchangeTest.StepDefinition
{
    [Binding]
    class GenericSteps
    {

        WebConnector web;
        public GenericSteps(WebConnector web)
        {

            this.web = web;
        }


        [Given(@"I go to \""(.*)"" https://test.aspire.fft.local/app/fileexchange/home on \""(.*)""")]
        public void GivenIGoToOn(string url, string browser)
        {

            web.openBrowser(browser);
            web.navigate(url);

        }

        [Given(@"I enter \""(.*)"" as \""(.*)""")]
        public void GivenIEnterAs(string obj, string text)
        {
            web.type(obj, text);
        }



        [When(@"I click on \""(.*)""")]
        public void WhenIClickOn(string obj)
        {
            web.click(obj);
            web.explicitWait("RSHomepage_Xpath");
          

        }
    







    }
}
