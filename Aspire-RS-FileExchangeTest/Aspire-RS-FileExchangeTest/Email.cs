using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Aspire_RS_FileExchangeTest
{
    [SetUpFixture]
    public static class Email
    {
        //  [OneTimeTearDown]
        public static void sendMail()
        {

            string reportFolder = @"\\mimas.fft.local\tfs-build-reports\Testresults\FileExchangeUI-TestReport\";

            DirectoryInfo DirInfo = new DirectoryInfo(reportFolder);

            FileInfo[] files = DirInfo.GetFiles();
            DateTime lastWrite = DateTime.MinValue;
            FileInfo lastWritenFile = null;

            foreach (FileInfo file in files)
            {
                if (file.LastWriteTime > lastWrite)
                {
                    lastWrite = file.LastWriteTime;
                    lastWritenFile = file;
                }
            }
            Console.WriteLine(lastWritenFile);

            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();
            try
            {
                m.From = new MailAddress("deepa.nair@fft.org.uk", "Deepa");
                m.To.Add(new MailAddress("Marion.Williams@fft.org.uk", "Marion"));

                // m.To.Add(new MailAddress("deepa.nair@fft.org.uk", "Deepa"));

                m.CC.Add(new MailAddress("Suseela.Sarvepalli@fft.org.uk", "Suseela"));
                m.CC.Add(new MailAddress("deepa.nair@fft.org.uk", "Deepa"));
                //similarly BCC

                //   m.Subject = "Automation Test Report on Live APT";
                m.Subject = "ResultService-UI Automation Test Report";
                m.Body = "Please find the Automated Test report attached.\n\n Regards\nDeepa";

                m.Attachments.Add(new Attachment(reportFolder + lastWritenFile));
                //m.Attachments.Add(new Attachment(reportFolder + fi1));

                //m.Attachments.Add(new Attachment(reportFolder + lastWritenFile));

                // sc.Host = "outlook.office365.com";
                sc.Host = "smtp.office365.com";
                sc.Port = 587;
                sc.Credentials = new System.Net.NetworkCredential("DNair@fft.org.uk", "yjycqxhvdrxhrvzx");
                sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
                sc.Send(m);
                // return;
            }
            catch (Exception ex)
            {

                Assert.Fail("Fail the Test-" + ex.Message);

            }
        }

    }
}
