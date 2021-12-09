using Microsoft.AspNetCore.Identity;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Application.Services
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogRepository _logRepository;

        public ClienteAppService(IClienteRepository clienteRepository, UserManager<IdentityUser> userManager, ILogRepository logRepository)
        {
            _clienteRepository = clienteRepository;
            _userManager = userManager;
            _logRepository = logRepository;
        }

        public void Adicionar(Cliente cliente)
        {
            if (cliente == null)
                return;

            _clienteRepository.Adicionar(cliente);


            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Cliente - Adição ID: " + cliente.ClienteId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Alterar(Cliente cliente)
        {
            if (cliente == null || cliente.ClienteId == 0)
                return;

            _clienteRepository.Alterar(cliente);


            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Cliente - Alteração ID: " + cliente.ClienteId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Remover(int clienteId)
        {
            if (clienteId == 0)
                return;

            _clienteRepository.Remover(clienteId);

            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Cliente - Remoção ID: " + clienteId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);

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
