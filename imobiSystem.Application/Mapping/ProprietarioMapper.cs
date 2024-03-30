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
    public class ProprietarioMapper : IProprietarioMapper
    {
        public Proprietario MapDtoToEntity(ProprietarioDto customerDto)
        {
            return new Proprietario()
            {
                Id = customerDto.Id,
                Nome = customerDto.Nome,
                Documento = customerDto.Documento
            };
        }

        public Proprietario MapPostDtoToEntity(ProprietarioPostDto customerDto)
        {
            return new Proprietario()
            {
                Nome = customerDto.Nome,
                Documento = customerDto.Documento
            };
        }

        public ProprietarioDto MapEntityToDto(Proprietario proprietario)
        {
            return new ProprietarioDto()
            {
                Id= proprietario.Id,
                Nome = proprietario.Nome,
                Documento = proprietario.Documento
            };
        }

        public IEnumerable<ProprietarioDto> MapListCustomerDto(IEnumerable<Proprietario> proprietarios)
        {
            return proprietarios.Select(c => new ProprietarioDto
            {
                Id = c.Id,
                Nome = c.Nome,
                Documento = c.Documento
            });
        }
    }
}
