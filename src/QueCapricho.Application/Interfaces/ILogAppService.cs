using System.Collections.Generic;
using QueCapricho.Domain.Entities;

namespace QueCapricho.Application.Interfaces
{
    public interface ILogAppService
    {
        void AdicionarAsync(Log log);
        List<Log> ObterTodos();
    }
}
