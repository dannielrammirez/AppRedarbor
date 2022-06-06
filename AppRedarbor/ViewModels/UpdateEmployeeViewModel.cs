using AppRedarbor.Models;
using AppRedarbor.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRedarbor.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class UpdateEmployeeViewModel : BaseViewModel
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
        public Command UpdateCommand { get; }
        public Command CancelCommand { get; }
        public Command LoadEmployeeCommand { get; }

        public UpdateEmployeeViewModel()
        {
            LoadEmployeeCommand = new Command(async () => await ExecuteLoadEmployeeCommand());
            UpdateCommand = new Command(OnUpdate, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => UpdateCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            bool companyIdIsvalid = !String.IsNullOrWhiteSpace(companyId.ToString());
            bool emailIsvalid = !String.IsNullOrWhiteSpace(email);
            bool faxIsValid = !String.IsNullOrWhiteSpace(fax);
            bool nameIsValid = !String.IsNullOrWhiteSpace(name);
            bool userNameIsValid = !String.IsNullOrWhiteSpace(userName);
            bool passwordIsValid = !String.IsNullOrWhiteSpace(password);
            bool portalIdIsValid = !String.IsNullOrWhiteSpace(portalId.ToString());
            bool roleIdIsValid = !String.IsNullOrWhiteSpace(roleId.ToString());
            bool statusIdIsValid = !String.IsNullOrWhiteSpace(statusId.ToString());
            bool telephoneIsValid = !String.IsNullOrWhiteSpace(telephone);

            return companyIdIsvalid && emailIsvalid && faxIsValid && nameIsValid && userNameIsValid && passwordIsValid && portalIdIsValid && roleIdIsValid && statusIdIsValid && telephoneIsValid;
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

        public int CompanyId
        {
            get => companyId;
            set => SetProperty(ref companyId, value);
        }
        public int EmployeeId
        {
            get => employeeId;
            set => SetProperty(ref employeeId, value);
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
        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnUpdate()
        {
            var dateNow = DateTime.Now;

            var objEmployee = new Employee()
            {
                Id = Id,
                CompanyId = CompanyId,
                Email = Email,
                Fax = Fax,
                Name = Name,
                Username = Username,
                Password = Password,
                PortalId = PortalId,
                RoleId = RoleId,
                StatusId = StatusId,
                Telephone = Telephone,
                CreatedOn = CreatedOn,
                DeletedOn = DeletedOn,
                Lastlogin = LastLogin,
                UpdatedOn = dateNow
            };

            var newEmployee = await _employeeRepo.UpdateAsync(CT.UrlEmployeeApi + Id, objEmployee);
            if (newEmployee)
                await Shell.Current.GoToAsync("..");
        }
        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadEmployeeCommand()
        {
            IsBusy = true;

            try
            {
                LoadEmployeeId(Id);
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

        public async void LoadEmployeeId(int employeeId)
        {
            try
            {
                var employee = await _employeeRepo.GetAsync(CT.UrlEmployeeApi, employeeId);
                //Id = employee.Id;
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
