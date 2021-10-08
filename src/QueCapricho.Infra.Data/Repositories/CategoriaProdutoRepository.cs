using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class CategoriaProdutoRepository : ICategoriaProdutoRepository
    {
        private readonly MeuContexto _context;

        public CategoriaProdutoRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(CategoriaProduto categoriaProduto)
        {
            _context.CategoriaProdutos.Add(categoriaProduto);
            _context.SaveChanges();
        }

        public void Alterar(CategoriaProduto categoriaProduto)
        {
            var categoriaProdutoDb = _context.CategoriaProdutos.FirstOrDefault(cp => cp.CategoriaProdutoId== categoriaProduto.CategoriaProdutoId);

            categoriaProdutoDb.Nome = categoriaProduto.Nome;

            _context.Entry(categoriaProdutoDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int categoriaProdutoId)
        {
            var categoriaProduto = _context.CategoriaProdutos.FirstOrDefault(cp => cp.CategoriaProdutoId == categoriaProdutoId);

            categoriaProduto.Apagado = true;

            _context.Entry(categoriaProduto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public CategoriaProduto Obter(int categoriaProdutoId)
        {
            return _context.CategoriaProdutos.FirstOrDefault(cp => cp.CategoriaProdutoId == categoriaProdutoId);
        }

        public List<CategoriaProduto> ObterTodos()
        {
            return _context.CategoriaProdutos
                .Where(cp => !cp.Apagado)
                .ToList();
        }
    }
}
