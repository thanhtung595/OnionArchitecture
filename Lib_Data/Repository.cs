using Lib_Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lib_Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        DbContext_MSSQL _dbContext_MSSQL;
        public Repository(DbContext_MSSQL dbContext_MSSQL)
        {

            _dbContext_MSSQL = dbContext_MSSQL;

        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await _dbContext_MSSQL.Set<T>().ToListAsync();
            }
            return await _dbContext_MSSQL.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await _dbContext_MSSQL.Set<T>().FindAsync(id)!;
        }

        // Repository
        public async Task<IEnumerable<T>> GetAllIncluding(Expression<Func<T, bool>> expression = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _dbContext_MSSQL.Set<T>();

            if (expression != null)
            {
                query = query.Where(expression);
            }

            // Bổ sung các bảng liên quan vào truy vấn
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task Insert(T entity)
        {
            await _dbContext_MSSQL.Set<T>().AddAsync(entity);
        }

        public async Task Insert (IEnumerable<T> entities)
        {
           await _dbContext_MSSQL.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entityEntry = _dbContext_MSSQL.Entry<T>(entity);
            entityEntry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        public void Delete(T entity)
        {
            EntityEntry entityEntry = _dbContext_MSSQL.Entry<T>(entity);
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entities = _dbContext_MSSQL.Set<T>().Where(expression).ToList();
            if (entities.Count > 0)
            {
                _dbContext_MSSQL.Set<T>().RemoveRange(entities);
            }
        }

        public virtual IQueryable<T> Table => _dbContext_MSSQL.Set<T>();

        public async Task Commit()
        {
            await _dbContext_MSSQL.SaveChangesAsync();
        }
    }
}
