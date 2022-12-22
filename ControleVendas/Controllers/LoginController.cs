using ControleVendas.Models.Inputs;
using ControleVendas.Models.Views;
using ControleVendas.Repositories.Users;
using ControleVendas.Services;
using ControleVendas.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace ControleVendas.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _service;
        public LoginController(IUserService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> LoginAsync([FromBody]LoginInput login)
        {
            if (login == null || string.IsNullOrEmpty(login.Email) || string.IsNullOrEmpty(login.Password))
            {
                BadRequest($"Email e Password devem ser informados.");
            }

            var user = await _service.GetAsync(login.Email, login.Password);

            if (user == null)
                return NotFound("Email ou senha inválidos");

            var token = TokenService.GenerateToken(user);

            return new
            {
                user = (UserView)user,
                Token = token
            };
        }
    }
}
