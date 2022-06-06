using AppRedarbor.Services;
using Xamarin.Forms;

namespace AppRedarbor
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<EmployeeRepository>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
