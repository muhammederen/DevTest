using DeveloperTest.Models;

namespace DeveloperTest.Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerTypeModel[] GetCustomerTypes();

        CustomerModel[] GetCustomers();

        CustomerModel GetCustomer(int id);

        CustomerModel CreateCustomer(CustomerModel model);
    }
}