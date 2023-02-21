using _03_EFC_DependencyInjection.Models.Entitites;
using _03_EFC_DependencyInjection.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _03_EFC_DependencyInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomer(int id) 
        { 
            var customer = await _customerService.GetAsync(id);
            if (customer != null)
                return new OkObjectResult(customer);

            return NotFound();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomers()
        {
            var customers = await _customerService.GetAllAsync();
            if (customers != null)
                return new OkObjectResult(customers);

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> GetAllCustomers(CustomerEntity customer)
        {
            await _customerService.SaveAsync(customer);
            return Ok();
        }
    }
}
