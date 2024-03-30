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
    public class ProprietarioManager : IProprietarioManager
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IProprietarioMapper _proprietarioMapper;

        public ProprietarioManager(IProprietarioRepository proprietarioRepository, IProprietarioMapper proprietarioMapper)
        {
            _proprietarioRepository = proprietarioRepository;
            _proprietarioMapper = proprietarioMapper;
        }

        public void Add(ProprietarioPostDto ProprietarioDto)
        {
            var proprietario = _proprietarioMapper.MapPostDtoToEntity(ProprietarioDto);
            _proprietarioRepository.Add(proprietario);
        }

        public IEnumerable<ProprietarioDto> GetAll()
        {
            var proprietarios = _proprietarioRepository.GetAll();
            return _proprietarioMapper.MapListCustomerDto(proprietarios);
        }

        public ProprietarioDto GetById(int id)
        {
            var proprietario = _proprietarioRepository.GetById(id);
            return _proprietarioMapper.MapEntityToDto(proprietario);
        }

        public void Remove(int id)
        {
            var proprietario = _proprietarioRepository.GetById(id);
            _proprietarioRepository.Delete(proprietario);
        }

        public void Update(ProprietarioDto proprietarioDto)
        {
            var proprietario = _proprietarioMapper.MapDtoToEntity(proprietarioDto);
            _proprietarioRepository.Update(proprietario);
        }
    }
}
