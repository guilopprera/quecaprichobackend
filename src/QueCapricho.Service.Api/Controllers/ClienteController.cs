using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] Cliente cliente)
        {
            _clienteAppService.Adicionar(cliente);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] Cliente cliente)
        {
            _clienteAppService.Adicionar(cliente);
        }

        [HttpPost]
        [Route("Remover")]
        public void Remover([FromBody] int clienteId)
        {
            _clienteAppService.Remover(clienteId);
        }

        [HttpGet]
        [Route("Obter/{clienteId}")]
        public ActionResult<Cliente> Obter(int clienteId)
        {
            return _clienteAppService.Obter(clienteId);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Cliente>> ObterTodos()
        {
            return _clienteAppService.ObterTodos();
        }

        [HttpGet]
        [Route("Pesquisar/{texto}")]
        public ActionResult<List<Cliente>> Pesquisar(string texto)
        {
            return _clienteAppService.Pesquisar(texto);
        }
    }
}
