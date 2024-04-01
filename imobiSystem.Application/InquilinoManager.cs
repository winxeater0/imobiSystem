using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application
{
    public class InquilinoManager : IInquilinoManager
    {
        private readonly IInquilinoRepository _inquilinoRepository;
        private readonly IInquilinoMapper _inquilinoMapper;

        public InquilinoManager(IInquilinoRepository inquilinoRepository, IInquilinoMapper inquilinoMapper)
        {
            _inquilinoRepository = inquilinoRepository;
            _inquilinoMapper = inquilinoMapper;
        }

        public void Add(InquilinoInputDto inquilinoDto)
        {
            var inquilino = _inquilinoMapper.MapDtoToEntity(inquilinoDto);
            _inquilinoRepository.Add(inquilino);
        }

        public IEnumerable<InquilinoDto> GetAll()
        {
            var inquilinos = _inquilinoRepository.GetAll();
            return _inquilinoMapper.MapListCustomerDto(inquilinos);
        }

        public InquilinoDto GetById(int id)
        {
            var inquilino = _inquilinoRepository.GetById(id);
            return _inquilinoMapper.MapEntityToDto(inquilino);
        }

        public void Remove(int id)
        {
            var inquilino = _inquilinoRepository.GetById(id);
            _inquilinoRepository.Delete(inquilino);
        }

        public void Update(int id, InquilinoInputDto inquilinoDto)
        {
            var inquilino = _inquilinoMapper.MapInputDtoToEntity(id, inquilinoDto);
            _inquilinoRepository.Update(inquilino);
        }
    }
}
