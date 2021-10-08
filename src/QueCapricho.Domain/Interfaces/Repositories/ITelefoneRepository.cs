using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface ITelefoneRepository
    {
        void Adicionar(Telefone telefone);
        void Alterar(Telefone telefone);
        List<Telefone> ObterTodos();
    }
}
