using Autofac;
using Tilbake.Domain.Interfaces.UnitOfWork;
using Tilbake.Infrastructure.Persistence.Repositories;
using System.Linq;
using Tilbake.Infrastructure.Persistence.Repositories.UnitOfWork;
using Tilbake.Application.PipelineBehaviours;
using MediatR;

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
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                    .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ValidationBehaviour<,>))
                    .As(typeof(IPipelineBehavior<,>))
                    .InstancePerLifetimeScope();
        }
    }
}