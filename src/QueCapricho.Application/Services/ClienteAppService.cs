using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace QueCapricho.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteAppService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Adicionar(Cliente cliente)
        {
            if (cliente == null)
                return;

            _clienteRepository.Adicionar(cliente);
        }

        public void Alterar(Cliente cliente)
        {
            if (cliente == null || cliente.ClienteId == 0)
                return;

            _clienteRepository.Alterar(cliente);
        }

        public void Remover(int clienteId)
        {
            if (clienteId == 0)
                return;

            _clienteRepository.Remover(clienteId);
        }

        public Cliente Obter(int clienteId)
        {
            if (clienteId <= 0)
                return null;

            return _clienteRepository.Obter(clienteId);
        }

        public List<Cliente> ObterTodos()
        {
            return _clienteRepository.ObterTodos();
        }

        public List<Cliente> Pesquisar(string textoPesquisa)
        {
            return _clienteRepository.Pesquisar(textoPesquisa);
        }
    }
}
