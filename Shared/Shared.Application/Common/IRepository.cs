
namespace Shared.Application.Common
{
    public interface IRepository<T> : IDisposable
        where T : class
    {
        Task<IEnumerable<T>> GetListAsync();
        Task<T> GetAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task SaveAsync();
    }
}
