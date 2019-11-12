using AutoLotDALCore.EF;
using AutoLotDALCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AutoLotDALCore.Repos
{
    public class BaseRepo<T> : IDisposable, IRepo<T> where T:EntityBase, new()
    {
        private readonly DbSet<T> table;
        protected AutoLotContext Context { get; }

        public BaseRepo() : this(new AutoLotContext()) { }

        public BaseRepo(AutoLotContext context)
        {
            Context = context;
            table = Context.Set<T>();
        }

        public void Dispose() => Context?.Dispose();

        public int Add(T entity)
        {
            table.Add(entity);
            return SaveChanges();
        }

        public int Add(IList<T> entities)
        {
            table.AddRange(entities);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            table.Update(entity);
            return SaveChanges();
        }

        public int Update(IList<T> entities)
        {
            table.UpdateRange(entities);
            return SaveChanges();
        }

        public int Delete(int id, byte[] timeStamp)
        {
            Context.Entry(new T() { Id = id, Timestamp = timeStamp }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(int? id) => table.Find(id);

        public virtual List<T> GetAll() => table.ToList();

        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending) => (ascending ? table.OrderBy(orderBy) : table.OrderByDescending(orderBy)).ToList();

        public List<T> GetSome(Expression<Func<T, bool>> where) => table.Where(where).ToList();

        public List<T> ExecuteQuery(string sql) => table.FromSql(sql).ToList();

        public List<T> ExecuteQuery(string sql, object[] sqlParametersObjects) => table.FromSql(sql, sqlParametersObjects).ToList();

        internal int SaveChanges()
        {
            try
            {
                return Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Генерируется, когда возникла ошибка, связанная с параллелизмом. Пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (RetryLimitExceededException)
            {
                // Генерируется, когда достигнуто максимальное количество попыток. Дополнительные детали можно найти во внутреннем исключении (исключениях). Пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (DbUpdateException)
            {
                // Генерируется, когда обновление базы данных потерпело неудачу. Дополнительные детали и затронутые объекты можно найти во внутреннем исключении (исключениях). Пока что просто сгенерировать исключение повторно.
                throw;
            }
            catch (Exception)
            {
                // Возникло какое-то другое исключение, которое должно быть обработано.
                throw;
            }
        }
    }
}
