using QueCapricho.Domain.Entities;
using QueCapricho.Domain.Interfaces.Repositories;
using QueCapricho.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace QueCapricho.Infra.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly MeuContexto _context;

        public LogRepository(MeuContexto context)
        {
            _context = context;

        }
        public void AdicionarAsync(Log log)
        {
            _context.Logs.Add(log);
            _context.SaveChangesAsync();
        }

        public List<Log> ObterTodos()
        {
            return _context.Logs.ToList();
        }
    }
}