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
    public class ProprietarioController : Controller
    {

        private readonly IProprietarioManager _proprietarioManager;
        private readonly ILogsManager _logsManager;


        public ProprietarioController(IProprietarioManager proprietarioManager, ILogsManager logsManager)
        {
            _proprietarioManager = proprietarioManager;
            _logsManager = logsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<ProprietarioDto> result = null;
            var output = string.Empty;

            try
            {
                result = _proprietarioManager.GetAll();
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }
            _logsManager.Handler("Proprietario/Get/", string.Empty, StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            ProprietarioDto result = null;
            var output = string.Empty;

            try
            {
                result = _proprietarioManager.GetById(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Proprietario/Get/{id}", id.ToString(), StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProprietarioInputDto proprietarioDto)
        {
            var output = Mensagens.AdicionadoComSucesso;

            try
            {
                if (proprietarioDto == null)
                    return NotFound();

                _proprietarioManager.Add(proprietarioDto);
                return Ok("Proprietario adicionado com sucesso!");
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Proprietario/Post/", JsonSerializer.Serialize(proprietarioDto), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] ProprietarioInputDto proprietarioDto)
        {
            var output = Mensagens.AtualizadoComSucesso;

            try
            {
                if (proprietarioDto == null)
                    return NotFound();

                _proprietarioManager.Update(id, proprietarioDto);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Proprietario/Put/", JsonSerializer.Serialize(proprietarioDto), StringExtension.CheckObjAsString(null, output));
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

                _proprietarioManager.Remove(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Proprietario/Delete/{id}", id.ToString(), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

    }
}
