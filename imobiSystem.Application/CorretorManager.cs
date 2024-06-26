﻿using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Interfaces.Repositories;
using imobiSystem.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application
{
    public class CorretorManager : ICorretorManager
    {
        private readonly ICorretorRepository _corretorRepository;
        private readonly ICorretorMapper _corretorMapper;

        public CorretorManager(ICorretorRepository corretorRepository, ICorretorMapper corretorMapper)
        {
            _corretorRepository = corretorRepository;
            _corretorMapper = corretorMapper;
        }

        public void Add(CorretorInputDto corretorDto)
        {
            var corretor = _corretorMapper.MapPostDtoToEntity(corretorDto);
            _corretorRepository.Add(corretor);
        }

        public IEnumerable<CorretorDto> GetAll()
        {
            var corretores = _corretorRepository.GetAll();
            return _corretorMapper.MapListCustomerDto(corretores);
        }

        public CorretorDto GetById(int id)
        {

            var corretor = _corretorRepository.GetById(id);

            if (corretor == null)
                throw new Exception(Mensagens.NaoEncontrado);

            return _corretorMapper.MapEntityToDto(corretor);
        }

        public void Remove(int id)
        {
            var corretor = _corretorRepository.GetById(id);

            if (corretor == null)
                throw new Exception("Corretor não encontrado!");

            _corretorRepository.Delete(corretor);
        }

        public void Update(int id, CorretorInputDto corretorDto)
        {
            var corretor = _corretorMapper.MapInputDtoToEntity(id, corretorDto);
            _corretorRepository.Update(corretor);
        }
    }
}
