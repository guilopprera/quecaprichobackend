using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Application.Interfaces
{
    public interface IEncomendaAppService
    {
        void Adicionar(Encomenda encomenda);
        void Alterar(Encomenda encomenda);
        void Remover(int encomendaId);
        void Finalizar(int encomendaId);
        Encomenda Obter(int encomendaId);
        List<Encomenda> ObterTodos();
    }
}
