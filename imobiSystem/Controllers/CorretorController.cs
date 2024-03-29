using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CorretorController : Controller
    {

        private readonly ICorretorManager _corretorManager;

        public CorretorController(ICorretorManager corretorManager)
        {
            _corretorManager = corretorManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_corretorManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_corretorManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CorretorDto corretorDTO)
        {
            try
            {
                if (corretorDTO == null)
                    return NotFound();

                _corretorManager.Add(corretorDTO);
                return Ok("Corretor adicionado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        public ActionResult Put([FromBody] CorretorDto corretorDto)
        {
            try
            {
                if (corretorDto == null)
                    return NotFound();

                _corretorManager.Update(corretorDto);
                return Ok("Corretor atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] CorretorDto corretorDto)
        {
            try
            {
                if (corretorDto == null)
                    return NotFound();

                _corretorManager.Remove(corretorDto);
                return Ok("Corretor removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
