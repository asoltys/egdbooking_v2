using System.Threading.Tasks;

namespace egdbooking_v2.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
