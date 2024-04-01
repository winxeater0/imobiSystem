using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Domain.Entities
{
    public class Logs
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string EndPoint { get; set; }
        public string Entrada { get; set; }
        public string Saida { get; set; }
        public string UsuarioLogado { get; set; }
    }
}
