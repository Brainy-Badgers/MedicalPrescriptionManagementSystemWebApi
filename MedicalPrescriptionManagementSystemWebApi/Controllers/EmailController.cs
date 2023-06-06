using MedicalPrescriptionManagementSystemWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Mail;
using System.Net.Mime;

namespace MedicalPrescriptionManagementSystemWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet("TestEmailApi")]
        public async Task<IActionResult> TestEmailAsync()
        {
            QRCodeGenerator QrGenerator = new QRCodeGenerator();
            QRCodeData QrCodeInfo = QrGenerator.CreateQrCode("https://www.google.lk/", QRCodeGenerator.ECCLevel.Q);
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
            await _emailService.SendEmailAsSystemAsync("medicalprescriptionmanagementr@gmail.com", "Test mail", "This is a test email from MPMS", attachments);
            return Ok();
        }
    }
}
