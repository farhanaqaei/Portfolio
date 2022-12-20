using Portfolio2.Dtos;

namespace Portfolio2.Services.Interfaces;

public interface IEmailService
{
    Task<bool> SendContactEmail(MailDTO mail);
}
