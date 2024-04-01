using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Domain.Entities
{
    public class Imovel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Endereco { get; set; }
        public bool Alugado { get; set; } = false;
        public DateTime? DataAlugado { get; set; }
        public int ProprietarioId { get; set; }
        public int? InquilinoId { get; set; }
        public Proprietario Proprietario { get; set; } = null;
        public Inquilino? Inquilino { get; set; } = null;

        public void Alugar(Inquilino inquilino, List<Corretor> corretores)
        {
            inquilino.VincularCorretorContactado(corretores);
            Inquilino = inquilino;
            DataAlugado = DateTime.Now;
            Alugado = true;
        }

        public void VincularProprietario(Proprietario proprietario) => Proprietario = proprietario;
    }
}
