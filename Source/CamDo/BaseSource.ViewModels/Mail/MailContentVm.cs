using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.ViewModels.Mail
{
    public class MailContentVm
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Code { get; set; }
        public string UserID { get; set; }
    }
}
