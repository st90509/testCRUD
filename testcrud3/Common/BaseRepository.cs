using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Data.SqlClient;

namespace testcrud3.Common
{
    /// <summary>
    /// It's a BaseRepository for generic type
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbContext _dbContext;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<T> Queryable()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public virtual int Delete(T obj)
        {
            return DeleteAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> DeleteAsync(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            _dbContext.Set<T>().Remove(obj);

            return 1;
        }

        public virtual int Delete(IEnumerable<T> list)
        {
            return DeleteAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> DeleteAsync(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            _dbContext.Set<T>().RemoveRange(list);

            return 1;
        }

        public virtual T Get(Expression<Func<T, bool>> predicate)
        {
            return GetAsync(predicate).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return GetAllAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> predicate)
        {
            return GetManyAsync(predicate).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.Where(predicate).AsNoTracking().ToListAsync();
        }

        public virtual int Insert(T obj)
        {
            return InsertAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> InsertAsync(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            _dbContext.Set<T>().Add(obj);

            return 1;
        }

        public virtual int Insert(IEnumerable<T> list)
        {
            return InsertAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> InsertAsync(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            _dbContext.Set<T>().AddRange(list);

            return 1;
        }

        public virtual int Update(T obj)
        {
            return UpdateAsync(obj).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> UpdateAsync(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            _dbContext.Set<T>().Update(obj);

            return 1;
        }

        public virtual int Update(IEnumerable<T> list)
        {
            return UpdateAsync(list).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> UpdateAsync(IEnumerable<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }

            _dbContext.Set<T>().UpdateRange(list);

            return 1;
        }

        public virtual IEnumerable<T> ExecuteSqlQuery(string sql, object parameters)
        {
            return ExecuteSqlQueryAsync(sql, parameters).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<IEnumerable<T>> ExecuteSqlQueryAsync(string sql, object parameters)
        {
            using (IDbConnection conn = _dbContext.Database.GetDbConnection())
            {
                conn.Open();
                
                return await conn.QueryAsync<T>(sql, parameters);
            }
        }

        public virtual IEnumerable<TEntity> ExecuteSqlQuery<TEntity>(string sql, object parameters)
        {
            return ExecuteSqlQueryAsync<TEntity>(sql, parameters).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<IEnumerable<TEntity>> ExecuteSqlQueryAsync<TEntity>(string sql, object parameters)
        {
            using (IDbConnection conn = _dbContext.Database.GetDbConnection())
            {
                conn.Open();

                return await conn.QueryAsync<TEntity>(sql, parameters);
            }
        }

        public virtual int ExecuteSql(string sql, object parameters)
        {
            return ExecuteSqlAsync(sql, parameters).ConfigureAwait(false).GetAwaiter().GetResult();
        }

        public virtual async Task<int> ExecuteSqlAsync(string sql, object parameters)
        {

            using (IDbConnection conn = _dbContext.Database.GetDbConnection())
            {
                conn.Open();

                return await conn.ExecuteAsync(sql, parameters);
            }
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(_dbContext.Database.GetConnectionString());
        }

    }
}