using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Moq;
using TestDbm.Context;
using TestDbm.Interfaces;
using TestDbm.Models;
using TestDbm.Repositories;
using TestDbm.Services;
using TestDbm.Validators;

namespace TestDbmUnitTest.Produtos
{
    public class ProdutoValidationTestes
    {
        private readonly ProdutoValidator _validator;

        public ProdutoValidationTestes()
        {
            var repositoryMock = new Mock<IProdutoRepository>();
            repositoryMock.Setup(x => x.NomeUnico(It.IsAny<string>()))
                .ReturnsAsync(true);

            _validator = new ProdutoValidator(repositoryMock.Object);
        }

        [Fact]
        public void Name_ShouldNotBeEmpty()
        {
            var produto = new Produto { Nome = "", Descricao = "Teste Desc", Preco = 10.99m };

            var result = _validator.TestValidate(produto);

            result.ShouldHaveValidationErrorFor(x => x.Nome)
                .WithErrorMessage("Nome obrigatório.");
        }

        [Fact]
        public void Price_ShouldBeGreaterThanZero()
        {
            var produto = new Produto { Nome = "Teste Produto", Descricao = "Teste Desc", Preco = 0 };

            // Act
            var result = _validator.TestValidate(produto);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Preco)
                .WithErrorMessage("Preço deve ser maior que 0.");
        }

    }
}
