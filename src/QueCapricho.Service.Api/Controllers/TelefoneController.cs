using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("api/telefone")]
    public class TelefoneController : Controller
    {
        private readonly ITelefoneAppService _telefoneAppService;
        public TelefoneController(ITelefoneAppService telefoneAppService)
        {
            _telefoneAppService = telefoneAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] Telefone telefone)
        {
            _telefoneAppService.Adicionar(telefone);
        }


        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] Telefone telefone)
        {
            _telefoneAppService.Alterar(telefone);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Telefone>> ObterTodos()
        {
            return _telefoneAppService.ObterTodos();
        }
    }
}
