namespace QueCapricho.Domain.Entities
{
    public class EncomendaProduto
    {
        public int EncomendaProdutoId { get; set; }
        public int EncomendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
