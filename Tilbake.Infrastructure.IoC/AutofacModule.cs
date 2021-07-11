using Autofac;
using Tilbake.Application.Services;
using Tilbake.Infrastructure.Persistence.Interfaces;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;
using Tilbake.Infrastructure.Persistence.Repositories;
using Tilbake.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace Tilbake.Infrastructure.IoC
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

            //builder.RegisterGeneric(typeof(ApplicationUserClaimsPrincipalFactory<,>))
            //        .As(typeof(IUserClaimsPrincipalFactory<ApplicationUser>))
            //        .InstancePerLifetimeScope();
        }
    }
}