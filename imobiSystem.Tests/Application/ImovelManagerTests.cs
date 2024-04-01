using imobiSystem.Application.Dtos;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Domain.Entities;
using imobiSystem.Domain.Interfaces.Repositories;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Tests.Application
{
    [TestClass]
    public class ImovelManagerTests
    {
        public ImovelManagerTests()
        {
            
        }

        [TestMethod]
        public void AddTest()
        {
            var mapperMocked = new Mock<IImovelMapper>();

            var imovel = new ImovelInputDto
            {
                Descricao = "desc",
                Endereco = "Endereco",
            };

            var imovelRepositoryMock = new Mock<IImovelRepository>();

            var imovelMocked = new Imovel
            {
                Id = 1,
                Descricao = "desc",
                Endereco = "Endereco",
                Alugado = false,
                DataAlugado = DateTime.Now,
            };

            var imovelMapped = mapperMocked.Setup(x => x.MapPostDtoToEntity(imovel)).Returns(imovelMocked);

            //add imovel no repo
            imovelRepositoryMock.Setup(x => x.Add(imovelMocked));

            var proprietarioRepositoryMock = new Mock<IProprietarioRepository>();

            var proprietario = new Proprietario
            {
                Id = 1,
                Documento = "doc1",
                Nome = "nome1"
            };

            //add prop no repo
            proprietarioRepositoryMock.Setup(x => x.Add(proprietario));

            var proprietarioOutput = proprietarioRepositoryMock.Setup(x => x.GetById(1));

            imovelMocked.VincularProprietario(proprietario);
            Assert.IsNotNull(imovel);
        }

        [TestMethod]
        public void AlugarTest()
        {
            var mapperMocked = new Mock<IImovelMapper>();

            var imovel = new ImovelInputDto
            {
                Descricao = "desc",
                Endereco = "Endereco",
            };

            var imovelRepositoryMock = new Mock<IImovelRepository>();

            var proprietario = new Proprietario
            {
                Id = 1,
                Documento = "doc1",
                Nome = "nome1"
            };

            var imovelMocked = new Imovel
            {
                Id = 1,
                Descricao = "desc",
                Endereco = "Endereco",
                Alugado = false,
                DataAlugado = DateTime.Now,
                Proprietario = proprietario
            };

            var imovelMapped = mapperMocked.Setup(x => x.MapPostDtoToEntity(imovel)).Returns(imovelMocked);

            //add imovel no repo
            imovelRepositoryMock.Setup(x => x.Add(imovelMocked));

            var proprietarioRepositoryMock = new Mock<IProprietarioRepository>();


            //add prop no repo
            proprietarioRepositoryMock.Setup(x => x.Add(proprietario));
            var proprietarioOutput = proprietarioRepositoryMock.Setup(x => x.GetById(proprietario.Id)).Returns(proprietario);


            var inquilinoRepositoryMock = new Mock<IInquilinoRepository>();

            var inquilino = new Inquilino
            {
                Id = 1,
                Nome = "nomeInquilino",
                Documento = "Doc1"
            };

            //add inq no repo
            inquilinoRepositoryMock.Setup(x => x.Add(inquilino));
            var inquilinoOutput = inquilinoRepositoryMock.Setup(x => x.GetById(inquilino.Id)).Returns(inquilino);

            var corretorRepositoryMock = new Mock<ICorretorRepository>();

            var corretor = new Corretor
            {
                Id = 1,
                Documento = "doc2",
                Nome = "nomeCorretor"
            };

            corretorRepositoryMock.Setup(x => x.Add(corretor));
            var corretorOutput = corretorRepositoryMock.Setup(x => x.GetById(corretor.Id)).Returns(corretor);

            imovelMocked.Alugar(inquilino, corretor);
            imovelRepositoryMock.Setup(x => x.Update(imovelMocked));

            Assert.IsNotNull(imovelMocked);
            Assert.IsNotNull(imovelMocked.Inquilino);
            Assert.IsFalse(imovelMocked.Inquilino.Corretores.Count().Equals(0));
            Assert.IsNotNull(imovelMocked.Proprietario);
        }
    }
}
