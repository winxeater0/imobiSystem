using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]/[action]")]
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
            try
            {
                return Ok(_imovelManager.GetFullImovel(id));

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ImovelPostDto imovelDTO, int proprietarioId)
        {
            try
            {
                if (imovelDTO == null || proprietarioId <= 0)
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

                _imovelManager.Update(imovelDto);
                return Ok("Imóvel atualizado com sucesso!");
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
                if (id <= 0)
                    return NotFound();

                _imovelManager.Remove(id);
                return Ok("Imóvel removido com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        public ActionResult Alugar([FromBody]AlugarDto alugarDto)
        {
            try
            {
                if (alugarDto.ImovelId <= 0 || alugarDto.InquilinoId <= 0 || alugarDto.ProprietarioId <= 0 || alugarDto.CorretorId <= 0)
                    return NotFound();

                _imovelManager.Alugar(alugarDto);
                return Ok("Imóvel alugado com sucesso!");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
