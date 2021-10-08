using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Domain.Interfaces.Repositories
{
    public interface ILogRepository
    {
        void AdicionarAsync(Log log);
        List<Log> ObterTodos();
    }
}
