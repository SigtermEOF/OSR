using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Diagnostics;

namespace OSR
{
    class Email
    {

        public static void Emailer()
        {

            string sSendto = "jlett@company.mail";
            string sMysubject = "test";
            string sMybody = "test";
            string sServer = "email";
            string sFile = string.Format(@"c:\temp\40837.txt");

            MailAddress from = new MailAddress("APSAUTO@ADVANCEDPHOTO.COM", "APS");
            MailAddress to = new MailAddress(sSendto);
            MailMessage message = new MailMessage(from, to);
            message.Subject = sMysubject;
            message.Body = sMybody;
            MailAddress bcc = new MailAddress("thegrump1976@gmail.com");
            message.Bcc.Add(bcc);
            Attachment data = new Attachment(sFile, MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);
            SmtpClient myclient = new SmtpClient(sServer);
            myclient.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                myclient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        public void EmailNew(string sEmailServer, string sNewCntrctrSendToAdd, string sEmailMyBccAdd, string sMysubject, string sMybody)
        {
            string sServer = sEmailServer;
            string sBcc = sEmailMyBccAdd;
            string sSendto = sNewCntrctrSendToAdd;

            MailAddress from = new MailAddress("APSAUTO@ADVANCEDPHOTO.COM", "APS");
            MailAddress to = new MailAddress(sSendto);
            MailMessage message = new MailMessage(from, to);
            message.Subject = sMysubject;
            message.Body = sMybody;
            MailAddress bcc = new MailAddress(sBcc);
            message.Bcc.Add(bcc);
            SmtpClient myclient = new SmtpClient(sServer);
            myclient.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                myclient.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
