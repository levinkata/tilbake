using Microsoft.Extensions.DependencyInjection;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Services;
using Tilbake.Domain.Interfaces;
using Tilbake.Infrastructure.Data.Repositories;

namespace Tilbake.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            //  Application Layer
            services.AddScoped<IInsurerService, InsurerService>();

            //  Infrastructure Data Layer
            services.AddScoped<IInsurerRepository, InsurerRepository>();
        }



    }
}
