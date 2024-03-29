using imobiSystem.Domain.Entities;
using imobiSystem.Domain.Interfaces.Repositories;
using imobiSystem.Infrastrusture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastructure.Data.Repositories
{
    public class ProprietarioRepository : RepositoryBase<Proprietario>, IProprietarioRepository
    {
        private readonly SqlContext sqlContext;

        public ProprietarioRepository(SqlContext sqlContext) : base(sqlContext) 
        {
            this.sqlContext = sqlContext;
        }
    }
}
