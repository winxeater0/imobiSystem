using imobiSystem.Application.Dtos;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces.Mapping
{
    public interface IProprietarioMapper
    {
        Proprietario MapDtoToEntity(ProprietarioDto proprietarioDto);
        Proprietario MapPostDtoToEntity(ProprietarioPostDto proprietarioDto);
        IEnumerable<ProprietarioDto> MapListCustomerDto(IEnumerable<Proprietario> proprietario);
        ProprietarioDto MapEntityToDto(Proprietario proprietario);
    }
}
