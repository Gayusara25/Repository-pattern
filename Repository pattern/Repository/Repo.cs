using Microsoft.EntityFrameworkCore;

namespace Repository_pattern.Repository
{
    public class Repo<T> : Irepo<T> where T : class

    {
        private Databasecontext _dbContext;

        public Repo(Databasecontext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> Insertrecords(T entity)
        {
            try
            {
                _dbContext.Set<T>().AddAsync(entity);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }
        }
        public T GetUserById(long Id)
        {
            return _dbContext.Set<T>().Find(Id);
        }

        public Task<bool> DeleteRecords(T model)
        {
            try
            {
                _dbContext.Set<T>().Remove(model);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {

                return Task.FromResult(false);
            }

        }

        public Task<List<T>> GetAllRecords()
        {
            return _dbContext.Set<T>().ToListAsync();
        }




    }
}
