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
    public class CorretorController : Controller
    {

        private readonly ICorretorManager _corretorManager;
        private readonly ILogsManager _logsManager;

        public CorretorController(ICorretorManager corretorManager, ILogsManager logsManager)
        {
            _corretorManager = corretorManager;
            _logsManager = logsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            IEnumerable<CorretorDto> result = null;
            var output = string.Empty;

            try
            {
                result = _corretorManager.GetAll();
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Corretor/Get/", string.Empty, StringExtension.CheckObjAsString(result, output));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            CorretorDto result = null;
            var output = string.Empty;

            try
            {
                result = _corretorManager.GetById(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Corretor/Get/{id}", id.ToString(), StringExtension.CheckObjAsString(result, output));
            return Ok(result);

        }


        [HttpPost]
        public ActionResult Post([FromBody] CorretorInputDto corretorDTO)
        {
            var output = Mensagens.AdicionadoComSucesso;

            try
            {
                if (corretorDTO == null)
                    return NotFound();

                _corretorManager.Add(corretorDTO);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Corretor/Post/", JsonSerializer.Serialize(corretorDTO), StringExtension.CheckObjAsString(null, output));
            return Ok(output);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] CorretorInputDto corretorDto)
        {
            var output = Mensagens.AtualizadoComSucesso;

            try
            {
                if (corretorDto == null)
                    return NotFound();

                _corretorManager.Update(id, corretorDto);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Corretor/Put/{id}", JsonSerializer.Serialize(corretorDto), StringExtension.CheckObjAsString(null, output));
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

                _corretorManager.Remove(id);
            }
            catch (Exception ex)
            {
                output = ex.Message;
            }

            _logsManager.Handler("Corretor/Delete/{id}", id.ToString(), StringExtension.CheckObjAsString(null, output));
            return Ok(output);

        }

    }
}
