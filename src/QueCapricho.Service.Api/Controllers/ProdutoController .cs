using Microsoft.AspNetCore.Mvc;
using QueCapricho.Application.Interfaces;
using QueCapricho.Domain.Entities;
using System.Collections.Generic;

namespace QueCapricho.Service.Api.Controllers
{
    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : Controller
    {
        private readonly IProdutoAppService _produtoAppService;
        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [Route("Adicionar")]
        public void Adicionar([FromBody] Produto produto)
        {
            _produtoAppService.Adicionar(produto);
        }

        [HttpPost]
        [Route("Alterar")]
        public void Alterar([FromBody] Produto produto)
        {
            _produtoAppService.Alterar(produto);
        }

        [HttpPost]
        [Route("AlterarEstoque")]
        public void Alterar([FromBody] Estoque estoque)
        {
            _produtoAppService.AlterarEstoque(estoque);
        }

        [HttpPost]
        [Route("Remover")]
        public void Alterar([FromBody] int produtoId)
        {
            _produtoAppService.Remover(produtoId);
        }

        [HttpGet]
        [Route("Obter/{produtoId}")]
        public ActionResult<Produto> Obter(int produtoId)
        {
            return _produtoAppService.Obter(produtoId);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public ActionResult<List<Produto>> ObterTodos()
        {
            return _produtoAppService.ObterTodos();
        }

        [HttpGet]
        [Route("Pesquisar/{texto}")]
        public ActionResult<List<Produto>> Pesquisar(string texto)
        {
            return _produtoAppService.Pesquisar(texto);
        }
    }
}
