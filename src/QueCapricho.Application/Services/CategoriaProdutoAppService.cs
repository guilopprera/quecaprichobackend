using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace QueCapricho.Application.Services
{
    public class CategoriaProdutoAppService : ICategoriaProdutoAppService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;
        private readonly ILogRepository _logRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public CategoriaProdutoAppService(ICategoriaProdutoRepository categoriaProdutoRepository,
            ILogRepository logRepository,
        UserManager<IdentityUser> userManager)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
            _userManager = userManager;
            _logRepository = logRepository;
        }

        public async void AdicionarAsync(CategoriaProduto categoriaProduto)
        {
            if (categoriaProduto == null)
                return;

            _categoriaProdutoRepository.Adicionar(categoriaProduto);

            var user = _userManager.Users.First();

            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "CategoriaProduto - Adição id: " + categoriaProduto.CategoriaProdutoId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Alterar(CategoriaProduto categoriaProduto)
        {
            if (categoriaProduto == null || categoriaProduto.CategoriaProdutoId == 0)
                return;

            _categoriaProdutoRepository.Alterar(categoriaProduto);

            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "CategoriaProduto - Alteração ID: " + categoriaProduto.CategoriaProdutoId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Remover(int categoriaProdutoId)
        {
            if (categoriaProdutoId == 0)
                return;

            _categoriaProdutoRepository.Remover(categoriaProdutoId);

            var user = _userManager.Users.First();
            var log = new Log();
            log.UsuarioId = user.Id;
            log.Evento = "CategoriaProduto - Remoção ID: " + categoriaProdutoId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public CategoriaProduto Obter(int categoriaProdutoId)
        {
            if (categoriaProdutoId <= 0)
                return null;

            return _categoriaProdutoRepository.Obter(categoriaProdutoId);
        }

        public List<CategoriaProduto> ObterTodos()
        {
            return _categoriaProdutoRepository.ObterTodos();
        }
    }
}
