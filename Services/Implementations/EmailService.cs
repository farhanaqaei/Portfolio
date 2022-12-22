using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Portfolio2.Dtos;
using Portfolio2.Services.Interfaces;

namespace Portfolio2.Services.Implementations;

public class EmailService : IEmailService
{
    private readonly string? _receiverMail;
    private readonly string? _senderMail;
    private readonly string? _password;
    private readonly string? _host;
    private readonly string? _port;
    private readonly IViewRendererService _viewRenderService;

    public EmailService(IViewRendererService viewRenderService)
    {
        _receiverMail = Environment.GetEnvironmentVariable("ReceiverMail");
        _senderMail = Environment.GetEnvironmentVariable("SenderMail");
        _password = Environment.GetEnvironmentVariable("MailPassword");
        _host = Environment.GetEnvironmentVariable("MailHost");
        _port = Environment.GetEnvironmentVariable("MailPort");
        _viewRenderService = viewRenderService;
    }

    public async Task<bool> SendContactEmail(MailDTO mail)
    {
        try
        {
            var mailBody = await _viewRenderService.RenderToStringAsync("EmailBody", mail);

            var message = new MimeMessage();
            message.Sender = MailboxAddress.Parse(_senderMail);
            message.To.Add(MailboxAddress.Parse(_receiverMail));
            message.Subject = mail.Subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailBody;

            message.Body = bodyBuilder.ToMessageBody();

            var client = new SmtpClient();

            await client.ConnectAsync(_host, Convert.ToInt32(_port), SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_senderMail, _password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
            client.Dispose();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}