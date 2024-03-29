using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Domain.Entities
{
    public class Corretor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public List<Proprietario> Proprietarios { get; } = new List<Proprietario>();
        public List<Inquilino> Inquilinos { get; } = new List<Inquilino>();
    }
}
