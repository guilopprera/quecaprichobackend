using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.ValueObjects;
using System.Threading.Tasks;

namespace QueCapricho.Service.Api.Controllers
{
    [Route("api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthAppService _authAppService;

        public AuthController(IAuthAppService authAppService)
        {
            _authAppService = authAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Cadastrar")]
        public async Task<ActionResult<UsuarioLoginResult>> Cadastrar([FromBody] Usuario usuarioCad)
        {
            if (!ModelState.IsValid) return BadRequest();

            return await _authAppService.Cadastrar(usuarioCad);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<ActionResult<UsuarioLoginResult>> Login([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid) return BadRequest();

            return await _authAppService.Login(usuario);
        }
    }
}
