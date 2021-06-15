using Autofac;
using Tilbake.Domain.Interfaces;
using Tilbake.Infrastructure.Persistence.Repositories;
using System.Linq;

namespace Tilbake.Infrastructure.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BankService).Assembly)
                    .Where(t => t.Name.EndsWith("Service"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(BankRepository).Assembly)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ValidationBehaviour<,>))
                    .As(typeof(IPipelineBehavior<,>))
                    .InstancePerLifetimeScope();
        }
    }
}