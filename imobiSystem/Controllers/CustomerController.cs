using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {

        private readonly ICustomerManager _customerManager;

        public CustomerController(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_customerManager.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_customerManager.GetById(id));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] CustomerDto customerDTO)
        {
            try
            {
                if (customerDTO == null)
                    return NotFound();

                _customerManager.Add(customerDTO);
                return Ok("Customer added success!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        // PUT api/values/5
        [HttpPut]
        public ActionResult Put([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                    return NotFound();

                _customerManager.Update(customerDto);
                return Ok("Customer updated success!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/values/5
        [HttpDelete()]
        public ActionResult Delete([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                    return NotFound();

                _customerManager.Remove(customerDto);
                return Ok("Customer deleted success!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
