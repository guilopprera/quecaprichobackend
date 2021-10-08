using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("api/endereco")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoAppService _enderecoAppService;
        public EnderecoController(IEnderecoAppService enderecoeAppService)
        {
            _enderecoAppService = enderecoeAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] Endereco endereco)
        {
            _enderecoAppService.Adicionar(endereco);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] Endereco endereco)
        {
            _enderecoAppService.Adicionar(endereco);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Endereco>> ObterTodos()
        {
            return _enderecoAppService.ObterTodos();
        }
    }
}
