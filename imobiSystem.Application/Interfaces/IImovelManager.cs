using imobiSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces
{
    public interface IImovelManager
    {
        void Add(ImovelDto imovelDto, int proprietarioId);
        void Update(ImovelDto imovelDto);
        void Remove(ImovelDto imovelDto);
        IEnumerable<ImovelDto> GetAll();
        ImovelDto GetById(int id);
        void Alugar(int imovelId, int inquilinoId);
    }
}
