namespace AppRedarbor.Services.IRepository
{
    public interface ICustomDependencyService
    {
        T Get<T>() where T : class;
    }
}