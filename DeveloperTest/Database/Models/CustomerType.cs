using System.ComponentModel.DataAnnotations;

namespace DeveloperTest.Database.Models
{
    public class CustomerType
    {
        [Key]
        public int CustomerTypeId { get; set; }
        public string Description { get; set; }
    }
}