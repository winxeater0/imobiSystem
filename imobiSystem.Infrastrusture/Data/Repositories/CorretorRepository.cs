﻿using imobiSystem.Domain.Entities;
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
    public class CorretorRepository : RepositoryBase<Corretor>, ICorretorRepository
    {
        private readonly SqlContext sqlContext;

        public CorretorRepository(SqlContext sqlContext) : base(sqlContext) 
        {
            this.sqlContext = sqlContext;
        }

        public List<Corretor> GetCorretoresByIds(List<int> ids)
        {
            var ret = sqlContext.Corretores
                .Where(x => ids.Contains(x.Id)).ToList();
            return ret;
        }
    }
}
