using imobiSystem.Domain.Entities;
using imobiSystem.Domain.Interfaces.Repositories;
using imobiSystem.Infrastrusture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastructure.Data.Repositories
{
    public class ImovelRepository : RepositoryBase<Imovel>, IImovelRepository
    {
        private readonly SqlContext sqlContext;

        public ImovelRepository(SqlContext sqlContext) : base(sqlContext) 
        {
            this.sqlContext = sqlContext;
        }

        public Imovel GetFullImovel(int id)
        {
            return sqlContext.Imoveis
                .Where(x => x.Id == id)
                .Include(x => x.Inquilino)
                .Include(x => x.Proprietario)
                .FirstOrDefault();
        }
    }
}
