using Employee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PocController : ControllerBase
    {
        private IEmployeeRepo _employeeRepo= null;

        public PocController(IEmployeeRepo employeeRepo)
        {
            this._employeeRepo = employeeRepo;
        }

        // GET: api/<PocController>
        [HttpGet]
        public ActionResult<List<Employ>> Get()
        {
            return _employeeRepo.GetAll();
        }

        // GET api/<PocController>/5
        //[Route("api/[controller]/")]
        [HttpGet("{id}")]
        public ActionResult<Employ> Get(int id)
        {
            return _employeeRepo.EmployeeGet(id);
        }
        [HttpGet("{department id}")]
        public ActionResult<Employ> GetByDept(int DepId)
        {
            return _employeeRepo.GetByDept(DepId);
        }

        // POST api/<PocController>
        [HttpPost]
        public void Post([FromBody]Employ employ)
        {
            _employeeRepo.Add(employ);
        }

        // PUT api/<PocController>/5
        [HttpPut]
        public void Put([FromBody]Employ employ)
        {
            _employeeRepo.Edit(employ);
        }

        // DELETE api/<PocController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
