using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppRedarbor.Services.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string url);
        Task<T> GetAsync(string url, int id);
        Task<bool> SaveAsync(string url, T itemSave);
        Task<bool> UpdateAsync(string url, T itemSave);
        Task<bool> DeleteAsync(string url, int id);
    }
}