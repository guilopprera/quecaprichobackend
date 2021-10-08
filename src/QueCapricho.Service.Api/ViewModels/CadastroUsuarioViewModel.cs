using System.ComponentModel.DataAnnotations;

namespace QueCapricho.Service.Api.ViewModels
{
    public class CadastroUsuarioViewModel
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]

        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [MaxLength(14, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido!")]
        [MaxLength(100, ErrorMessage = "O campo {0} precisa ter {1} caracteres")]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
