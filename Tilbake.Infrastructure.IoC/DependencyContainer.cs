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
            services.AddScoped<IKlientService, KlientService>();
            services.AddScoped<ILandService, LandService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<ITitleService, TitleService>();

            //  Infrastructure Data Layer
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBankBranchRepository, BankBranchRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<IKlientRepository, KlientRepository>();
            services.AddScoped<ILandRepository, LandRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
        }
    }
}
