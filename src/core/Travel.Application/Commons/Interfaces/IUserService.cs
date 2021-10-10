using Travel.Application.Dtos.Users;
using Travel.Domain.Entities;

namespace Travel.Application.Commons.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate (AuthenticateRequest model);
        User GetById(int id);
    }
}