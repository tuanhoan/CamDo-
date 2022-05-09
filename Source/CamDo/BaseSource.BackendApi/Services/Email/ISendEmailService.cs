using BaseSource.ViewModels.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Email
{
    public interface ISendEmailService
    {
        Task SendMailConfirmEmail(MailContentVm mailContent);
        Task SendMailResetPassword(MailContentVm mailContent);
    
    }
}
