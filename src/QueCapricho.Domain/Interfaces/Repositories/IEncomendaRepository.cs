using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface IEncomendaRepository
    {
        void Adicionar(Encomenda encomenda);
        void Alterar(Encomenda encomenda);
        void Remover(int encomendaId);
        void Finalizar(int encomendaId);
        Encomenda Obter(int encomendaId);
        List<Encomenda> ObterTodos();
    }
}
