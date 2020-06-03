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
            services.AddScoped<IAllRiskService, AllRiskService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<IBankBranchService, BankBranchService>();
            services.AddScoped<IBodyTypeService, BodyTypeService>();
            services.AddScoped<ICoverTypeService, CoverTypeService>();
            services.AddScoped<IDocumentTypeService, DocumentTypeService>();
            services.AddScoped<IDriverTypeService, DriverTypeService>();
            services.AddScoped<IGlassService, GlassService>();
            services.AddScoped<IHouseService, HouseService>();
            services.AddScoped<IIncidentService, IncidentService>();
            services.AddScoped<IInsurerService, InsurerService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceStatusService, InvoiceStatusService>();
            services.AddScoped<IKlientService, KlientService>();
            services.AddScoped<IKlientBankAccountService, KlientBankAccountService>();
            services.AddScoped<IKlientDocumentService, KlientDocumentService>();
            services.AddScoped<IKlientRiskService, KlientRiskService>();
            services.AddScoped<IKravService, KravService>();
            services.AddScoped<IKravStatusService, KravStatusService>();
            services.AddScoped<IKlientDocumentService, KlientDocumentService>();
            services.AddScoped<ILandService, LandService>();
            services.AddScoped<IMotorService, MotorService>();
            services.AddScoped<IMotorMakeService, MotorMakeService>();
            services.AddScoped<IMotorModelService, MotorModelService>();
            services.AddScoped<IMotorUseService, MotorUseService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IPolitikkService, PolitikkService>();
            services.AddScoped<IPolitikkRiskService, PolitikkRiskService>();
            services.AddScoped<IPolitikkStatusService, PolitikkStatusService>();
            services.AddScoped<IPolitikkTypeService, PolitikkTypeService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IPremiumService, PremiumService>();
            services.AddScoped<IPremiumTypeService, PremiumTypeService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IQuoteStatusService, QuoteStatusService>();
            services.AddScoped<IRegionService, RegionService>();            
            services.AddScoped<IResidenceTypeService, ResidenceTypeService>();
            services.AddScoped<IRiskItemService, RiskItemService>();
            services.AddScoped<IRoofTypeService, RoofTypeService>();
            services.AddScoped<ISalesTypeService, SalesTypeService>();
            services.AddScoped<ITitleService, TitleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IWallTypeService, WallTypeService>();

            //  Infrastructure Data Layer
            services.AddScoped<IAllRiskRepository, AllRiskRepository>();
            services.AddScoped<IBankRepository, BankRepository>();
            services.AddScoped<IBankBranchRepository, BankBranchRepository>();
            services.AddScoped<IBodyTypeRepository, BodyTypeRepository>();
            services.AddScoped<ICoverTypeRepository, CoverTypeRepository>();
            services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            services.AddScoped<IDriverTypeRepository, DriverTypeRepository>();
            services.AddScoped<IHouseRepository, HouseRepository>();
            services.AddScoped<IGlassRepository, GlassRepository>();
            services.AddScoped<IIncidentRepository, IncidentRepository>();
            services.AddScoped<IInsurerRepository, InsurerRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceStatusRepository, InvoiceStatusRepository>();
            services.AddScoped<IKlientRepository, KlientRepository>();
            services.AddScoped<IKlientBankAccountRepository, KlientBankAccountRepository>();
            services.AddScoped<IKlientDocumentRepository, KlientDocumentRepository>();
            services.AddScoped<IKlientRiskRepository, KlientRiskRepository>();
            services.AddScoped<IKravRepository, KravRepository>();
            services.AddScoped<IKravStatusRepository, KravStatusRepository>();
            services.AddScoped<ILandRepository, LandRepository>();
            services.AddScoped<IMotorRepository, MotorRepository>();
            services.AddScoped<IMotorMakeRepository, MotorMakeRepository>();
            services.AddScoped<IMotorModelRepository, MotorModelRepository>();
            services.AddScoped<IMotorUseRepository, MotorUseRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IPolitikkRepository, PolitikkRepository>();
            services.AddScoped<IPolitikkRiskRepository, PolitikkRiskRepository>();
            services.AddScoped<IPolitikkStatusRepository, PolitikkStatusRepository>();
            services.AddScoped<IPolitikkTypeRepository, PolitikkTypeRepository>();
            services.AddScoped<IPortfolioRepository, PortfolioRepository>();
            services.AddScoped<IPremiumRepository, PremiumRepository>();
            services.AddScoped<IPremiumTypeRepository, PremiumTypeRepository>();
            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteStatusRepository, QuoteStatusRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();             
            services.AddScoped<IResidenceTypeRepository, ResidenceTypeRepository>();            
            services.AddScoped<IRiskItemRepository, RiskItemRepository>();
            services.AddScoped<IRoofTypeRepository, RoofTypeRepository>();            
            services.AddScoped<ITitleRepository, TitleRepository>();
            services.AddScoped<ISalesTypeRepository, SalesTypeRepository>();
            services.AddScoped<IWallTypeRepository, WallTypeRepository>();
        }
    }
}
