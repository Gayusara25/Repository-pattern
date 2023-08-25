namespace Repository_pattern.Repository
{
    public interface Irepo<T> where T : class
    {
        public Task<bool> Insertrecords(T entity);
        Task<List<T>> GetAllRecords();
        public Task<bool> DeleteRecords(T entity);
        T GetUserById(long Id);
    }
}
