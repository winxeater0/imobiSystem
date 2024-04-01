using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Dtos
{
    public class LogDto
    {
        public string EndPoint { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string UsuarioLogado { get; set; }
    }
}
