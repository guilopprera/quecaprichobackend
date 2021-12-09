using QueCapricho.Domain.Entities;
using System.Threading.Tasks;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void RedefinirSenha(Usuario usuario);
        void EnviarEmailTrocaSenha(string email);

    }
}
