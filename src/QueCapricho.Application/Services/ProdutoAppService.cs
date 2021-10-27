using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;

namespace QueCapricho.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoAppService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public void Adicionar(Produto produto)
        {
            if (produto == null)
                return;

            _produtoRepository.Adicionar(produto);
        }

        public void Alterar(Produto produto)
        {
            if (produto == null || produto.ProdutoId == 0)
                return;

            _produtoRepository.Alterar(produto);
        }

        public void AlterarEstoque(Estoque estoque)
        {
            if (estoque == null || estoque.ProdutoId == 0)
                return;

            _produtoRepository.AlterarEstoque(estoque);
        }

        public void Remover(int produtoId)
        {
            if (produtoId == 0)
                return;

            _produtoRepository.Remover(produtoId);
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
