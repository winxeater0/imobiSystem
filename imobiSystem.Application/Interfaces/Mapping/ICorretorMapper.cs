using imobiSystem.Application.Dtos;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces.Mapping
{
    public interface ICorretorMapper
    {
        Corretor MapDtoToEntity(CorretorDto corretorDto);
        public Corretor MapPostDtoToEntity(CorretorPostDto corretorDto);
        IEnumerable<CorretorDto> MapListCustomerDto(IEnumerable<Corretor> corretor);
        CorretorDto MapEntityToDto(Corretor corretor);
    }
}
