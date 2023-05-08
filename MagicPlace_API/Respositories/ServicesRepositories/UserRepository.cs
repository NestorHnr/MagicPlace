using MagicPlace_API.DataAdapters;
using MagicPlace_API.Dto;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicPlace_API.Respositories.ServicesRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private string secretKey;

        public UserRepository(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            secretKey = config.GetValue<string>("ApiSettings:Secret");
        }


        public bool IsUserUnic(string userName)
        {
            var usuario = _context.Users.FirstOrDefault(u => u.UserName.ToLower() == userName.ToLower());
            if(usuario == null) 
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower() && 
                                                                     u.Password == loginRequestDto.Password);

            if (user == null) 
            {
                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }
            // Si el usuario existe enviamos un JW Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Rol)
                }),
                Expires = DateTime.UtcNow.AddDays(5),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDto = new()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };
            return loginResponseDto;
        }

        public async Task<User> Register(RegisterRequestDto registerRequestDto)
        {
            User user = new()
            {
                UserName = registerRequestDto.UserName,
                Password = registerRequestDto.Password,
                Names = registerRequestDto.Names,
                Rol = registerRequestDto.Rol,
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            user.Password = "";
            return (user);
        }
    }
}
