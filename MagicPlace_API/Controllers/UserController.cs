using MagicPlace_API.Dto;
using MagicPlace_API.Models;
using MagicPlace_API.Respositories.IRespositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicPlace_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private APIResponse _response;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto modelo) 
        {
            var loginResponse = await _userRepository.Login(modelo);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token)) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("User or Password are incorrect");
                return BadRequest(_response);
            }
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            _response.Result = loginResponse;
            return Ok(_response);
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto modelo) 
        {
            var isUserUnic = _userRepository.IsUserUnic(modelo.UserName);
            if (!isUserUnic) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("User already exists");
                return BadRequest(_response);
            }

            var user = await _userRepository.Register(modelo);
            if (user == null) 
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsExitoso = false;
                _response.ErrorMessages.Add("Failed to register user!");
                return BadRequest(_response);
            }
            _response.IsExitoso = true;
            _response.StatusCode = HttpStatusCode.OK;
            return Ok(_response);
        }
    }
}
