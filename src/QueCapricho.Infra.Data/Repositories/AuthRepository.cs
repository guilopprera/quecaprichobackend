using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly MeuContexto _context;

        public AuthRepository(MeuContexto context)
        {
            _context = context;

        }
        public Usuario Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return usuario;
        }

        public Usuario Login(Usuario usuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email & u.Senha == usuario.Senha);
        }

        public bool VerificarUsuarioExiste(Usuario usuario)
        {
            return _context.Usuarios.Where(u => u.Email == usuario.Email && u.Senha == usuario.Senha).Any();
        }
    }
}
