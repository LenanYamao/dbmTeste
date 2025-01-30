using FluentValidation;
using TestDbm.Interfaces;
using TestDbm.Models;
using TestDbm.Repositories;

namespace TestDbm.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoValidator(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;

            RuleFor(produto => produto.Nome).NotNull().MaximumLength(100).MustAsync(NomeUnico).WithMessage("Nome deve ser único.");
            RuleFor(produto => produto.Preco).NotNull().GreaterThan(0);
        }

        private async Task<bool> NomeUnico(string nome, CancellationToken cancellationToken)
        {
            return await _produtoRepository.NomeUnico(nome);
        }
    }
}
