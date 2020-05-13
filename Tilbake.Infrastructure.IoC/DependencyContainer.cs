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
            services.AddScoped<IBodyTypeService, BodyTypeService>();
            services.AddScoped<IDriverTypeService, DriverTypeService>();
            services.AddScoped<IInsurerService, InsurerService>();
            services.AddScoped<IKlientService, KlientService>();
            services.AddScoped<IKlientDocumentService, KlientDocumentService>();
            services.AddScoped<ILandService, LandService>();
            services.AddScoped<IMotorService, MotorService>();
            services.AddScoped<IMotorMakeService, MotorMakeService>();
            services.AddScoped<IMotorModelService, MotorModelService>();
            services.AddScoped<IMotorUseService, MotorUseService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IQuoteStatusService, QuoteStatusService>();
            services.AddScoped<IRiskItemService, RiskItemService>();
            services.AddScoped<ITitleService, TitleService>();

            //  Infrastructure Data Layer
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBankBranchRepository, BankBranchRepository>();
            services.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
            services.AddScoped<IDriverTypeRepository, DriverTypeRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<IKlientRepository, KlientRepository>();
            services.AddScoped<IKlientDocumentRepository, KlientDocumentRepository>();
            services.AddScoped<ILandRepository, LandRepository>();
            services.AddScoped<IMotorRepository, MotorRepository>();
            services.AddScoped<IMotorMakeRepository, MotorMakeRepository>();
            services.AddScoped<IMotorModelRepository, MotorModelRepository>();
            services.AddScoped<IMotorUseRepository, MotorUseRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteStatusRepository, QuoteStatusRepository>();
            services.AddScoped<IRiskItemRepository, RiskItemRepository>();
            services.AddScoped<ITitleRepository, TitleRepository>();
        }
    }
}
