using Microsoft.AspNetCore.Identity;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Domain.ValueObjects;
using System.Threading.Tasks;

namespace QueCapricho.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IAuthRepository _authRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AuthAppService(IAuthRepository authRepository,
            UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _authRepository = authRepository;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UsuarioLoginResult> Cadastrar(Usuario usuario)
        {

            if (_authRepository.VerificarUsuarioExiste(usuario))
            {
                return null;
            }

            var identityUser = new IdentityUser { Email = usuario.Email, PasswordHash = usuario.Senha, UserName = usuario.Nome };

            var result = await _userManager.CreateAsync(identityUser, identityUser.PasswordHash);

            await _signInManager.SignInAsync(identityUser, isPersistent: false);

            _authRepository.Cadastrar(usuario);

            var usuarioBd = _authRepository.Login(usuario);

            return new UsuarioLoginResult(usuarioBd, identityUser);
        }

        public async Task<UsuarioLoginResult> Login(Usuario usuario)
        {
            var usuarioBd = _authRepository.Login(usuario);

            if (usuarioBd == null)
                return null;

            var userIdentity = new IdentityUser { UserName = usuarioBd.Nome, Email = usuario.Email, PasswordHash = usuario.Senha };
            //await _signInManager.SignInAsync(userIdentity, isPersistent: false);

            return new UsuarioLoginResult(usuarioBd, userIdentity);
        }
    }
}
