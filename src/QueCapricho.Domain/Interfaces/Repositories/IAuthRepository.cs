using QueCapricho.Domain.Entities;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Usuario Cadastrar(Usuario usuario);
        Usuario Login(Usuario usuario);
        bool VerificarUsuarioExiste(Usuario usuario);
    }
}
