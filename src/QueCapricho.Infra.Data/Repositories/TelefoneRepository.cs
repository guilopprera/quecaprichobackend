using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly MeuContexto _context;

        public TelefoneRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            _context.SaveChanges();
        }

        public void Alterar(Telefone telefone)
        {
            var telefoneDb = _context.Telefones.FirstOrDefault(t => t.TelefoneId == telefone.TelefoneId);

            telefoneDb.Numero = telefoneDb.Numero;

            _context.Entry(telefoneDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Telefone> ObterTodos()
        {
            return _context.Telefones
                .ToList();
        }
    }
}