using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_customerService.GetCustomers());
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetCustomerTypes()
        {
            return Ok(_customerService.GetCustomerTypes());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = _customerService.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Create(CustomerModel model)
        {
            var customer = _customerService.CreateCustomer(model);
            return Ok(customer);
        }
    }
}