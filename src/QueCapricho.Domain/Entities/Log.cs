using System;

namespace QueCapricho.Domain.Entities
{
    public class Log
    {
        public int LogId { get; set; }
        public string UsuarioId { get; set; }
        public string Evento { get; set; }
        public decimal ValorAntigo { get; set; }
        public decimal ValorNovo { get; set; }
        public DateTime DataLog { get; set; }
    }
}
