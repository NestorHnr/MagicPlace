using MagicPlace_API.Dto;
using MagicPlace_API.Models;

namespace MagicPlace_API.Respositories.IRespositories
{
    public interface IUserRepository
    {
        bool IsUserUnic(string userName);

        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        Task<User> Register(RegisterRequestDto registerRequestDto);
    }
}
