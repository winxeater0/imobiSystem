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
        void Add(CorretorInputDto corretorDto);
        void Update(int id, CorretorInputDto corretorDto);
        void Remove(int id);
        IEnumerable<CorretorDto> GetAll();
        CorretorDto GetById(int id);
    }
}
