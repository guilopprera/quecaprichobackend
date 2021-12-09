using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;
using System;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace QueCapricho.Application.Services
{
    public class EncomendaAppService : IEncomendaAppService
    {
        private readonly IEncomendaRepository _encomendaRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogRepository _logRepository;

        public EncomendaAppService(IEncomendaRepository encomendaRepository, UserManager<IdentityUser> userManager, ILogRepository logRepository)
        {
            _encomendaRepository = encomendaRepository;
            _userManager = userManager;
            _logRepository = logRepository;
        }

        public void Adicionar(Encomenda encomenda)
        {
            if (encomenda == null)
                return;
            foreach (var encomendaProduto in encomenda.ListaEncomendaProduto) { encomendaProduto.Produto = null; }
            encomenda.DataEncomenda = DateTime.Now;
            _encomendaRepository.Adicionar(encomenda);


            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Encomenda - Adição ID: " + encomenda.EncomendaId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Alterar(Encomenda encomenda)
        {
            if (encomenda == null || encomenda.EncomendaId == 0)
                return;

            _encomendaRepository.Alterar(encomenda);

            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Encomenda - Alteração ID: " + encomenda.EncomendaId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Remover(int encomendaId)
        {
            if (encomendaId == 0)
                return;

            _encomendaRepository.Remover(encomendaId);

            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Encomenda - Remoção ID: " + encomendaId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Finalizar(int encomendaId)
        {
            if (encomendaId == 0)
                return;

            _encomendaRepository.Finalizar(encomendaId);


            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "Encomenda - Finalização ID: " + encomendaId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public Encomenda Obter(int encomendaId)
        {
            if (encomendaId == 0)
                return null;

            return _encomendaRepository.Obter(encomendaId);
        }
        public List<Encomenda> ObterTodos()
        {
            return _encomendaRepository.ObterTodos();
        }
    }
}
