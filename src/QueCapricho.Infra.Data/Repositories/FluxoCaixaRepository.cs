using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Domain.ValueObjects;
using QueCapricho.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class FluxoCaixaRepository : IFluxoCaixaRepository
    {
        private readonly MeuContexto _context;

        public FluxoCaixaRepository(MeuContexto context)
        {
            _context = context;

        }
        public FluxoCaixa Adicionar(FluxoCaixa fluxoCaixa)
        {
            _context.FluxoCaixa.Add(fluxoCaixa);
            _context.SaveChanges();
            return fluxoCaixa;
        }

        public void Alterar(FluxoCaixa fluxoCaixa)
        {
            var fluxoCaixaDb = _context.FluxoCaixa.FirstOrDefault(fc => fc.FluxoCaixaId == fluxoCaixa.FluxoCaixaId);

            fluxoCaixaDb.Tipo = fluxoCaixa.Tipo;
            fluxoCaixaDb.Descricao = fluxoCaixa.Descricao;
            fluxoCaixaDb.Valor = fluxoCaixa.Valor;
            fluxoCaixaDb.Data = fluxoCaixa.Data;

            _context.Entry(fluxoCaixaDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int fluxoCaixaId)
        {
            var fluxoCaixa = _context.FluxoCaixa.FirstOrDefault(fc => fc.FluxoCaixaId == fluxoCaixaId);

            fluxoCaixa.Apagado = true;

            _context.Entry(fluxoCaixa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public FluxoCaixa Obter(int fluxoCaixaId)
        {
            return _context.FluxoCaixa
                .FirstOrDefault(fc => fc.FluxoCaixaId == fluxoCaixaId);
        }

        public List<FluxoCaixa> ObterTodos()
        {
            return _context.FluxoCaixa.Where(fc => fc.Data.Date == DateTime.Today.Date)
                .ToList();
        }

        public List<FluxoCaixa> Pesquisar(FluxoCaixaRequest fluxoCaixa)
        {
            return _context.FluxoCaixa
                .Where(fc =>
                (fluxoCaixa.DataInicial == DateTime.MinValue ? fc.FluxoCaixaId > 0 : fc.Data.Date >= fluxoCaixa.DataInicial.Date)
                && (fluxoCaixa.DataFinal == DateTime.MinValue ? fc.FluxoCaixaId > 0 : fc.Data.Date <= fluxoCaixa.DataFinal.Date
                && !fc.Apagado))
                .ToList();
        }
    }
}