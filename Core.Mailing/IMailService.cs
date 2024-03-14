
namespace Core.Mailing;

public interface IMailService
{
    public Task SendMailAsync(Mail mail);
}