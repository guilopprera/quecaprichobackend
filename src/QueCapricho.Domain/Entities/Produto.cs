using System.Collections.Generic;

namespace QueCapricho.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public int CategoriaProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Apagado { get; set; }
        public virtual CategoriaProduto CategoriaProduto { get; set; }
        public virtual ProdutoFoto ProdutoFoto { get; set; }
    }
}
