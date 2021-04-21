using DeveloperTest.Database.Models;

namespace DeveloperTest.Models
{
    public class CustomerModel
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerTypeId { get; set; }
        public string CustomerType { get; set; }

        public JobModel[] Jobs { get; set; }
    }
}