using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Options;
using MedicalPrescriptionManagementSystemWebApi.Models;
using QRCoder;
using System.Drawing;
using System.Net.Mime;

namespace MedicalPrescriptionManagementSystemWebApi.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailOptions _emailoptions;
        public EmailService(IOptions<EmailOptions> emailOptions)
        {
            _emailoptions = emailOptions.Value;
        }
        public async Task SendEmailAsSystemAsync(string to, string subject, string body)
        {
            var emailClient = new SmtpClient(_emailoptions.Host)
            {
                Port = _emailoptions.Port,
                Credentials = new NetworkCredential(_emailoptions.FromEmail, _emailoptions.FromAppPassword),
                EnableSsl = _emailoptions.EnableSsl
            };

            var message = new MailMessage
            {
                From = new MailAddress(_emailoptions.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(to);
            await emailClient.SendMailAsync(message);
        }

        public async Task SendEmailAsSystemAsync(string to, string subject, string body, List<Attachment> attachments)
        {
            var emailClient = new SmtpClient(_emailoptions.Host)
            {
                Port = _emailoptions.Port,
                Credentials = new NetworkCredential(_emailoptions.FromEmail, _emailoptions.FromAppPassword),
                EnableSsl = _emailoptions.EnableSsl
            };

            var message = new MailMessage
            {
                From = new MailAddress(_emailoptions.FromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            foreach (var attachment in attachments)
            {
                message.Attachments.Add(attachment);
            }

            message.To.Add(to);
            await emailClient.SendMailAsync(message);
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            var emailClient = new SmtpClient(_emailoptions.Host)
            {
                Port = _emailoptions.Port,
                Credentials = new NetworkCredential(_emailoptions.FromEmail, _emailoptions.FromAppPassword),
                EnableSsl = _emailoptions.EnableSsl
            };

            var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };

            message.To.Add(to);
            await emailClient.SendMailAsync(message);
        }

        public async Task SendQREmailAsSystemAsync(string to, string subject, string body, string qrLink)
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(qrLink, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(QrCodeInfo);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            byte[] qrCodeBytes;

            using (MemoryStream stream1 = new MemoryStream())
            {
                qrCodeImage.Save(stream1, System.Drawing.Imaging.ImageFormat.Png);
                qrCodeBytes = stream1.ToArray();
            }

            MemoryStream stream = new MemoryStream(qrCodeBytes);
            Attachment attach = new Attachment(stream, "qrCode.png");
            attach.TransferEncoding = TransferEncoding.QuotedPrintable;

            List<Attachment> attachments = new List<Attachment>();
            attachments.Add(attach);
            await SendEmailAsSystemAsync(to, subject, body, attachments);
        }
    }
}
