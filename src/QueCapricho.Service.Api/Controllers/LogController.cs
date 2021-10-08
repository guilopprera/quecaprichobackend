using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("api/log")]
    public class LogController : Controller
    {
        private readonly ILogAppService _logAppService;
        public LogController(ILogAppService logAppService)
        {
            _logAppService = logAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void AdicionarAsync([FromBody] Log log)
        {
            _logAppService.AdicionarAsync(log);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Log>> ObterTodos()
        {
            return _logAppService.ObterTodos();
        }
    }
}
