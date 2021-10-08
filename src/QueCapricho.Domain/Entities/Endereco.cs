namespace QueCapricho.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string ClienteId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

    }
}
