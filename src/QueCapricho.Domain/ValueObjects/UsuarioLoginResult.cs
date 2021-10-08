using QueCapricho.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace QueCapricho.Domain.ValueObjects
{
    public class UsuarioLoginResult
    {
        public UsuarioLoginResult(Usuario usuario, IdentityUser userIdentity)
        {
            this.Usuario = usuario;
            this.IdentityUsuario = usuario;
        }
        public Usuario Usuario { get; set; }
        public object IdentityUsuario { get; set; }
    }
}