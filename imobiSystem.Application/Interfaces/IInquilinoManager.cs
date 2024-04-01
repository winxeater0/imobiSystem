using imobiSystem.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces
{
    public interface IInquilinoManager
    {
        void Add(InquilinoInputDto inquilinoDto);
        void Update(int id, InquilinoInputDto inquilinoDto);
        void Remove(int id);
        IEnumerable<InquilinoDto> GetAll();
        InquilinoDto GetById(int id);
    }
}
