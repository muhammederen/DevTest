using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeveloperTest.Database.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        [ForeignKey("CustomerType")]
        public int CustomerTypeId { get; set; }
        public CustomerType CustomerType { get; set; }

        public List<Job> Jobs { get; set; }
    }
}