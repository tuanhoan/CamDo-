using BaseSource.BackendApi.Services.Email;
using BaseSource.Data.EF;
using BaseSource.ViewModels.Mail;
using MailKit.Security;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Email
{
    public class SendEmailService : ISendEmailService
    {
        private readonly MailSettingsVm mailSettings;
        private readonly IConfiguration _configuration;
        private readonly BaseSourceDbContext _db;
        private readonly IWebHostEnvironment _appEnvironment;
        public SendEmailService(IOptions<MailSettingsVm> _mailSettings, IConfiguration configuration, BaseSourceDbContext db, IWebHostEnvironment appEnvironment)
        {
            mailSettings = _mailSettings.Value;
            _configuration = configuration;
            _db = db;
            _appEnvironment = appEnvironment;
        }

        private async Task SendMail(MailContentVm model)
        {
            var mailSetting = new MailSettingsVm();
            var host = _db.Settings.FirstOrDefault(x => x.Id == "EmailHost");
            var portConfig = _db.Settings.FirstOrDefault(x => x.Id == "EmailPort");
            int port = 0;
            if (portConfig != null)
            {
                port = int.Parse(portConfig.Value);
            }
            var emailSender = _db.Settings.FirstOrDefault(x => x.Id == "EmailSender");
            var emailPass = _db.Settings.FirstOrDefault(x => x.Id == "EmailSenderPassword");
            var emailSSL = _db.Settings.FirstOrDefault(x => x.Id == "EmailSSL");
            var displayName = _db.Settings.FirstOrDefault(x => x.Id == "DisplayName");


            mailSetting.Host = host?.Value;
            mailSetting.Mail = emailSender?.Value;
            mailSetting.Password = emailPass?.Value;
            mailSetting.Port = port;
            mailSetting.DisplayName = displayName?.Value;

            var rs = Task.Run(() => CoreSendMail(model, mailSetting));

        }
        public async Task CoreSendMail(MailContentVm model, MailSettingsVm setting)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(setting.DisplayName, setting.Mail);
            email.From.Add(new MailboxAddress(setting.DisplayName, setting.Mail));
            email.To.Add(MailboxAddress.Parse(model.To));
            email.Subject = model.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = model.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    smtp.Connect(setting.Host, setting.Port, SecureSocketOptions.StartTls);
                    smtp.Authenticate(setting.Mail, setting.Password);
                    await smtp.SendAsync(email);
                }
                catch (Exception ex)
                {
                    // Gửi mail thất bại, nội dung email sẽ lưu vào thư mục mailssave
                    System.IO.Directory.CreateDirectory("mailssave");
                    var emailsavefile = string.Format(@"mailssave/{0}.eml", Guid.NewGuid());
                    await email.WriteToAsync(emailsavefile);
                }
                smtp.Disconnect(true);
            }
        }

        public async Task SendMailConfirmEmail(MailContentVm model)
        {
            string host = _configuration.GetValue<string>("WebBaseAddress");
            string url = $"{host}/Account/ConfirmEmail?userId={model.UserID}&code={model.Code}";
            model.Body = $"Hãy xác nhận địa chỉ email bằng cách <a href='{url}'>bấm vào đây</a>.";
            model.Subject = "[Casa] Xác nhận địa chỉ email";
            await SendMail(model);

        }

        public async Task SendMailResetPassword(MailContentVm model)
        {
            string host = _configuration.GetValue<string>("WebBaseAddress");
            string url = $"{host}/Account/ResetPassword?code={model.Code}&email={model.To}";

            model.Body = $"Vui lòng click <a href='{url}'>vào đây</a> để reset mật khẩu.";
            model.Subject = "[Casa] Reset Password";

            await SendMail(model);
        }

        
    }
}
