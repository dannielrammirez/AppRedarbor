using AppRedarbor.ViewModels;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRedarbor.Views
{
    public partial class EmployeeDetailPage : ContentPage
    {
        EmployeeDetailViewModel _viewModel;
        public EmployeeDetailPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new EmployeeDetailViewModel();
        }

        private async void DeleteEmployee(object sender, System.EventArgs e)
        {
            _viewModel.ConfirmDeleted = await DisplayActionSheet("Eliminar Empleado", "Cancelar", null, "Temporal", "Permanente");
            _viewModel.OnDeleteEmployee();
        }
    }
}