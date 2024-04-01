using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Domain.Entities;
using imobiSystem.Domain.Interfaces.Repositories;
using imobiSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.LogsHandler
{
    public class LogsManager : ILogsManager
    {
        private readonly ILogsRepository _logsRepository;
        public LogsManager(ILogsRepository repositoryBase)
        {
            _logsRepository = repositoryBase;
        }

        public void Handler(string endpoint, string entrada, string saida)
        {
            var log = new Logs
            {
                Data = DateTime.Now,
                EndPoint = endpoint,
                Entrada = entrada,
                Saida = saida,
                UsuarioLogado = ""
            };

            _logsRepository.Add(log);
        }
    }
}
