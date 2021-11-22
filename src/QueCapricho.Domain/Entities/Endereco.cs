namespace QueCapricho.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int ClienteId { get; set; }
        public string Descricao { get; set; }
        public bool Apagado { get; set; }

    }
}
