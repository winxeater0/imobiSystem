using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Domain.Entities
{
    public class Inquilino
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Documento { get; set; }
        public List<Corretor> Corretores { get; } = new List<Corretor>();
        public List<Imovel> Imoveis { get; } = new List<Imovel>();

        public void VincularCorretorContactado(List<Corretor> corretores) => corretores.ForEach(x=> Corretores.Add(x));
    }
}
