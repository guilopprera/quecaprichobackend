using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly MeuContexto _context;

        public ClienteRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Alterar(Cliente cliente)
        {
            var clienteDb = _context.Clientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId);

            clienteDb.Nome = cliente.Nome;
            clienteDb.Email = cliente.Email;
            clienteDb.CPF = cliente.CPF;
            clienteDb.Enderecos = cliente.Enderecos;
            clienteDb.Telefones = cliente.Telefones;

            _context.Entry(clienteDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Remover(int clienteId)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);

            cliente.Apagado = true;

            _context.Entry(cliente).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Cliente Obter(int clienteId)
        {
            return _context.Clientes.FirstOrDefault(c => c.ClienteId == clienteId);
        }

        public List<Cliente> ObterTodos()
        {
            return _context.Clientes.Where(c => !c.Apagado)
                 .ToList();
        }

        public List<Cliente> Pesquisar(string textoPesquisa)
        {
            return _context.Clientes
                .Where(c => (string.IsNullOrEmpty(textoPesquisa) ? c.ClienteId > 0 : c.Nome.Contains(textoPesquisa.Trim())) && !c.Apagado)
                .Select(
                cli => new Cliente
                {
                    ClienteId = cli.ClienteId,
                    Nome = cli.Nome
                }).ToList();
        }
    }
}
