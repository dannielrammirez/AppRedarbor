using AppRedarbor.Views;
using Xamarin.Forms;

namespace AppRedarbor
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(EmployeesPage), typeof(EmployeesPage));
            Routing.RegisterRoute(nameof(EmployeeDetailPage), typeof(EmployeeDetailPage));
            Routing.RegisterRoute(nameof(NewEmployeePage), typeof(NewEmployeePage));
            Routing.RegisterRoute(nameof(UpdateEmployeePage), typeof(UpdateEmployeePage));

            BindingContext = this;
        }
    }
}
