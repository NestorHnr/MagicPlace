using MagicPlace_API.Models;

namespace MagicPlace_API.Dto
{
    public class LoginResponseDto
    {
        public User User { get; set; }

        public string Token { get; set; }
    }
}
