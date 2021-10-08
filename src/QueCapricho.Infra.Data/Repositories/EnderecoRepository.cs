using Microsoft.EntityFrameworkCore;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MeuContexto _context;

        public EnderecoRepository(MeuContexto context)
        {
            _context = context;

        }
        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public void Alterar(Endereco endereco)
        {
            var enderecoDb = _context.Enderecos.FirstOrDefault(e => e.EnderecoId == endereco.EnderecoId);

            endereco.Bairro = endereco.Bairro;
            endereco.Cidade = endereco.Cidade;
            endereco.Logradouro = endereco.Logradouro;
            endereco.Numero = endereco.Numero;

            _context.Entry(enderecoDb).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Endereco> ObterTodos()
        {
            return _context.Enderecos
                .ToList();
        }
    }
}