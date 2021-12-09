using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using System.Threading.Tasks;

namespace QueCapricho.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioAppService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void RedefinirSenha(Usuario usuario)
        {
            _usuarioRepository.RedefinirSenha(usuario);
        }

        public void EnviarEmailTrocaSenha(string email)
        {
            _usuarioRepository.EnviarEmailTrocaSenha(email);
        }
    }
}
