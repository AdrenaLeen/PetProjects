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
    public abstract class BaseRepo<T> where T:class,new()
    {
        public AutoLotEntities Context { get; } = new AutoLotEntities();
        protected DbSet<T> Table;

        public T GetOne(int? id) => Table.Find(id);

        public async Task<T> GetOneAsync(int? id) => await Table.FindAsync(id);

        public List<T> GetAll() => Table.ToList();

        public Task<List<T>> GetAllAsync() => Table.ToListAsync();

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
    }
}
