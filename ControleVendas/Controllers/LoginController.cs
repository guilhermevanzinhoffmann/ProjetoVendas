using ControleVendas.Models.Inputs;
using ControleVendas.Models.Views;
using ControleVendas.Repositories;
using ControleVendas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public LoginController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> LoginAsync([FromBody]LoginInput login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
            {
                BadRequest($"Login e Password devem ser informados.");
            }

            var user = _userRepository.Get(login.Username, login.Password);

            if (user == null)
                return NotFound("Usuário ou senha inválidos");

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = (UserView)user,
                Token = token
            };
        }
    }
}
