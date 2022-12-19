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
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> LoginAsync([FromBody]LoginInput login)
        {
            if (login == null)
            {
                throw new ArgumentNullException(nameof(login));
            }

            var user = UserRepository.GetUser(login.Username, login.Password);

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
