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
        void Add(ProprietarioDto proprietarioDto);
        void Update(ProprietarioDto proprietarioDto);
        void Remove(ProprietarioDto proprietarioDto);
        IEnumerable<ProprietarioDto> GetAll();
        ProprietarioDto GetById(int id);
    }
}
