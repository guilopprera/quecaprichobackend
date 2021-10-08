namespace QueCapricho.Domain.Entities
{
    public class Telefone
    {
        public int TelefoneId { get; set; }
        public int ClienteId { get; set; }
        public string Numero { get; set; }
    }
}