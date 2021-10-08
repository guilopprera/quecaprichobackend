namespace QueCapricho.Domain.Entities
{
    public class ProdutoFoto
    {
        public int ProdutoId { get; set; }
        public int FotoId { get; set; }
        public bool Apagado { get; set; }
        public Foto Foto { get; set; }
    }
}
