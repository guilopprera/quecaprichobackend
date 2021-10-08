using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;
using QueCapricho.Domain.Interfaces.Repositories;

namespace QueCapricho.Application.Services
{
    public class TelefoneAppService : ITelefoneAppService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneAppService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public void Adicionar(Telefone telefone)
        {
            if (telefone == null)
                return;

            _telefoneRepository.Adicionar(telefone);
        }

        public void Alterar(Telefone telefone)
        {
            if (telefone == null || telefone.TelefoneId == 0)
                return;

            _telefoneRepository.Alterar(telefone);
        }

        public List<Telefone> ObterTodos()
        {
            return _telefoneRepository.ObterTodos();
        }
    }
}
