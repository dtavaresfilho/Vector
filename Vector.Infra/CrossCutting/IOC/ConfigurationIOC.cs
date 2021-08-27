using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Vector.Application;
using Vector.Application.Interfaces;
using Vector.Application.Interfaces.Mappers;
using Vector.Application.Mappers;
using Vector.Domain.Core.Interfaces.Repositories;
using Vector.Domain.Core.Interfaces.Services;
using Vector.Domain.Services;
using Vector.Infra.Data.Repositories;

namespace Vector.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            // Application
            builder.RegisterType<ApplicationServiceUsuario>().As<IApplicationServiceUsuario>();
            builder.RegisterType<ApplicationServiceAPITeste>().As<IApplicationServiceAPITeste>();
            
            // Service
            builder.RegisterType<ServiceUsuario>().As<IServiceUsuario>();

            // Repository
            builder.RegisterType<RepositoryUsuario>().As<IRepositoryUsuario>();            

            // Mapper
            builder.RegisterType<MapperUsuario>().As<IMapperUsuario>();
        }
    }
}
