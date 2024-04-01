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
    public class ImovelMapper : IImovelMapper
    {
        public Imovel MapDtoToEntity(ImovelDto imovelDto)
        {
            return new Imovel()
            {
                Id = imovelDto.Id,
                Descricao = imovelDto.Descricao,
                Endereco = imovelDto.Endereco,
            };
        }

        public Imovel MapPostDtoToEntity(ImovelPostDto imovelDto)
        {
            return new Imovel()
            {
                Descricao = imovelDto.Descricao,
                Endereco = imovelDto.Endereco,
            };
        }

        public ImovelDto MapEntityToDto(Imovel imovel)
        {
            return new ImovelDto()
            {
                Id = imovel.Id,
                Descricao = imovel.Descricao,
                Endereco = imovel.Endereco,
            };
        }

        public ImovelFullDto MapFullEntityToDto(Imovel imovel)
        {
            return new ImovelFullDto()
            {
                Id = imovel.Id,
                Descricao = imovel.Descricao,
                Endereco = imovel.Endereco,
                DataAlugado = imovel.DataAlugado,
                Alugado = imovel.Alugado,
                Inquilino = new InquilinoDto()
                {
                    Id = imovel.Inquilino.Id,
                    Documento = imovel.Inquilino.Documento,
                    Nome = imovel.Inquilino.Nome
                },
                Proprietario = new ProprietarioDto()
                {
                    Id = imovel.Proprietario.Id,
                    Nome = imovel.Proprietario.Nome,
                    Documento = imovel.Proprietario.Documento
                }
            };
        }

        public IEnumerable<ImovelDto> MapListCustomerDto(IEnumerable<Imovel> imoveis)
        {
            return imoveis.Select(c => new ImovelDto
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Endereco = c.Endereco,
            });
        }
    }
}
