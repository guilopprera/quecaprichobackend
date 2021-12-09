using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface ICategoriaProdutoAppService
    {
        void AdicionarAsync(CategoriaProduto categoriaProduto);
        void Alterar(CategoriaProduto categoriaProduto);
        void Remover(int categoriaProdutoId);
        CategoriaProduto Obter(int categoriaProdutoId);
        List<CategoriaProduto> ObterTodos();
    }
}
