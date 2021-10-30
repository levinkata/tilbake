using Autofac;
using Tilbake.Application.Services;
using Tilbake.EF.Persistence.Repositories;

namespace Tilbake.EF.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BankRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(BankService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork))
                    .As(typeof(IUnitOfWork))
                    .InstancePerLifetimeScope();

            //This is needed by TilbakeDbContext to get the userId from claims
            builder.RegisterType(typeof(GetClaimsFromUser))
                    .As(typeof(IGetClaimsProvider))
                    .InstancePerLifetimeScope();
        }
    }
}