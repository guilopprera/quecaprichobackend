using System;

namespace QueCapricho.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal RendaMensal { get; set; }
        public decimal SaldoConta { get; set; }
        public bool Apagado { get; set; }
    }
}
