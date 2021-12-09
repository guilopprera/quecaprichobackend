using Microsoft.AspNetCore.Identity;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Application.Services
{
    public class FluxoCaixaAppService : IFluxoCaixaAppService
    {
        private readonly IFluxoCaixaRepository _fluxoCaixaRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogRepository _logRepository;

        public FluxoCaixaAppService(IFluxoCaixaRepository fluxoCaixaRepository, UserManager<IdentityUser> userManager, ILogRepository logRepository)
        {
            _fluxoCaixaRepository = fluxoCaixaRepository;
            _userManager = userManager;
            _logRepository = logRepository;
        }

        public FluxoCaixa Adicionar(FluxoCaixa fluxoCaixa)
        {
            if (fluxoCaixa == null)
                return null;

            return _fluxoCaixaRepository.Adicionar(fluxoCaixa);


            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "FluxoCaixa - Adição ID: " + fluxoCaixa.FluxoCaixaId;
            log.ValorNovo = fluxoCaixa.Valor;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Alterar(FluxoCaixa fluxoCaixa)
        {
            if (fluxoCaixa == null || fluxoCaixa.FluxoCaixaId == 0)
                return;


            var fluxoCaixaBd = _fluxoCaixaRepository.Obter(fluxoCaixa.FluxoCaixaId);
            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "FluxoCaixa - Alteração ID: " + fluxoCaixa.FluxoCaixaId;
            log.ValorAntigo = fluxoCaixaBd.Valor;
            log.ValorNovo = fluxoCaixa.Valor;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);

            _fluxoCaixaRepository.Alterar(fluxoCaixa);

        }

        public void Remover(int fluxoCaixaId)
        {
            if (fluxoCaixaId == 0)
                return;

            _fluxoCaixaRepository.Remover(fluxoCaixaId);


            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "FluxoCaixa - Remoção ID: " + fluxoCaixaId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public FluxoCaixa Obter(int fluxoCaixaId)
        {
            if (fluxoCaixaId <= 0)
                return null;

            return _fluxoCaixaRepository.Obter(fluxoCaixaId);
        }

        public List<FluxoCaixa> ObterTodos()
        {
            return _fluxoCaixaRepository.ObterTodos();
        }

        public List<FluxoCaixa> Pesquisar(FluxoCaixaRequest fluxoCaixa)
        {
            return _fluxoCaixaRepository.Pesquisar(fluxoCaixa);
        }
    }
}
