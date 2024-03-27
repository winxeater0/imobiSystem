using Autofac;
using imobiSystem.Application;
using imobiSystem.Application.Interfaces;
using imobiSystem.Application.Interfaces.Mapping;
using imobiSystem.Application.Mapping;
using imobiSystem.Domain.Interfaces.Repositories;
using imobiSystem.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imobiSystem.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<CustomerManager>().As<ICustomerManager>();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();

            builder.RegisterType<CustomerMapper>().As<ICustomerMapper>();
            
            #endregion
        }
    }
}
