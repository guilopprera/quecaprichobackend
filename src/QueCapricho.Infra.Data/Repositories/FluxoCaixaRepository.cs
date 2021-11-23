using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
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
        public void Adicionar(FluxoCaixa fluxoCaixa)
        {
            _context.FluxoCaixa.Add(fluxoCaixa);
            _context.SaveChanges();
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
            return _context.FluxoCaixa.Where(fc=> fc.Data.Date == DateTime.Today.Date)
                .ToList();
        }

        public List<FluxoCaixa> Pesquisar(DateTime dataInicial, DateTime dataFinal, string descricao)
        {
            return _context.FluxoCaixa
                .Where(fc =>
                (string.IsNullOrEmpty(descricao) ? fc.FluxoCaixaId > 0 : fc.Descricao.Contains(descricao.Trim()))
                && dataInicial == DateTime.MinValue ? fc.FluxoCaixaId > 0 : fc.Data.Date > dataInicial.Date
                && dataFinal == DateTime.MinValue ? fc.FluxoCaixaId > 0 : fc.Data.Date < dataFinal.Date
                && !fc.Apagado)
                .ToList();
        }
    }
}