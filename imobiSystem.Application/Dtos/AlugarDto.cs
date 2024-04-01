using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Dtos
{
    public class AlugarDto
    {
        public int ImovelId { get; set; }
        public int InquilinoId { get; set; }
        public int ProprietarioId { get; set; }
        public int CorretorId { get; set; }
    }
}
