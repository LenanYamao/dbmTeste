using TestDbm.Interfaces;
using TestDbm.Models;
using TestDbm.Repositories;

namespace TestDbm.Services
{
    public class ProdutoService
    {
        private readonly IRepository<Produto> _prodRepository;

        public ProdutoService(IRepository<Produto> prodRepository)
        {
            _prodRepository = prodRepository;
        }

        public IEnumerable<Produto> GetAll()
        {
            return _prodRepository.GetAll();
        }

        public Produto Get(int id)
        {
            return _prodRepository.Get(id);
        }

        public void AddProduto(Produto prod)
        {
            _prodRepository.Add(prod);
            _prodRepository.Save();
        }

        public bool UpdateProduto(Produto prod)
        {
            var _prod = _prodRepository.Get(prod.Id);
            if (_prod == null) return false;

            _prod.Nome = prod.Nome;
            _prod.Descricao = prod.Descricao;
            _prod.Preco = prod.Preco;

            _prodRepository.Update(_prod);
            _prodRepository.Save();
            return true;
        }

        public bool DeleteProduto(int id)
        {
            var _prod = _prodRepository.Get(id);
            if (_prod == null) return false;

            _prodRepository.Delete(id);
            _prodRepository.Save();
            return true;
        }
    }
}
