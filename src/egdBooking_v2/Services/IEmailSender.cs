using System.Threading.Tasks;

namespace egdbooking_v2.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
