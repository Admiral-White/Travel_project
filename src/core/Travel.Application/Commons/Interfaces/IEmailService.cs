using System.Threading.Tasks;
using Travel.Application.Dtos.Email;

namespace Travel.Application.Commons.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailDto emailRequest);
    }
}