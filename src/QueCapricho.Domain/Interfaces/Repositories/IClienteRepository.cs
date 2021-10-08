using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        void Adicionar(Cliente cliente);
        void Alterar(Cliente cliente);
        void Remover(int clienteId);
        Cliente Obter(int clienteId);
        List<Cliente> ObterTodos();
        List<Cliente> Pesquisar(string textoPesquisa);
    }
}
