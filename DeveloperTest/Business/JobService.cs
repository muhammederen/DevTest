using System;
using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            return context.Jobs.Include(x => x.Customer.CustomerType).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                Customer = new CustomerModel
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.CustomerName,
                    CustomerType = x.Customer.CustomerType.Description
                }
            }).ToArray();
        }

        public JobModel GetJob(int jobId)
        {

            return context.Jobs.Include(x => x.Customer.CustomerType).Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                Customer = new CustomerModel
                {
                    CustomerId = x.CustomerId,
                    CustomerName = x.Customer.CustomerName,
                    CustomerType = x.Customer.CustomerType.Description
                }
            }).SingleOrDefault();
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = Convert.ToInt32(model.Customer)
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When
            };
        }
    }
}
