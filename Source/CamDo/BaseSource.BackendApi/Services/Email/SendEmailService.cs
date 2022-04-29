using BaseSource.BackendApi.Services.Helper;
using BaseSource.Data.EF;
using BaseSource.Shared.Constants;
using BaseSource.ViewModels.Admin;
using MailKit.Security;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseSource.BackendApi.Services.Email
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly BaseSourceDbContext _db;
        public SendEmailService(IConfiguration configuration, BaseSourceDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        private async Task SendMail(IdentityMessage message)
        {
            var settings = SettingsData.Get(await _db.Settings.ToListAsync());

            string emailSender = settings.EmailSender;
            string emailPassword = settings.EmailSenderPassword;
            string emailHost = settings.EmailHost;
            int emailPort = Convert.ToInt32(settings.EmailPort);
            bool emailSSL = Convert.ToBoolean(settings.EmailSSL);

            await Send(message, emailSender, emailPassword, emailHost, emailPort, emailSSL);
        }

        private async Task Send(IdentityMessage message, string emailSender, string emailPassword, string emailHost, int emailPort, bool emailSSL)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(SystemConstants.SiteAuthorName, emailSender);
            email.From.Add(new MailboxAddress(SystemConstants.SiteAuthorName, emailSender));
            email.To.Add(MailboxAddress.Parse(message.Destination));
            email.Subject = message.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = message.Body;
            email.Body = builder.ToMessageBody();

            // dùng SmtpClient của MailKit
            using (var smtp = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    smtp.Connect(emailHost, emailPort, SecureSocketOptions.StartTls);
                    smtp.Authenticate(emailSender, emailPassword);
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

        public async Task SendMailConfirmEmail(string username, string email, string userId, string code)
        {

            string host = _configuration.GetValue<string>("WebBaseAddress");
            string url = $"{host}/Account/ConfirmEmail?userId={userId}&code={code}";
            string body = $"Hãy xác nhận địa chỉ email bằng cách <a href='{url}'>bấm vào đây</a>.";

            var message = new IdentityMessage
            {
                Destination = email,
                Subject = $"[{SystemConstants.SiteAuthorName}] Xác nhận Đăng ký",
                Body = body
            };
            await SendMail(message);

        }

        public async Task SendMailResetPassword(string username, string email, string code)
        {
            string host = _configuration.GetValue<string>("WebBaseAddress");
            string url = $"{host}/Account/ResetPassword?code={code}&email={email}";
            var body = $"Vui lòng click <a href='{url}'>vào đây</a> để reset mật khẩu.";

            var message = new IdentityMessage
            {
                Destination = email,
                Subject = $"[{SystemConstants.SiteAuthorName}] Reset your password",
                Body = body
            };
            await SendMail(message);
        }
    }
}
