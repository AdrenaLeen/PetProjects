using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.EF;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
            catch (DbUpdateConcurrencyException ex)
            {
                // Генерируется, когда возникла ошибка параллелизма; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Генерируется, когда обновление базы данных терпит отказ. Проверить внутреннее исключение (исключения), чтобы получить дополнительные сведения и затронутые объекты; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Обработать здесь ошибки, связанные с транзакцией; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (Exception ex)
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
            catch (DbUpdateConcurrencyException ex)
            {
                // Генерируется, когда возникла ошибка параллелизма; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (DbUpdateException ex)
            {
                // Генерируется, когда обновление базы данных терпит отказ. Проверить внутреннее исключение (исключения), чтобы получить дополнительные сведения и затронутые объекты; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (CommitFailedException ex)
            {
                // Обработать здесь ошибки, связанные с транзакцией; пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (Exception ex)
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

            if (disposing)
            {
                Context.Dispose();
                
                // Освободить здесь любые управляемые объекты.
            }

            // Освободить здесь любые управляемые объекты.
            disposed = true;
        }
    }
}
