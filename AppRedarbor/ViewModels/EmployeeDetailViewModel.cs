using AppRedarbor.Utilities;
using AppRedarbor.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace AppRedarbor.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class EmployeeDetailViewModel : BaseViewModel
    {
        private int id;
        private int employeeId;
        private int companyId;
        private string email;
        private string fax;
        private string name;
        private string userName;
        private string password;
        private int portalId;
        private int roleId;
        private int statusId;
        private string telephone;
        private DateTime createdOn;
        private DateTime? lastLogin;
        private DateTime? deletedOn;
        private DateTime? updatedOn;
        private bool confirmDeleted;
        public bool ConfirmDeleted
        {
            get { return confirmDeleted; }
            set { confirmDeleted = value; }
        }

        public Command DeleteEmployeeCommand { get; }
        public Command UpdateEmployeeCommand { get; }

        public EmployeeDetailViewModel()
        {
            UpdateEmployeeCommand = new Command(OnUpdateEmployee);
            DeleteEmployeeCommand = new Command(OnDeleteEmployee);
        }

        public async void OnDeleteEmployee()
        {
            try
            {
                var delete = await _employeeRepo.DeleteAsync(CT.UrlEmployeeApi, Id);
                if(delete)
                    await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private async void OnUpdateEmployee()
        {
            await Shell.Current.GoToAsync($"{nameof(UpdateEmployeePage)}?{nameof(UpdateEmployeeViewModel.Id)}={Id}");
        }

        #region Properties
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                SetProperty(ref id, value);
                LoadEmployeeId(value);
            }
        }
        public int EmployeeId
        {
            get => employeeId;
            set => SetProperty(ref employeeId, value);
        }
        public int CompanyId
        {
            get => companyId;
            set => SetProperty(ref companyId, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Fax
        {
            get => fax;
            set => SetProperty(ref fax, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Username
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public int PortalId
        {
            get => portalId;
            set => SetProperty(ref portalId, value);
        }
        public int RoleId
        {
            get => roleId;
            set => SetProperty(ref roleId, value);
        }

        public int StatusId
        {
            get => statusId;
            set => SetProperty(ref statusId, value);
        }

        public string Telephone
        {
            get => telephone;
            set => SetProperty(ref telephone, value);
        }

        public DateTime CreatedOn
        {
            get => createdOn;
            set => SetProperty(ref createdOn, value);
        }

        public DateTime? DeletedOn
        {
            get => deletedOn;
            set => SetProperty(ref deletedOn, value);
        }
        public DateTime? UpdatedOn
        {
            get => updatedOn;
            set => SetProperty(ref updatedOn, value);
        }
        public DateTime? LastLogin
        {
            get => lastLogin;
            set => SetProperty(ref lastLogin, value);
        }
        #endregion
        public async void LoadEmployeeId(int employeeId)
        {
            try
            {
                var employee = await _employeeRepo.GetAsync(CT.UrlEmployeeApi, employeeId);
                EmployeeId = employee.Id;
                CompanyId = employee.CompanyId;
                CreatedOn = employee.CreatedOn;
                DeletedOn = employee.DeletedOn;
                Email = employee.Email;
                Fax = employee.Fax;
                Name = employee.Name;
                Username = employee.Username;
                LastLogin = employee.Lastlogin;
                Password = employee.Password;
                PortalId = employee.PortalId;
                RoleId = employee.RoleId;
                StatusId = employee.StatusId;
                Telephone = employee.Telephone;
                UpdatedOn = employee.UpdatedOn;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Employee");
            }
        }
    }
}
