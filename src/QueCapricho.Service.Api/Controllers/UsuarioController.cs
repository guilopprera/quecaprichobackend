using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Threading.Tasks;

namespace QueCapricho.Service.Api.Controllers
{
    [Route("api/usuario")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("RedefinirSenha")]
        public void RedefinirSenha([FromBody] Usuario usuario)
        {
            _usuarioAppService.RedefinirSenha(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("EnviarEmailTrocaSenha")]
        public void EnviarEmailTrocaSenha([FromBody] Usuario usuario)
        {
            _usuarioAppService.EnviarEmailTrocaSenha(usuario.Email);
        }
    }
}
