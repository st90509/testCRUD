using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace testcrud3.Common
{
    /// <summary>
    /// It's a BaseRepository interface for generic type
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        public IQueryable<T> Queryable();

        public T Get(Expression<Func<T, bool>> predicate = null);
        public Task<T> GetAsync(Expression<Func<T, bool>> predicate = null);

        public IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        public IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate = null);
        public Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate = null);

        public int Insert(T obj);
        public Task<int> InsertAsync(T obj);

        public int Insert(IEnumerable<T> list);
        public Task<int> InsertAsync(IEnumerable<T> list);

        public int Update(T obj);
        public Task<int> UpdateAsync(T obj);

        public int Update(IEnumerable<T> list);
        public Task<int> UpdateAsync(IEnumerable<T> list);

        public int Delete(T obj);
        public Task<int> DeleteAsync(T obj);

        public int Delete(IEnumerable<T> list);
        public Task<int> DeleteAsync(IEnumerable<T> list);

    }
}
