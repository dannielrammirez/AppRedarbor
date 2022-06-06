using AppRedarbor.Models;
using AppRedarbor.Services.IRepository;

namespace AppRedarbor.Services
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

    }
}
