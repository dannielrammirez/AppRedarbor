using AppRedarbor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppRedarbor.Services.IRepository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(string url);
        Task<Employee> GetAsync(string url, int id);
        Task<bool> SaveAsync(string url, Employee itemSave);
        Task<bool> UpdateAsync(string url, Employee itemSave);
        Task<bool> DeleteAsync(string url, int id);
    }
}