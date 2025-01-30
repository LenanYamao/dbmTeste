using Microsoft.EntityFrameworkCore;
using System;
using TestDbm.Context;
using TestDbm.Interfaces;

namespace TestDbm.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbmDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbmDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
