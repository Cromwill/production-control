using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Areas.Location.Models.Repos
{
    public abstract class BaseRepo<T> : IDisposable where T: class, new() 
    {
        public ProductContolEntities Context { get; } = new ProductContolEntities();
        protected DbSet<T> Table;

        public T GetOne(int id) => Table.Find(id);
        public Task<T> GetOneAsync(int id) => Table.FindAsync(id);
        public List<T> GetAll() => Table.ToList();
        public Task<List<T>> GetAllAsync() => Table.ToListAsync();



        public int Add(T enity)
        {
            Table.Add(enity);
            return SaveChanges();
        }

        public Task<int> AddAsync(T enity)
        {
            Table.Add(enity);
            return SaveChangesAsync();
        }

        public int AddRange(IList<T> enities)
        {
            Table.AddRange(enities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IList<T> enities)
        {
            Table.AddRange(enities);
            return SaveChangesAsync();
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChangesAsync();
        }

         internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                throw new Exception("Ошибка параллелизма", ex.InnerException);
            }
            catch(DbUpdateException ex)
            {
                throw new Exception("Обновление базы данных терпит отказ", ex.InnerException);
            }
            catch(CommitFailedException ex)
            {
                throw new Exception("Ошибка с транзакцией", ex.InnerException);
            }
            catch(Exception ex)
            {
                throw new Exception("Хуйня какая-то", ex.InnerException);
            }
        }

         internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Ошибка параллелизма", ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Обновление базы данных терпит отказ", ex.InnerException);
            }
            catch (CommitFailedException ex)
            {
                throw new Exception("Ошибка с транзакцией", ex.InnerException);
            }
            catch (Exception ex)
            {
                throw new Exception("Хуйня какая-то", ex.InnerException);
            }
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if(disposing) Context.Dispose();

            disposed = true;
        }

        public List<T> ExecuteQuery(string sql) 
            => Table.SqlQuery(sql).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql)
            => Table.SqlQuery(sql).ToListAsync();
        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql, sqlParametersObjects).ToList();
        public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects)
            => Table.SqlQuery(sql).ToListAsync();
    }
}