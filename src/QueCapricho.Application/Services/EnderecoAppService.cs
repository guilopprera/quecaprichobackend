using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;

namespace QueCapricho.Application.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoAppService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Adicionar(Endereco endereco)
        {
            if (endereco == null)
                return;

            _enderecoRepository.Adicionar(endereco);
        }

        public void Alterar(Endereco endereco)
        {
            if (endereco == null || endereco.EnderecoId == 0)
                return;

            _enderecoRepository.Alterar(endereco);
        }

        public List<Endereco> ObterTodos()
        {
            return _enderecoRepository.ObterTodos();
        }
    }
}
