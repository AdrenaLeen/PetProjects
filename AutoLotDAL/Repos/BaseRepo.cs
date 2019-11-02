using AutoLotDAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace AutoLotDAL.Repos
{
    public abstract class BaseRepo<T>: IDisposable where T:class,new()
    {
        public AutoLotEntities Context { get; } = new AutoLotEntities();
        protected DbSet<T> Table;

        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Генерируется, когда возникла ошибка параллелизма; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (DbUpdateException)
            {
                // Генерируется, когда обновление базы данных терпит отказ. Проверить внутреннее исключение (исключения), чтобы получить дополнительные сведения и затронутые объекты; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (CommitFailedException)
            {
                // Обработать здесь ошибки, связанные с транзакцией; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (Exception)
            {
                // Были сгенерированы какие-то другие исключения, которые должны быть обработаны.
                throw;
            }
        }

        internal async Task<int> SaveChangesAsync()
        {
            try
            {
                return await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Генерируется, когда возникла ошибка параллелизма; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (DbUpdateException)
            {
                // Генерируется, когда обновление базы данных терпит отказ. Проверить внутреннее исключение (исключения), чтобы получить дополнительные сведения и затронутые объекты; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (CommitFailedException)
            {
                // Обработать здесь ошибки, связанные с транзакцией; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (Exception)
            {
                // Были сгенерированы какие-то другие исключения, которые должны быть обработаны.
                throw;
            }
        }

        public T GetOne(int? id) => Table.Find(id);

        public async Task<T> GetOneAsync(int? id) => await Table.FindAsync(id);

        public List<T> GetAll() => Table.ToList();

        public Task<List<T>> GetAllAsync() => Table.ToListAsync();

        public List<T> ExecuteQuery(string sql) => Table.SqlQuery(sql).ToList();

        public Task<List<T>> ExecuteQueryAsync(string sql) => Table.SqlQuery(sql).ToListAsync();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => Table.SqlQuery(sql, sqlParametersObjects).ToList();

        public Task<List<T>> ExecuteQueryAsync(string sql, object[] sqlParametersObjects) => Table.SqlQuery(sql).ToListAsync();

        public int Add(T entity)
        {
            Table.Add(entity);
            return SaveChanges();
        }

        public async Task<int> AddAsync(T entity)
        {
            Table.Add(entity);
            return await SaveChangesAsync();
        }

        public int AddRange(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChanges();
        }

        public Task<int> AddRangeAsync(IList<T> entities)
        {
            Table.AddRange(entities);
            return SaveChangesAsync();
        }

        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            // Освободить здесь любые управляемые объекты.
            if (disposing) Context.Dispose();

            // Освободить здесь любые управляемые объекты.
            disposed = true;
        }

        public int Save(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public async Task<int> SaveAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public async Task<int> DeleteAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return await SaveChangesAsync();
        }
    }
}
