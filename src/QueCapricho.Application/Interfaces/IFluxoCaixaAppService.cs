using System;
using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface IFluxoCaixaAppService
    {
        void Adicionar(FluxoCaixa fluxoCaixa);
        void Alterar(FluxoCaixa fluxoCaixa);
        void Remover(int fluxoCaixaId);
        FluxoCaixa Obter(int fluxoCaixaId);
        List<FluxoCaixa> ObterTodos();
        List<FluxoCaixa> Pesquisar(DateTime dataInicial, DateTime dataFinal, string descricao);
    }
}
