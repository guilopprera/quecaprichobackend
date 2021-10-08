using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        List<Endereco> ObterTodos();
    }
}
