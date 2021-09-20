using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
namespace Aspire_RS_FileExchangeTest.StepDefinition
{
    [Binding]
    class UploadTemplateSteps
    {

        WebConnector web;
        public UploadTemplateSteps(WebConnector web)
        {

            this.web = web;
        }

        [Given(@"I click on Upload Template section and select a file")]
        public void GivenIClickOnUploadTemplateSectionAndSelectAFile()
        {
            web.scrollDown(900);
          
            web.click("Uploadsection_Xpath");
        }

        [Then(@"I should be able to see the selected file in the Choose Input box")]
        public void ThenIShouldBeAbleToSeeTheSelectedFileInTheChooseInputBox()
        {
            String dir = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dir);
            DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = currentDir.FullName;

            string FilePath = parentDirName + "\\RS-Uploads\\2021KS4GRS.xlsx";

            try
            {
                web.getElement("ChooseButton_Xpath").SendKeys(FilePath);

            }

            catch (Exception e)
            {

                Assert.Fail("The file does not exist in the directory");
            }


            string expectedFile = "2021KS4GRS.xlsx";

            string actualFile = web.getElement("ChooseButton_Xpath").GetAttribute("value");

            string[] partition1 = actualFile.Split('\\');

            string actualFileName = (partition1[2].Trim());


            Assert.AreEqual(expectedFile, actualFileName, "Incorrect Chosen File");
        }



        [Given(@"I click on Upload Template section and select a file and then upload")]
        public void GivenIClickOnUploadTemplateSectionAndSelectAFileAndThenUpload()
        {
            web.scrolldown("Uploadsection_Xpath");
            web.scrollDown(-500);
            web.click("Uploadsection_Xpath");
            web.scrollDown(300);
            String dir = AppDomain.CurrentDomain.BaseDirectory;
            FileInfo fileInfo = new FileInfo(dir);
            DirectoryInfo currentDir = fileInfo.Directory.Parent.Parent;
            string parentDirName = currentDir.FullName;

            string FilePath = parentDirName + "\\RS-Uploads\\2021KS4GRS.xlsx";

            try
            {
                web.getElement("ChooseButton_Xpath").SendKeys(FilePath);
              //  web.getElement("UploadDescription_Xpath").SendKeys("Test");

            }

            catch (Exception e)
            {

                Assert.Fail("The file does not exist in the directory");
            }




            web.click("ConfirmCheckbox_Xpath");
            web.click("ConfirmBtn_Xpath");

            if (web.CheckforElement("OverwriteText_Xpath").Equals(true))
            {
                web.click("OverwriteUploadBtn_Xpath");


            }

        }

        [Then(@"After the Upload I should be able to see the updated date and time in the last uploaded section")]
        public void ThenAfterTheUploadIShouldBeAbleToSeeTheUpdatedDateAndTimeInTheLastUploadedSection()
        {
            web.explicitWait("FileUploadLabel_Xpath");
            Thread.Sleep(1000);
            DateTime date = DateTime.Now;
            CultureInfo frC = new CultureInfo("fr-FR");
            string CurrentDate = date.ToString("d", frC);
            string CurrentTime = date.ToString("t", frC);
            string ExpectedDate = CurrentDate + " " + CurrentTime;

           

            string onscreenDate = web.getElement("UploadedDateTime_Xpath").Text;

            string[] partition1 = onscreenDate.Split(' ');
            string actualDate = (partition1[0].Trim()) + ' ' + (partition1[1].Trim());



            Assert.AreEqual(ExpectedDate, actualDate, "Last Uploaded date has not been updated");
        }

    }
}
