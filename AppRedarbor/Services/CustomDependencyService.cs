using AppRedarbor.Services.IRepository;
using Xamarin.Forms;

namespace AppRedarbor.Services
{
    public class CustomDependencyService : ICustomDependencyService
    {
        public T Get<T>() where T : class
        {
            return DependencyService.Get<T>();
        }
    }
}