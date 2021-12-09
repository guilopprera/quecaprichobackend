using System;
using System.Collections.Generic;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.ValueObjects;

namespace QueCapricho.Application.Interfaces
{
    public interface IFluxoCaixaAppService
    {
        FluxoCaixa Adicionar(FluxoCaixa fluxoCaixa);
        void Alterar(FluxoCaixa fluxoCaixa);
        void Remover(int fluxoCaixaId);
        FluxoCaixa Obter(int fluxoCaixaId);
        List<FluxoCaixa> ObterTodos();
        List<FluxoCaixa> Pesquisar(FluxoCaixaRequest fluxoCaixa);
    }
}
