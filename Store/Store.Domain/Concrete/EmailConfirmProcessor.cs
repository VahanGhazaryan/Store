using Store.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
    public class EmailConfirmProcessor : IEmailConfirmProcessor
    {
        public void Send(EmailSettings emailSettings, string emailTo, string confirmUrl)
        {
            MailAddress from = new MailAddress(emailSettings.MailFromAddress, "Web Registration");
            MailAddress to = new MailAddress(emailTo);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Email confirmation";
            //m.IsBodyHtml = true;
            m.Body = string.Format("Dear customer,"+
                                    "Thank you for registering at the OnlineStore. Before we can activate your account one last "+ 
                                    "step must be taken to complete your registration.Please note - you must complete this last " +
                                    "step to become a registered member. You will only need to visit this URL once to activate your "+ 
                                    "account.To complete your registration, please visit this URL:" +
                                    "{0}"+
                                    "\n All the best, OnlineStore", confirmUrl);
            SmtpClient smtp = new System.Net.Mail.SmtpClient(emailSettings.ServerName, emailSettings.ServerPort);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(emailSettings.Username, emailSettings.Password);
            smtp.EnableSsl = emailSettings.UseSsl;
            smtp.Send(m);
        }
    }
}
