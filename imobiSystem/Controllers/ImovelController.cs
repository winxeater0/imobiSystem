using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImovelController : Controller
    {

        private readonly IImovelManager _imovelManager;

        public ImovelController(IImovelManager imovelManager)
        {
            _imovelManager = imovelManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_imovelManager.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Ok(_imovelManager.GetById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] ImovelDto imovelDTO, int proprietarioId)
        {
            try
            {
                if (imovelDTO == null || proprietarioId == null)
                    return NotFound();

                _imovelManager.Add(imovelDTO, proprietarioId);
                return Ok("Imóvel adicionado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        [HttpPut]
        public ActionResult Put([FromBody] ImovelDto imovelDto)
        {
            try
            {
                if (imovelDto == null)
                    return NotFound();

                var imovel = _imovelManager.GetById(imovelDto.Id);

                _imovelManager.Update(imovelDto);
                return Ok("Imóvel atualizado com sucesso!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] ImovelDto imovelDto)
        {
            try
            {
                if (imovelDto == null)
                    return NotFound();

                _imovelManager.Remove(imovelDto);
                return Ok("Imóvel removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody]int imovelId, int inquilinoId)
        {
            try
            {
                if (imovelId == null || inquilinoId == null)
                    return NotFound();

                _imovelManager.Alugar(imovelId, imovelId);
                return Ok("Imóvel alugado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
