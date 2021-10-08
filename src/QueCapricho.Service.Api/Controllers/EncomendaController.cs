using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("api/encomenda")]
    public class EncomendaController : Controller
    {
        private readonly IEncomendaAppService _encomendaAppService;
        public EncomendaController(IEncomendaAppService encomendaAppService)
        {
            _encomendaAppService = encomendaAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] Encomenda encomenda)
        {
            _encomendaAppService.Adicionar(encomenda);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] Encomenda encomenda)
        {
            _encomendaAppService.Adicionar(encomenda);
        }

        [HttpPost]
        [Route("Remover")]
        public void Remover([FromBody] int encomendaId)
        {
            _encomendaAppService.Remover(encomendaId);
        }

        [HttpPost]
        [Route("Finalizar")]
        public void Finalizar([FromBody] int encomendaId)
        {
            _encomendaAppService.Finalizar(encomendaId);
        }

        [HttpGet]
        [Route("Obter/{encomendaId}")]
        public ActionResult<Encomenda> Obter(int encomendaId)
        {
            return _encomendaAppService.Obter(encomendaId);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Encomenda>> ObterTodos()
        {
            return _encomendaAppService.ObterTodos();
        }
    }
}
