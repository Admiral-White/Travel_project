using System.Threading.Tasks;

namespace Travel.Application.Commons.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}