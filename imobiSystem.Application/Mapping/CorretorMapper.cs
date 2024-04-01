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
    public class CorretorMapper : ICorretorMapper
    {
        public Corretor MapDtoToEntity(CorretorDto corretorDto)
        {
            return new Corretor()
            {
                Id = corretorDto.Id,
                Nome = corretorDto.Nome,
                Documento = corretorDto.Documento
            };
        }
        public Corretor MapInputDtoToEntity(int id, CorretorInputDto corretorDto)
        {
            return new Corretor()
            {
                Id = id,
                Nome = corretorDto.Nome,
                Documento = corretorDto.Documento
            };
        }

        public Corretor MapPostDtoToEntity(CorretorInputDto corretorDto)
        {
            return new Corretor()
            {
                Nome = corretorDto.Nome,
                Documento = corretorDto.Documento
            };
        }

        public CorretorDto MapEntityToDto(Corretor corretor)
        {
            return new CorretorDto()
            {
                Id = corretor.Id,
                Nome = corretor.Nome,
                Documento = corretor.Documento
            };
        }

        public IEnumerable<CorretorDto> MapListCustomerDto(IEnumerable<Corretor> corretores)
        {
            return corretores.Select(c => new CorretorDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Documento = c.Documento
            });
        }
    }
}
