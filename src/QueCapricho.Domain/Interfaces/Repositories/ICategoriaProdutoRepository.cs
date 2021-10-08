using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface ICategoriaProdutoRepository
    {
        void Adicionar(CategoriaProduto categoriaProduto);
        void Alterar(CategoriaProduto categoriaProduto);
        void Remover(int categoriaProdutoId);
        CategoriaProduto Obter(int categoriaProdutoId);
        List<CategoriaProduto> ObterTodos();
    }
}
