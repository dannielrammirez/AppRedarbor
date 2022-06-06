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
    }
}