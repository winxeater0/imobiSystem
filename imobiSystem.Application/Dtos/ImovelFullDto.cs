using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Dtos
{
    public class ImovelFullDto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public DateTime? DataAlugado { get; set; }
        public bool Alugado { get; set; }
        public InquilinoDto? Inquilino { get; set; }
        public ProprietarioDto? Proprietario { get; set; }
    }
}
