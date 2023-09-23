using Autofac;
using LucasChallenge.Aplication;
using LucasChallenge.Aplication.Interfaces;
using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Services;
using LucasChallenge.Infra.Data.Data.Repositorys;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;
using LucasChallenge.Infrastructure.CrossCutting.Mapper;

namespace LucasChallenge.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<AplicationServiceCompany>().As<IAplicationServiceCompany>();
            builder.RegisterType<AplicationServiceSupplier>().As<IAplicationServiceSupplier>();

            builder.RegisterType<ServiceCompany>().As<IServiceCompany>();
            builder.RegisterType<ServiceSupplier>().As<IServiceSupplier>();

            builder.RegisterType<RepositoryCompany>().As<IRepositoryCompany>();
            builder.RegisterType<RepositorySupplier>().As<IRepositorySupplier>();

            builder.RegisterType<MapperCompany>().As<IMapperCompany>();
            builder.RegisterType<MapperSupplier>().As<IMapperSupplier>();

            #endregion IOC
        }
    }
}