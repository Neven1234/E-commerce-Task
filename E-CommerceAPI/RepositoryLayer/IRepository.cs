using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public interface IRepository<T, TId> where T : BaseEntity<TId>
    {
        public Task<T> Add(T entity);
        public Task Update(Action<T> updateExpression, TId id);
        public Task DeleteAsync(TId id);
        public Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null);
        public Task<T> GetAsync(Expression<Func<T, bool>> filter );
        public Task<T> GetById(TId id);
    }
}
