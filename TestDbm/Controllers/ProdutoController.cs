using FirebirdSql.Data.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TestDbm.Models;
using TestDbm.Services;
using TestDbm.Validators;

namespace TestDbm.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;
        private readonly IValidator<Produto> _validator;

        public ProdutoController(ProdutoService produtoService, IValidator<Produto> validator)
        {
            _produtoService = produtoService;
            _validator = validator;
        }
        [HttpGet]
        public ActionResult<Produto> Get(int id)
        {
            var produto = _produtoService.Get(id);
            if (produto == null)
            {
                return NoContent();
            }
            return Ok(produto);
        }
        [HttpGet]
        public ActionResult<IEnumerable<Produto>> GetAll()
        {
            var produtos = _produtoService.GetAll();
            if (produtos == null)
            {
                return NoContent();
            }
            return Ok(produtos);
        }
        [HttpPost]
        public async Task<ActionResult<Produto>> PostAsync(Produto prod)
        {
            var validationResult = await _validator.ValidateAsync(prod);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.ToDictionary());
            }
            _produtoService.AddProduto(prod);
            return Created();
        }
        [HttpPut]
        public ActionResult<Produto> Put(Produto prod)
        {
            var updated = _produtoService.UpdateProduto(prod);
            if (!updated) return NotFound();
            return Ok();
        }
        [HttpDelete]
        public ActionResult<Produto> Delete(int id)
        {
            var deleted = _produtoService.DeleteProduto(id);
            if (!deleted) return NotFound();
            return Ok();
        }
    }
}
