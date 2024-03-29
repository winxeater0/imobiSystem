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

            builder.RegisterType<ProprietarioManager>().As<IProprietarioManager>();
            builder.RegisterType<ProprietarioRepository>().As<IProprietarioRepository>();
            builder.RegisterType<ProprietarioMapper>().As<IProprietarioMapper>();

            builder.RegisterType<CorretorManager>().As<ICorretorManager>();
            builder.RegisterType<CorretorRepository>().As<ICorretorRepository>();
            builder.RegisterType<CorretorMapper>().As<ICorretorMapper>();

            builder.RegisterType<InquilinoManager>().As<IInquilinoManager>();
            builder.RegisterType<InquilinoRepository>().As<IInquilinoRepository>();
            builder.RegisterType<InquilinoMapper>().As<IInquilinoMapper>();

            builder.RegisterType<ImovelManager>().As<IImovelManager>();
            builder.RegisterType<ImovelRepository>().As<IImovelRepository>();
            builder.RegisterType<ImovelMapper>().As<IImovelMapper>();

            #endregion
        }
    }
}
