using AppRedarbor.Models;
using AppRedarbor.Utilities;
using AppRedarbor.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppRedarbor.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {
        private Employee _selectedEmployee;
        public ObservableCollection<Employee> Employees { get; }
        public Command LoadEmployeesCommand { get; }
        public Command AddEmployeeCommand { get; }
        public Command<Employee> EmployeeTapped { get; }

        public EmployeesViewModel()
        {
            Title = "Employees";
            Employees = new ObservableCollection<Employee>();
            LoadEmployeesCommand = new Command(async () => await ExecuteLoadEmployeesCommand());
            EmployeeTapped = new Command<Employee>(OnEmployeeSelected);
            AddEmployeeCommand = new Command(OnAddEmployee);
        }

        async Task ExecuteLoadEmployeesCommand()
        {
            IsBusy = true;

            try
            {
                Employees.Clear();
                var employees = await _employeeRepo.GetAllAsync(CT.UrlEmployeeApi);
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedEmployee = null;
        }

        public Employee SelectedEmployee
        {
            get => _selectedEmployee;
            set
            {
                SetProperty(ref _selectedEmployee, value);
                OnEmployeeSelected(value);
            }
        }

        private async void OnAddEmployee(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewEmployeePage));
        }

        async void OnEmployeeSelected(Employee Employee)
        {
            if (Employee == null)
                return;

            // This will push the EmployeeDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(EmployeeDetailPage)}?{nameof(EmployeeDetailViewModel.Id)}={Employee.Id}");
        }
    }
}