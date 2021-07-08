using Autofac;
using Tilbake.Application.Services;
using Tilbake.Infrastructure.Persistence.Repositories;

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

            //builder.RegisterGeneric(typeof(ApplicationUserClaimsPrincipalFactory<,>))
            //        .As(typeof(IUserClaimsPrincipalFactory<ApplicationUser>))
            //        .InstancePerLifetimeScope();
        }
    }
}