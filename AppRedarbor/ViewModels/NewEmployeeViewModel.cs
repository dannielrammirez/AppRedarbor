using AppRedarbor.Models;
using AppRedarbor.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRedarbor.ViewModels
{
    public class NewEmployeeViewModel : BaseViewModel
    {
        private int id;
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
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public NewEmployeeViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
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

        public int Id
        {
            get => id;
            set => SetProperty(ref id, value);
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

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var dateNow = DateTime.Now;

            var objEmployee = new Employee()
            {
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
                CreatedOn = dateNow,
                DeletedOn = dateNow,
                Lastlogin = dateNow,
                UpdatedOn = dateNow
            };

            var newEmployee = await _employeeRepo.SaveAsync(CT.UrlEmployeeApi, objEmployee);
            if (newEmployee)
            {
                // This will pop the current page off the navigation stack
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
