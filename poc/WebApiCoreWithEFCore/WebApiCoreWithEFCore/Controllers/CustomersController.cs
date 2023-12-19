using Microsoft.AspNetCore.Mvc;
using WebApiCoreWithEFCore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCoreWithEFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository _customerRepository = null;

        public CustomersController(ICustomerRepository customerRepository)
        {
            this._customerRepository= customerRepository;
        }
        // GET: api/<CustomersController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            return _customerRepository.GetCustomers();
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            return _customerRepository.GetCustomer(id);
        }

        // POST api/<CustomersController>
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer customer)
        {
            return _customerRepository.AddCustomer(customer);
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public ActionResult<Customer> Put(int id, [FromBody] Customer customer)
        {
            return _customerRepository.UpdateCustomer(id, customer);
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return _customerRepository.DeleteCustomer(id);
        }
    }
}
