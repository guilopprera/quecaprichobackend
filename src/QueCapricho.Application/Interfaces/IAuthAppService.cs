using QueCapricho.Domain.Entities;
using QueCapricho.Domain.ValueObjects;
using System.Threading.Tasks;

namespace QueCapricho.Application.Interfaces
{
    public interface IAuthAppService
    {
        Task<UsuarioLoginResult> Cadastrar(Usuario usuario);
        Task<UsuarioLoginResult> Login(Usuario usuario);
    }
}
