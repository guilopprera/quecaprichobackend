using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace QueCapricho.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly MeuContexto _context;

        public UsuarioRepository(MeuContexto context)
        {
            _context = context;
        }
        public void RedefinirSenha(Usuario usuario)
        {
            var usuarioDb = _context.Usuarios.FirstOrDefault(u => u.Email == usuario.Email);
            usuarioDb.Senha = usuario.Senha;

            _context.Entry(usuarioDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void EnviarEmailTrocaSenha(string email)
        {
            string emailDestinatario = email;

            // ASSUNTO
            string emailAssunto = "Instruções para redefinir de senha - QueCapricho";

            // MENSAGEM
            string emailMensagem = "<h1>Olá, Renata</h1>" +
                "<br>Clique no link a seguir para redefinir a senha da sua conta do aplicativo QueCapricho: <a href='http://localhost:4200/redefinirsenha'>Clique aqui!</a>";

            MailMessage mail = new MailMessage();

            mail.IsBodyHtml = true;
            mail.From = new MailAddress("guilopprera@gmail.com"); // DE
            mail.To.Add(emailDestinatario); // PARA
            mail.Subject = emailAssunto; // ASSUNTO
            mail.Body = emailMensagem; // MENSAGEM

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = new NetworkCredential("guilopprera@gmail.com", "salsichubi");
                smtp.Send(mail);
            }
        }
    }
}
