using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;

namespace QueCapricho.Application.Services
{
    public class CategoriaProdutoAppService : ICategoriaProdutoAppService
    {
        private readonly ICategoriaProdutoRepository _categoriaProdutoRepository;

        public CategoriaProdutoAppService(ICategoriaProdutoRepository categoriaProdutoRepository)
        {
            _categoriaProdutoRepository = categoriaProdutoRepository;
        }

        public void Adicionar(CategoriaProduto categoriaProduto)
        {
            if (categoriaProduto == null)
                return;

            _categoriaProdutoRepository.Adicionar(categoriaProduto);
        }

        public void Alterar(CategoriaProduto categoriaProduto)
        {
            if (categoriaProduto == null || categoriaProduto.CategoriaProdutoId == 0)
                return;

            _categoriaProdutoRepository.Alterar(categoriaProduto);
        }

        public void Remover(int produtoId)
        {
            if (produtoId == 0)
                return;

            _categoriaProdutoRepository.Remover(produtoId);
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
