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
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankBranchService, BankBranchService>();
            services.AddScoped<IInsurerService, InsurerService>();
            services.AddScoped<IOccupationService, OccupationService>();

            //  Infrastructure Data Layer
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBankBranchRepository, BankBranchRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
        }



    }
}
