using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace QueCapricho.Domain.Entities
{
    public class ProdutoFoto
    {
        public int ProdutoFotoId { get; set; }
        public int ProdutoId { get; set; }
        public string NomeFoto { get; set; }

        [NotMapped]
        public IFormFile ArquivoFoto { get; set; }
        public bool Apagado { get; set; }
    }
}
