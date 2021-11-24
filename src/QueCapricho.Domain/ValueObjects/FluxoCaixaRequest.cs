using System;
using QueCapricho.Domain.Enums;

namespace QueCapricho.Domain.ValueObjects
{
    public class FluxoCaixaRequest
    {
        public object IdentityUsuario { get; set; }
        public string Descricao { get; set; }
        public TipoFluxoCaixaEnum Tipo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
        public bool Apagado { get; set; }
    }
}