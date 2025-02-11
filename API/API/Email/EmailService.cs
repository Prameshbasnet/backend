using API.Configurations;
using API.Email.Contracts;
using Common.Common.Response;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp; 
using Common.Common.Handlers;
using MimeKit; 
using Ganss.Xss;
using API.Email.Dtos;
using System.Net;

namespace API.Email
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        private readonly ILogger<EmailService> _logger;
        private readonly IWebHostEnvironment _env;

        public EmailService(IOptions<MailSettings> mailSettingsOptions,
                            ILogger<EmailService> logger,
                            IWebHostEnvironment env)
        {
            _mailSettings = mailSettingsOptions.Value;
            _logger = logger;
            _env = env;
        }

        public async Task SendConfirmationEmail(string userName, string applicationType, string email)
        {
            try
            {
                var sanitizer = new HtmlSanitizer();

                string templatePath = Path.Combine(_env.ContentRootPath, "Notification", "EmailTemplate", "ConfirmationPage.html");
                string templateContent = await File.ReadAllTextAsync(templatePath);

                templateContent = templateContent.Replace("{UserName}", WebUtility.HtmlEncode(userName));
                templateContent = templateContent.Replace("{ApplicationType}", applicationType);

                _logger.LogInformation("Password reset email generated for {email}", email);

                var payload = new HTMLMailRequestDto
                {
                    ToId = email,
                    ToName = userName,
                    Subject = "Application Received",
                    Body = templateContent
                };
                await SendHTMLMail(payload);
                _logger.LogInformation("Confirmation email sent successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending confirmation email: {ex.Message}");
            }
        }

        private async Task<APIResponse> SendHTMLMail(HTMLMailRequestDto htmlMailData)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("No Reply", _mailSettings.UserName)); 
            emailMessage.To.Add(new MailboxAddress(htmlMailData.ToName, htmlMailData.ToId));
            emailMessage.Subject = htmlMailData.Subject;

            emailMessage.Body = new TextPart("html")
            {
                Text = htmlMailData.Body
            };

            return await SendMail(emailMessage);
        }

        private async Task<APIResponse> SendMail(MimeMessage emailMessage)
        {
            try
            {
                using (var smtpClient = new SmtpClient()) 
                {
                    await smtpClient.ConnectAsync(_mailSettings.Server, _mailSettings.Port, useSsl: _mailSettings.EnableSsl);
                    await smtpClient.AuthenticateAsync(_mailSettings.UserName, _mailSettings.Password);

                    await smtpClient.SendAsync(emailMessage);

                    await smtpClient.DisconnectAsync(true);

                    _logger.LogInformation("Email sent successfully to {to} with subject {subject}", emailMessage.To, emailMessage.Subject);

                    return ResponseHandler.GetSuccessResponse("Email sent successfully");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error sending email to {to} with subject {subject}: {error}", emailMessage.To, emailMessage.Subject, ex.Message);
                throw; 
            }
        }
    }
}
