using QueCapricho.Domain.Entities;
using QueCapricho.Domain.ValueObjects;
using System.Threading.Tasks;

namespace QueCapricho.Application.Interfaces
{
    public interface IUsuarioAppService
    {

        void RedefinirSenha(Usuario usuario);
        void EnviarEmailTrocaSenha(string email);
    }
}
