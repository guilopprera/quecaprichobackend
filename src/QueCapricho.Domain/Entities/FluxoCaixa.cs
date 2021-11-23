using QueCapricho.Domain.Enums;
using System;

namespace QueCapricho.Domain.Entities
{
    public class FluxoCaixa
    {
        public int FluxoCaixaId { get; set; }
        public TipoFluxoCaixaEnum Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool Apagado { get; set; }
        public DateTime Data { get; set; }

    }
}
