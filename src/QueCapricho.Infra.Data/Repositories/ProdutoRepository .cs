using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly MeuContexto _context;

        public ProdutoRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
        }

        public void Alterar(Produto produto)
        {
            var produtoDb = _context.Produtos.FirstOrDefault(p => p.ProdutoId == produto.ProdutoId);

            produtoDb.CategoriaProdutoId = produto.CategoriaProdutoId;
            produtoDb.Nome = produto.Nome;
            produtoDb.Valor = produto.Valor;

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AlterarEstoque(Estoque estoque)
        {
            var estoqueProdutoDb = _context.Estoques.FirstOrDefault(e => e.ProdutoId == estoque.ProdutoId);

            estoqueProdutoDb.Quantidade= estoque.Quantidade;

            _context.Entry(estoqueProdutoDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int produtoId)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            produto.Apagado = true;

            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Produto Obter(int produtoId)
        {
            return _context.Produtos
                .Include(p=> p.ProdutoFotos)
                .FirstOrDefault(p => p.ProdutoId == produtoId);
        }

        public List<Produto> ObterTodos()
        {
            return _context.Produtos.Include(p => p.CategoriaProduto)
                .GroupJoin(_context.ProdutoFotos, p => p.ProdutoId, pf => pf.ProdutoId, (p, pf) => new { Produto = p, ProdutoFoto = pf })
                .Select(join => new Produto
                {
                    ProdutoId = join.Produto.ProdutoId,
                    Nome = join.Produto.Nome,
                    Valor = join.Produto.Valor,
                    Ativo = join.Produto.Ativo,
                    Apagado = join.Produto.Apagado,
                    ProdutoFotos = join.ProdutoFoto.ToList()
                })
                .Where(p => !p.Apagado)
                .ToList();
        }
    }
}
