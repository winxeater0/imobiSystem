using imobiSystem.Application;
using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace imobiSystem.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ImovelController : Controller
    {

        private readonly IImovelManager _imovelManager;
        private readonly ILogsManager _logsManager;


        public ImovelController(IImovelManager imovelManager, ILogsManager logsManager)
        {
            _imovelManager = imovelManager;
            _logsManager = logsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<ImovelDto> result = null;
            var output = string.Empty;

            try
            {
                result = _imovelManager.GetAll();
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Get/", string.Empty, StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            ImovelFullDto result = null;
            var output = string.Empty;

            try
            {
                result = _imovelManager.GetFullImovel(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Get/{id}", id.ToString(), StringExtension.CheckObjAsString(result, output));
            return Ok();
        }

        [HttpPost]
        public ActionResult Post([FromBody] ImovelInputDto imovelDTO, int proprietarioId)
        {
            var output = Mensagens.AdicionadoComSucesso;

            try
            {
                if (imovelDTO == null || proprietarioId <= 0)
                    return NotFound();

                _imovelManager.Add(imovelDTO, proprietarioId);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Post/", JsonSerializer.Serialize(imovelDTO) + proprietarioId, StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] ImovelInputDto imovelDto)
        {
            var output = Mensagens.AtualizadoComSucesso;

            try
            {
                if (imovelDto == null)
                    return NotFound();

                _imovelManager.Update(id, imovelDto);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Put/", JsonSerializer.Serialize(imovelDto), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpDelete()]
        public ActionResult Delete(int id)
        {
            var output = Mensagens.RemovidoComSucesso;

            try
            {
                if (id <= 0)
                    return NotFound();

                _imovelManager.Remove(id);
                return Ok("Imóvel removido com sucesso!");
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Delete/{id}", id.ToString(), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpPost]
        public ActionResult Alugar([FromBody] AlugarDto alugarDto)
        {
            var output = "Alugado com sucesso!";

            try
            {
                if (alugarDto.ImovelId <= 0 || alugarDto.InquilinoId <= 0 || alugarDto.ProprietarioId <= 0 || alugarDto.CorretorId.Count() <= 0)
                    return NotFound();

                _imovelManager.Alugar(alugarDto);
                return Ok("Imóvel alugado com sucesso!");
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Imovel/Alugar/", JsonSerializer.Serialize(alugarDto), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

    }
}
