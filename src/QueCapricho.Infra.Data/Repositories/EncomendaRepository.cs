using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class EncomendaRepository : IEncomendaRepository
    {
        private readonly MeuContexto _context;

        public EncomendaRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(Encomenda encomenda)
        {
            _context.Encomendas.Add(encomenda);
            _context.SaveChanges();
        }

        public void Alterar(Encomenda encomenda)
        {
            var encomendaDb = _context.Encomendas.FirstOrDefault(e => e.EncomendaId == encomenda.EncomendaId);

            encomendaDb.DataEntrega = encomenda.DataEntrega;
            encomendaDb.ClienteId = encomenda.ClienteId;
            encomendaDb.ClienteId = encomenda.ClienteId;
            encomendaDb.Valor = encomenda.Valor;

            _context.Entry(encomendaDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Finalizar(int encomendaId)
        {
            var encomendaDb = _context.Encomendas.FirstOrDefault(e => e.EncomendaId == encomendaId);

            encomendaDb.Ativo = false;

            _context.Entry(encomendaDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int encomendaId)
        {
            var encomenda = _context.Encomendas.FirstOrDefault(e => e.EncomendaId == encomendaId);

            encomenda.Apagado = true;

            _context.Entry(encomenda).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Encomenda Obter(int encomendaId)
        {
            return _context.Encomendas.FirstOrDefault(e => e.EncomendaId == encomendaId);
        }

        public List<Encomenda> ObterTodos()
        {
            return _context.Encomendas
                .Include(e => e.Cliente)
                .Include(e => e.ListaEncomendaProduto)
                .Where(e => !e.Apagado)
                .ToList();
        }
    }
}
