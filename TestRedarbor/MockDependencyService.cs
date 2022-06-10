using AppRedarbor.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRedarbor
{
    public class MockDependencyService : ICustomDependencyService
    {
        private readonly Dictionary<object, object> registeredServices = new Dictionary<object, object>();
        public void Register<T>(T implementation)
        {
            registeredServices.Add(typeof(T), implementation);
        }

        public T Get<T>() where T : class
        {
            return (T)registeredServices[typeof(T)];
        }
    }
}
