using Microsoft.AspNetCore.Identity;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogRepository _logRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository, UserManager<IdentityUser> userManager, ILogRepository logRepository)
        {
            _produtoRepository = produtoRepository;
            _userManager = userManager;
            _logRepository = logRepository;
        }

        public void Adicionar(Produto produto)
        {
            if (produto == null)
                return;

            _produtoRepository.Adicionar(produto);

            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "Produto - Adição ID: " + produto.ProdutoId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Alterar(Produto produto)
        {
            if (produto == null || produto.ProdutoId == 0)
                return;

            _produtoRepository.Alterar(produto);

            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "Produto - Alteração ID: " + produto.ProdutoId;
            log.DataLog = DateTime.Now;
            _logRepository.AdicionarAsync(log);
        }

        public void Remover(int produtoId)
        {
            if (produtoId == 0)
                return;

            _produtoRepository.Remover(produtoId);

            var log = new Log();
            log.UsuarioId = _userManager.Users.First().Id;
            log.Evento = "Produto - Remoção ID: " + produtoId;
            _logRepository.AdicionarAsync(log);
        }

        public Produto Obter(int produtoId)
        {
            if (produtoId <= 0)
                return null;

            return _produtoRepository.Obter(produtoId);
        }

        public List<Produto> ObterTodos()
        {
            return _produtoRepository.ObterTodos();
        }

        public List<Produto> Pesquisar(string textoPesquisa)
        {
            return _produtoRepository.Pesquisar(textoPesquisa);
        }
    }
}
