using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProprietarioController : Controller
    {

        private readonly IProprietarioManager _proprietarioManager;

        public ProprietarioController(IProprietarioManager proprietarioManager)
        {
            _proprietarioManager = proprietarioManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_proprietarioManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_proprietarioManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProprietarioPostDto proprietarioDto)
        {
            try
            {
                if (proprietarioDto == null)
                    return NotFound();

                _proprietarioManager.Add(proprietarioDto);
                return Ok("Proprietario adicionado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        public ActionResult Put([FromBody] ProprietarioDto proprietarioDto)
        {
            try
            {
                if (proprietarioDto == null)
                    return NotFound();

                _proprietarioManager.Update(proprietarioDto);
                return Ok("Proprietario atualizado com sucesso!");
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

                _proprietarioManager.Remove(id);
                return Ok("Proprietario removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
