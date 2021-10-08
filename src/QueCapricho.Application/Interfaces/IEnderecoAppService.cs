using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface IEnderecoAppService
    {
        void Adicionar(Endereco endereco);
        void Alterar(Endereco endereco);
        List<Endereco> ObterTodos();
    }
}
