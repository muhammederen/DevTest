using System;
using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext context;

        public CustomerService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public CustomerTypeModel[] GetCustomerTypes()
        {
            return context.CustomerTypes.Select(x => new CustomerTypeModel
            {
                Id = x.CustomerTypeId,
                Description = x.Description
            }).ToArray();
        }

        public CustomerModel[] GetCustomers()
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerTypeId = x.CustomerType.CustomerTypeId,
                CustomerType = x.CustomerType.Description,
                Jobs = x.Jobs.Select(j => new JobModel
                {
                    Engineer = j.Engineer,
                    When = j.When,
                    JobId = j.JobId
                }).ToArray()
            }).ToArray();
        }

        public CustomerModel GetCustomer(int id)
        {
            return context.Customers.Select(x => new CustomerModel
            {
                CustomerId = x.CustomerId,
                CustomerName = x.CustomerName,
                CustomerTypeId = x.CustomerType.CustomerTypeId,
                CustomerType = x.CustomerType.Description,
                Jobs = x.Jobs.Select(j => new JobModel
                {
                    Engineer = j.Engineer,
                    When = j.When,
                    JobId = j.JobId
                }).ToArray()
            }).FirstOrDefault(x => x.CustomerId.Equals(id));

        }

        public CustomerModel CreateCustomer(CustomerModel model)
        {
            var addedCustomer = context.Customers.Add(new Customer
            {
                CustomerName = model.CustomerName,
                CustomerTypeId = model.CustomerTypeId
            });

            context.SaveChanges();

            return new CustomerModel
            {
                CustomerId = addedCustomer.Entity.CustomerId,
                CustomerName = addedCustomer.Entity.CustomerName,
            };
        }
    }
}