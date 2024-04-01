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
    public class InquilinoController : Controller
    {

        private readonly IInquilinoManager _inquilinoManager;
        private readonly ILogsManager _logsManager;

        public InquilinoController(IInquilinoManager inquilinoManager, ILogsManager logsManager)
        {
            _inquilinoManager = inquilinoManager;
            _logsManager = logsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<InquilinoDto> result = null;
            var output = string.Empty;

            try
            {
                result = _inquilinoManager.GetAll();
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            _logsManager.Handler("Inquilino/Get/", string.Empty, StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            InquilinoDto result = null;
            var output = string.Empty;

            try
            {
                result = _inquilinoManager.GetById(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Inquilino/Get/{id}", id.ToString(), StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] InquilinoInputDto inquilinoDto)
        {
            var output = Mensagens.AdicionadoComSucesso;

            try
            {
                if (inquilinoDto == null)
                    return NotFound();

                _inquilinoManager.Add(inquilinoDto);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            _logsManager.Handler("Inquilino/Post/", JsonSerializer.Serialize(inquilinoDto), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] InquilinoInputDto inquilinoDto)
        {
            var output = Mensagens.AtualizadoComSucesso;

            try
            {
                if (inquilinoDto == null)
                    return NotFound();

                _inquilinoManager.Update(id, inquilinoDto);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Inquilino/Put/", JsonSerializer.Serialize(inquilinoDto), StringExtension.CheckObjAsString(null, output));
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

                _inquilinoManager.Remove(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Inquilino/Delete/{id}", id.ToString(), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

    }
}
