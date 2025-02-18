using Business.Services;
using Microsoft.AspNetCore.Mvc;
using Persistence.Models;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/customer
        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        // GET: api/customer/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        // POST: api/customer
        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _customerService.AddCustomer(customer);
            return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
        }
    }
}
