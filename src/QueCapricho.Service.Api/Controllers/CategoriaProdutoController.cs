using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [DisableCors]
    [ApiController]
    [Route("api/categoriaproduto")]
    public class CategoriaProdutoController : Controller
    {
        private readonly ICategoriaProdutoAppService _categoriaProdutoAppService;
        public CategoriaProdutoController(ICategoriaProdutoAppService categoriaProdutoAppService)
        {
            _categoriaProdutoAppService = categoriaProdutoAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] CategoriaProduto categoriaProduto)
        {
            _categoriaProdutoAppService.Adicionar(categoriaProduto);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] CategoriaProduto categoriaProduto)
        {
            _categoriaProdutoAppService.Adicionar(categoriaProduto);
        }

        [HttpPost]
        [Route("Remover")]
        public void Alterar([FromBody] int categoriaProdutoid)
        {
            _categoriaProdutoAppService.Remover(categoriaProdutoid);
        }

        [HttpGet]
        [Route("Obter/{categoriaProdutoId}")]
        public ActionResult<CategoriaProduto> Obter(int categoriaProdutoId)
        {
            return _categoriaProdutoAppService.Obter(categoriaProdutoId);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<CategoriaProduto>> ObterTodos()
        {
            return _categoriaProdutoAppService.ObterTodos();
        }
    }
}
