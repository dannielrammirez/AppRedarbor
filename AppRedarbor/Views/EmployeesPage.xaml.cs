using AppRedarbor.ViewModels;
using Xamarin.Forms;

namespace AppRedarbor.Views
{
    public partial class EmployeesPage : ContentPage
    {
        EmployeesViewModel _viewModel;

        public EmployeesPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EmployeesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}