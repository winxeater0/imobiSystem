using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Entities;
using imobiSystem.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Application
{
    public class ImovelManager : IImovelManager
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IInquilinoRepository _inquilinoRepository;
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IImovelMapper _imovelMapper;

        public ImovelManager(IImovelRepository imovelRepository, IInquilinoRepository inquilinoRepository,
            IProprietarioRepository proprietarioRepository, IImovelMapper imovelMapper)
        {
            _imovelRepository = imovelRepository;
            _inquilinoRepository = inquilinoRepository;
            _proprietarioRepository = proprietarioRepository;
            _imovelMapper = imovelMapper;
        }

        public void Add(ImovelDto imovelDto, int proprietarioId)
        {
            var imovel = _imovelMapper.MapDtoToEntity(imovelDto);

            var proprietario = _proprietarioRepository.GetById(proprietarioId);

            if (proprietario == null)
                throw new Exception("O proprietário não está cadastrado.");

            imovel.VincularProprietario(proprietario);
            _imovelRepository.Add(imovel);
        }

        public IEnumerable<ImovelDto> GetAll()
        {
            var imoveis = _imovelRepository.GetAll();
            return _imovelMapper.MapListCustomerDto(imoveis);
        }

        public ImovelDto GetById(int id)
        {
            var imovel = _imovelRepository.GetById(id);
            return _imovelMapper.MapEntityToDto(imovel);
        }

        public void Remove(ImovelDto imovelDto)
        {
            var imovel = _imovelMapper.MapDtoToEntity(imovelDto);
            _imovelRepository.Delete(imovel);
        }

        public void Update(ImovelDto imovelDto)
        {
            var imovel = _imovelMapper.MapDtoToEntity(imovelDto);
            _imovelRepository.Update(imovel);
        }

        public void Alugar(int imovelId, int inquilinoId)
        {
            var imovel = _imovelRepository.GetById(imovelId);

            if (imovel == null)
                throw new Exception("Imóvel não encontrado.");

            var inquilino = _inquilinoRepository.GetById(inquilinoId);

            if (inquilino == null)
                throw new Exception("Inquilino não encontrado.");

            imovel.Alugar(inquilino);

            _imovelRepository.Update(imovel);
        }
    }
}
