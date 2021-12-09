using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [ApiController]
    [Route("api/fluxocaixa")]
    public class FluxoCaixaControllar: Controller
    {
        private readonly IFluxoCaixaAppService _fluxoCaixaAppService;
        public FluxoCaixaControllar(IFluxoCaixaAppService fluxoCaixaAppService)
        {
            _fluxoCaixaAppService = fluxoCaixaAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public FluxoCaixa Adicionar([FromBody] FluxoCaixa fluxoCaixa)
        {
            return _fluxoCaixaAppService.Adicionar(fluxoCaixa);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] FluxoCaixa fluxoCaixa)
        {
            _fluxoCaixaAppService.Alterar(fluxoCaixa);
        }

        [HttpPost]
        [Route("Remover")]
        public void Remover([FromBody] int fluxoCaixaId)
        {
            _fluxoCaixaAppService.Remover(fluxoCaixaId);
        }

        [HttpGet]
        [Route("Obter/{clienteId}")]
        public ActionResult<FluxoCaixa> Obter(int fluxoCaixaId)
        {
            return _fluxoCaixaAppService.Obter(fluxoCaixaId);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<FluxoCaixa>> ObterTodos()
        {
            return _fluxoCaixaAppService.ObterTodos();
        }

        [HttpPost]
        [Route("Pesquisar")]
        public ActionResult<List<FluxoCaixa>> Pesquisar(FluxoCaixaRequest fluxoCaixa)
        {
            return _fluxoCaixaAppService.Pesquisar(fluxoCaixa);
        }
    }
}
