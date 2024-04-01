using imobiSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Tests.Domain
{
    [TestClass]
    public class ImovelTests
    {
        [TestMethod]
        public void ImovelTest()
        {
            var obj = new Imovel()
            {
                Id = 1,
                Descricao = "desc",
                Endereco = "Endereco",
                Alugado = false,
                DataAlugado = DateTime.Now,
            };

            Assert.IsNotNull(obj);
        }
    }
}
