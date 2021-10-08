using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface ITelefoneAppService
    {
        void Adicionar(Telefone telefone);
        void Alterar(Telefone telefone);
        List<Telefone> ObterTodos();
    }
}
