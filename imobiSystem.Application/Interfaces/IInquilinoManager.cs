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
        void Add(InquilinoDto inquilinoDto);
        void Update(InquilinoDto inquilinoDto);
        void Remove(int id);
        IEnumerable<InquilinoDto> GetAll();
        InquilinoDto GetById(int id);
    }
}
