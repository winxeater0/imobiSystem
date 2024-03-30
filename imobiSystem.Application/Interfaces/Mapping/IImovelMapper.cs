﻿using imobiSystem.Application.Dtos;
using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application.Interfaces.Mapping
{
    public interface IImovelMapper
    {
        Imovel MapDtoToEntity(ImovelDto imovelDto);
        Imovel MapPostDtoToEntity(ImovelPostDto imovelDto);
        IEnumerable<ImovelDto> MapListCustomerDto(IEnumerable<Imovel> imovel);
        ImovelDto MapEntityToDto(Imovel imovel);
    }
}
