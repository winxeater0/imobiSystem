using imobiSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces
{
    public interface ICorretorManager
    {
        void Add(CorretorDto corretorDto);
        void Update(CorretorDto corretorDto);
        void Remove(CorretorDto corretorDto);
        IEnumerable<CorretorDto> GetAll();
        CorretorDto GetById(int id);
    }
}
