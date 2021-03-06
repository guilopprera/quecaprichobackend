using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface IProdutoAppService
    {
        void Adicionar(Produto produto);
        void Alterar(Produto produto);
        void Remover(int produtoId);
        Produto Obter(int produtoId);
        List<Produto> ObterTodos();
        List<Produto> Pesquisar(string textoPesquisa);
    }
}
