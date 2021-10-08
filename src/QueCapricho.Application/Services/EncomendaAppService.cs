using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;

namespace QueCapricho.Application.Services
{
    public class EncomendaAppService : IEncomendaAppService
    {
        private readonly IEncomendaRepository _encomendaRepository;

        public EncomendaAppService(IEncomendaRepository encomendaRepository)
        {
            _encomendaRepository = encomendaRepository;
        }

        public void Adicionar(Encomenda encomenda)
        {
            if (encomenda == null)
                return;

            _encomendaRepository.Adicionar(encomenda);
        }

        public void Alterar(Encomenda encomenda)
        {
            if (encomenda == null || encomenda.EncomendaId == 0)
                return;

            _encomendaRepository.Alterar(encomenda);
        }

        public void Remover(int encomendaId)
        {
            if (encomendaId == 0)
                return;

            _encomendaRepository.Remover(encomendaId);
        }

        public void Finalizar(int encomendaId)
        {
            if (encomendaId == 0)
                return;

            _encomendaRepository.Finalizar(encomendaId);
        }

        public Encomenda Obter(int encomendaId)
        {
            if (encomendaId == 0)
                return null;

            return _encomendaRepository.Obter(encomendaId);
        }
        public List<Encomenda> ObterTodos()
        {
            return _encomendaRepository.ObterTodos();
        }
    }
}
