using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public class Repository<T, TId> : IRepository<T,TId> where T : BaseEntity<TId>,new()
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
           await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TId id)
        {
            _dbContext.Remove(new T()
            {
                Id = id
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            if(filter == null)
            {
                throw new Exception("filter is required");
            }
            return await _entities.FirstOrDefaultAsync(filter); 
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter)
        {
            return filter == null ? _entities.ToList() : _entities.Where(filter).ToList();
        }
        public async Task<T> GetById(TId id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task Update(Action<T> updateExpression, TId id)
        {
            var entity = new T();
            updateExpression(entity);
            entity.Id= id;
            _dbContext.Update(entity);
           await _dbContext.SaveChangesAsync();          
        }
    }
}
