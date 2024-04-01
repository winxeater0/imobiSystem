using imobiSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces
{
    public interface IProprietarioManager
    {
        void Add(ProprietarioInputDto proprietarioDto);
        void Update(int id, ProprietarioInputDto proprietarioDto);
        void Remove(int id);
        IEnumerable<ProprietarioDto> GetAll();
        ProprietarioDto GetById(int id);
    }
}
