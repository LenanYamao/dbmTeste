using TestDbm.Models;

namespace TestDbm.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<bool> NomeUnico(string nome);
    }
}
