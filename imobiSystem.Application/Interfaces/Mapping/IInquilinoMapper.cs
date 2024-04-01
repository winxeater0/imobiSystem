using imobiSystem.Application.Dtos;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces.Mapping
{
    public interface IInquilinoMapper
    {
        Inquilino MapDtoToEntity(InquilinoDto inquilinoDto);
        Inquilino MapDtoToEntity(InquilinoPostDto inquilinoDto);
        IEnumerable<InquilinoDto> MapListCustomerDto(IEnumerable<Inquilino> inquilino);
        InquilinoDto MapEntityToDto(Inquilino inquilino);
    }
}
