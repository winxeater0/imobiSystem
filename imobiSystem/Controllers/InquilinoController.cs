using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InquilinoController : Controller
    {

        private readonly IInquilinoManager _inquilinoManager;

        public InquilinoController(IInquilinoManager inquilinoManager)
        {
            _inquilinoManager = inquilinoManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_inquilinoManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_inquilinoManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] InquilinoDto inquilinoDto)
        {
            try
            {
                if (inquilinoDto == null)
                    return NotFound();

                _inquilinoManager.Add(inquilinoDto);
                return Ok("Inquilino adicionado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        public ActionResult Put([FromBody] InquilinoDto inquilinoDto)
        {
            try
            {
                if (inquilinoDto == null)
                    return NotFound();

                _inquilinoManager.Update(inquilinoDto);
                return Ok("Inquilino atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                if (id == null)
                    return NotFound();

                _inquilinoManager.Remove(id);
                return Ok("Inquilino removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
