using System.ComponentModel.DataAnnotations;

namespace Travel.Application.Dtos.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Username { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}