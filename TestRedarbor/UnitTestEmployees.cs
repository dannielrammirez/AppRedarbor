using AppRedarbor.Models;
using AppRedarbor.Services;
using AppRedarbor.Services.IRepository;
using AppRedarbor.Utilities;
using AppRedarbor.ViewModels;
using Moq;

namespace TestRedarbor
{
    public class UnitTestEmployees
    {
        private static MockDependencyService _service = new MockDependencyService();
        private BaseViewModel bvm;
        private const int ID_EMPLOYEE = 1007;

        [SetUp]
        public void Setup()
        {
            var dpEmployees = new Mock<EmployeeRepository>();
            _service.Register<IEmployeeRepository>(dpEmployees.Object);
            bvm = new BaseViewModel(_service);
        }

        [Test]
        public async Task TestGetAllEmployees()
        {
            var response = await bvm._repoEmployee.GetAllAsync(CT.UrlEmployeeApi);

            Assert.IsNotEmpty(response);
        }

        [Test]
        public async Task TestGetEmployee()
        {
            int idEmployee = ID_EMPLOYEE;

            var response = await bvm._repoEmployee.GetAsync(CT.UrlEmployeeApi, idEmployee);

            Assert.IsNotNull(response);
        }

        [Test]
        public async Task TestCreateEmployee()
        {
            var currentDate = DateTime.Now;

            var objNewEmployee = new Employee()
            {
                CompanyId = 1,
                Email = "test@test.com",
                Fax = "123456789",
                Name = "NameTest",
                Username = "UsernameTest",
                Password = "PasswordTest",
                PortalId = 1,
                RoleId = 1,
                StatusId = 1,
                Telephone = "987654321",
                CreatedOn = currentDate,
                DeletedOn = currentDate,
                Lastlogin = currentDate,
                UpdatedOn = currentDate,
            };

            var response = await bvm._repoEmployee.SaveAsync(CT.UrlEmployeeApi, objNewEmployee);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task TestUpdateEmployee()
        {
            var currentDate = DateTime.Now;

            var objEmployee = new Employee();
            objEmployee.Id = ID_EMPLOYEE;
            objEmployee.CompanyId = 1;
            objEmployee.Email = "test@testUpdated.com";
            objEmployee.Fax = "1111111";
            objEmployee.Name = "NameTestUpdated";
            objEmployee.Username = "UsernameTestUpdated";
            objEmployee.Password = "PasswordTestUpdated";
            objEmployee.PortalId = 1;
            objEmployee.RoleId = 1;
            objEmployee.StatusId = 1;
            objEmployee.Telephone = "2222222";
            objEmployee.CreatedOn = currentDate;
            objEmployee.DeletedOn = currentDate;
            objEmployee.Lastlogin = currentDate;
            objEmployee.UpdatedOn = currentDate;

            var response = await bvm._repoEmployee.UpdateAsync(CT.UrlEmployeeApi + objEmployee.Id, objEmployee);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task TestDeleteEmployee()
        {
            int idEmployee = ID_EMPLOYEE;
            string urlAction = CT.UrlEmployeeApi + "DeleteEmployee/";

            var response = await bvm._repoEmployee.DeleteAsync(urlAction, idEmployee);

            Assert.IsTrue(response);
        }

        [Test]
        public async Task TestDeleteBDEmployee()
        {
            int idEmployee = ID_EMPLOYEE;
            string urlAction = CT.UrlEmployeeApi + "DeleteDBEmployee/";
            
            var response = await bvm._repoEmployee.DeleteAsync(urlAction, idEmployee);

            Assert.IsTrue(response);
        }
    }
}