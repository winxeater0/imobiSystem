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
        private readonly ICorretorRepository _corretorRepository;
        private readonly IImovelMapper _imovelMapper;

        public ImovelManager(IImovelRepository imovelRepository, IInquilinoRepository inquilinoRepository, ICorretorRepository corretorRepository,
            IProprietarioRepository proprietarioRepository, IImovelMapper imovelMapper)
        {
            _imovelRepository = imovelRepository;
            _inquilinoRepository = inquilinoRepository;
            _proprietarioRepository = proprietarioRepository;
            _corretorRepository = corretorRepository;
            _imovelMapper = imovelMapper;
        }

        public void Add(ImovelPostDto imovelDto, int proprietarioId)
        {
            var imovel = _imovelMapper.MapPostDtoToEntity(imovelDto);

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

        public ImovelFullDto GetFullImovel(int id)
        {
            var imovel = _imovelRepository.GetFullImovel(id);

            if (imovel == null)
                throw new Exception("O imovel não está cadastrado.");

            return _imovelMapper.MapFullEntityToDto(imovel);
        }

        public void Remove(int id)
        {
            var imovel = _imovelRepository.GetById(id);
            if (imovel == null)
                throw new Exception("Imóvel não encontrado.");

            _imovelRepository.Delete(imovel);
        }

        public void Update(ImovelDto imovelDto)
        {
            var imovel = _imovelMapper.MapDtoToEntity(imovelDto);
            _imovelRepository.Update(imovel);
        }

        public void Alugar(AlugarDto alugarDto)
        {
            var imovel = _imovelRepository.GetById(alugarDto.ImovelId);

            if (imovel == null)
                throw new Exception("Imóvel não encontrado.");

            var inquilino = _inquilinoRepository.GetById(alugarDto.InquilinoId);

            if (inquilino == null)
                throw new Exception("Inquilino não encontrado.");

            var proprietario = _proprietarioRepository.GetById(alugarDto.ProprietarioId);

            if (proprietario == null)
                throw new Exception("Proprietario não encontrado.");

            var corretor = _corretorRepository.GetById(alugarDto.CorretorId);

            if (corretor == null)
                throw new Exception("Corretor não encontrado.");

            imovel.Alugar(inquilino, corretor);

            _imovelRepository.Update(imovel);
        }
    }
}
