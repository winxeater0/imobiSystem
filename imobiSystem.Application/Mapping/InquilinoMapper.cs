using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Mapping
{
    public class InquilinoMapper : IInquilinoMapper
    {
        public Inquilino MapDtoToEntity(InquilinoDto inquilinoDto)
        {
            return new Inquilino()
            {
                Id = inquilinoDto.Id,
                Nome = inquilinoDto.Nome,
                Documento = inquilinoDto.Documento,
            };
        }
        public Inquilino MapInputDtoToEntity(int id, InquilinoInputDto inquilinoDto)
        {
            return new Inquilino()
            {
                Id = id,
                Nome = inquilinoDto.Nome,
                Documento = inquilinoDto.Documento,
            };
        }

        public Inquilino MapDtoToEntity(InquilinoInputDto inquilinoDto)
        {
            return new Inquilino()
            {
                Nome = inquilinoDto.Nome,
                Documento = inquilinoDto.Documento,
            };
        }

        public InquilinoDto MapEntityToDto(Inquilino inquilino)
        {
            return new InquilinoDto()
            {
                Id = inquilino.Id,
                Nome = inquilino.Nome,
                Documento = inquilino.Documento,
            };
        }

        public IEnumerable<InquilinoDto> MapListCustomerDto(IEnumerable<Inquilino> inquilinos)
        {
            return inquilinos.Select(c => new InquilinoDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Documento = c.Documento,
            });
        }
    }
}
