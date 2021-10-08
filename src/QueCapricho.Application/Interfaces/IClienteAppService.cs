using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface IClienteAppService
    {
        void Adicionar(Cliente cliente);
        void Alterar(Cliente cliente);
        void Remover(int clienteId);
        Cliente Obter(int clienteId);
        List<Cliente> ObterTodos();
        List<Cliente> Pesquisar(string textoPesquisa);
    }
}
