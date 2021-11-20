using System.Threading.Tasks;
using ApiAuth.Models;
using ApiAuth.Respositories;
using ApiAuth.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiAuth.Controllers
{
  [ApiController]
  [Route("v1")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
        {
            // Recupera o usuario
            var user = UserRepository.Get(model.Username, model.Password);

            // Verifica se o usuario existe
            if(user == null)
            return NotFound(new { mensage = "Usuario ou senha invalidos" });

            // Gerar o Token
            var token = TokenServices.GenerateToken(user);

            // Oculta a senha
            user.Password = "";

            // Retorna os dados
            return new
            {
              user = user,
              token = token
            };
        }
    }
}
