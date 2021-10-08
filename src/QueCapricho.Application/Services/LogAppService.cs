using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace QueCapricho.Application.Services
{
    public class LogAppService : ILogAppService
    {
        private readonly ILogRepository _logRepository;

        public LogAppService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }

        public void AdicionarAsync(Log log)
        {
            if (log == null)
                return;

            _logRepository.AdicionarAsync(log);
        }

        public List<Log> ObterTodos()
        {
            return _logRepository.ObterTodos();
        }
    }
}
