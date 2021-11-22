using System;
using System.Collections.Generic;
using QueCapricho.Domain.Enums;

namespace QueCapricho.Domain.Entities
{
    public class Encomenda
    {
        public int EncomendaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataEncomenda { get; set; }
        public DateTime DataEntrega { get; set; }
        public decimal Valor { get; set; }
        public FormaPagamentoEnum FormaPagamento { get; set; }
        public bool Ativo { get; set; }
        public bool Cancelado { get; set; }
        public bool Apagado { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<EncomendaProduto> ListaEncomendaProduto { get; set; }
    }
}
