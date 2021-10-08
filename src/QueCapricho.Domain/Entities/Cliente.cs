using System.Collections.Generic;

namespace QueCapricho.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public bool Apagado { get; set; }
        public virtual List<Endereco> Enderecos { get; set; }
        public virtual List<Telefone> Telefones { get; set; }
    }
}
