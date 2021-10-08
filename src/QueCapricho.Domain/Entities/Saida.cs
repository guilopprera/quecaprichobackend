using System;

namespace QueCapricho.Domain.Entities
{
    public class Saida
    {
        public int SaidaId { get; set; }
        public int EncomendaId { get; set; }
        public DateTime DataSaida { get; set; }
        public string Observacao { get; set; }
        public bool Apagado { get; set; }

    }
}
