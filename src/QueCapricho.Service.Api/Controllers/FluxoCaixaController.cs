using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
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
        public void Adicionar([FromBody] FluxoCaixa fluxoCaixa)
        {
            _fluxoCaixaAppService.Adicionar(fluxoCaixa);
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
        public ActionResult<List<FluxoCaixa>> Pesquisar(DateTime dataInicial, DateTime dataFinal, string descricao)
        {
            return _fluxoCaixaAppService.Pesquisar(dataInicial, dataFinal, descricao);
        }
    }
}
