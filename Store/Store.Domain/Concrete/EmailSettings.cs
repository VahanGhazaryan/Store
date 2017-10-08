using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Concrete
{
   public class EmailSettings
    {
        public string MailToAddress;
        public string MailFromAddress;
        public bool UseSsl;
        public string Username;
        public string Password;
        public string ServerName;
        public int ServerPort;

        public EmailSettings(int type)
        {
            if (type == 1)
            {
                MailToAddress = "vahan.ghazaryan.83@gmail.com";
                MailFromAddress = "vahan.ghazaryan.83@gmail.com";
                UseSsl = true;
                Username = "vahan.ghazaryan.83";
                Password = "qxcawfnjqdazsajy"; 
                ServerName = "smtp.gmail.com";
                ServerPort = 587;
            }
            else
                if (type == 2)
                {
                    MailToAddress = "vahan.ghazaryan.83@gmail.com";
                    MailFromAddress = "somemail@yandex.ru";
                    Username = "somemail@yandex.ru";
                    Password = "password";
                    ServerName = "smtp.yandex.ru";
                    ServerPort = 25;
                    UseSsl = true;
                }

        }
    }
}
