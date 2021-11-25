using Autofac;
using Tilbake.Core;
using Tilbake.Core.Interfaces;
using Tilbake.EF.Persistence;
using Tilbake.EF.Persistence.Repositories;

namespace Tilbake.EF.IoC
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
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