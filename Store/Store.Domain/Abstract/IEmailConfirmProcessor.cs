using Store.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Abstract
{
    public interface IEmailConfirmProcessor
    {
        void Send(EmailSettings emailSettings, string emailTo, string confirmUrl);
    }
}
