using Microsoft.EntityFrameworkCore;
using System;
using TestDbm.Context;
using TestDbm.Interfaces;
using TestDbm.Models;

namespace TestDbm.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        private readonly DbmDbContext _context;

        public ProdutoRepository(DbmDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> NomeUnico(string nome)
        {
            return !await _context.Produtos.AnyAsync(p => p.Nome == nome);
        }
    }
}
