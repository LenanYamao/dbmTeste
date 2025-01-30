using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TestDbm.Context;
using TestDbm.Models;
using TestDbm.Repositories;
using TestDbm.Services;

namespace TestDbmUnitTest.Produtos
{
    public class ProdutoServiceTestes
    {
        private readonly DbContextOptions<DbmDbContext> _options;
        private readonly DbmDbContext _context;
        private readonly ProdutoService _produtoService;

        public ProdutoServiceTestes()
        {
            // Set up an in-memory database
            _options = new DbContextOptionsBuilder<DbmDbContext>()
                .UseInMemoryDatabase(databaseName: "TesteDatabase")
                .Options;

            _context = new DbmDbContext(_options);
            _produtoService = new ProdutoService(new ProdutoRepository(_context));
        }

        [Fact]
        public void AddProduto_ShouldAddProdutoToDb()
        {
            var produto = new Produto { Nome = "Teste Produto", Descricao = "Teste Desc", Preco = 10.99m };

            _produtoService.AddProduto(produto);

            var prod = _context.Produtos.FirstOrDefault(p => p.Nome == "Teste Produto");
            prod.Should().NotBeNull();
            prod.Nome.Should().Be("Teste Produto");
            prod.Descricao.Should().Be("Teste Desc");
            prod.Preco.Should().Be(10.99m);
            prod.DataCadastro.Should().NotBeAfter(DateTime.Now);
        }
        [Fact]
        public void UpdateProduct_ShouldUpdateProductInDatabase()
        {
            var produto = new Produto { Nome = "Produto", Descricao = "Desc", Preco = 5.99m };
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            var prodEdit = new Produto
            {
                Id = 1,
                Nome = "Produto Edit",
                Descricao = "Desc Edit",
                Preco = 10.99m
            };

            _produtoService.UpdateProduto(prodEdit);

            var updatedProduct = _context.Produtos.Find(1);
            updatedProduct.Should().NotBeNull();
            updatedProduct.Nome.Should().Be("Produto Edit");
            updatedProduct.Descricao.Should().Be("Desc Edit");
            updatedProduct.Preco.Should().Be(10.99m);
        }

        [Fact]
        public async Task DeleteProduct_ShouldRemoveProductFromDatabase()
        {
            var produto = new Produto { Nome = "Produto", Descricao = "Desc", Preco = 5.99m };
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            _produtoService.DeleteProduto(1);

            // Assert
            var prod = _context.Produtos.Find(1);
            prod.Should().BeNull();
        }
    }
}
