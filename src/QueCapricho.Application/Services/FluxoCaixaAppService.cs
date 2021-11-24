using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace QueCapricho.Application.Services
{
    public class FluxoCaixaAppService : IFluxoCaixaAppService
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;

        public FluxoCaixaAppService(IFluxoCaixaRepository fluxoCaixaRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
        }

        public FluxoCaixa Adicionar(FluxoCaixa fluxoCaixa)
        {
            if (fluxoCaixa == null)
                return null;

            return _fluxoCaixaRepository.Adicionar(fluxoCaixa);
        }

        public void Alterar(FluxoCaixa fluxoCaixa)
        {
            if (fluxoCaixa == null || fluxoCaixa.FluxoCaixaId == 0)
                return;

            _fluxoCaixaRepository.Alterar(fluxoCaixa);
        }

        public void Remover(int fluxoCaixaId)
        {
            if (fluxoCaixaId == 0)
                return;

            _fluxoCaixaRepository.Remover(fluxoCaixaId);
        }

        public FluxoCaixa Obter(int fluxoCaixaId)
        {
            if (fluxoCaixaId <= 0)
                return null;

            return _fluxoCaixaRepository.Obter(fluxoCaixaId);
        }

        public List<FluxoCaixa> ObterTodos()
        {
            return _fluxoCaixaRepository.ObterTodos();
        }

        public List<FluxoCaixa> Pesquisar(FluxoCaixaRequest fluxoCaixa)
        {
            return _fluxoCaixaRepository.Pesquisar(fluxoCaixa);
        }
    }
}
