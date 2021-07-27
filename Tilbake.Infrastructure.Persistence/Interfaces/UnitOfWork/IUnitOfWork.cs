using System;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAllRiskRepository AllRisks { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBodyTypeRepository BodyTypes { get; }
        ICarrierRepository Carriers { get; }
        ICityRepository Cities { get; }
        IClientDocumentRepository ClientDocuments { get; }
        IClientRepository Clients { get; }
        IClientRiskRepository ClientRisks { get; }
        IClientTypeRepository ClientTypes{ get; }
        IContentRepository Contents { get; }
        ICountryRepository Countries { get; }
        ICoverTypeRepository CoverTypes { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDriverTypeRepository DriverTypes { get; }
        IGenderRepository Genders { get; }
        IHouseRepository Houses { get; }
        IHouseConditionRepository HouseConditions { get; }
        IInsurerRepository Insurers { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceStatusRepository InvoiceStatuses { get; }
        IMaritalStatusRepository MaritalStatuses { get; }
        IMotorRepository Motors { get; }
        IMotorMakeRepository MotorMakes { get; }
        IMotorModelRepository MotorModels { get; }
        IMotorUseRepository MotorUses { get; }
        IOccupationRepository Occupations { get; }
        IPolicyStatusRepository PolicyStatuses { get; }
        IPolicyTypeRepository PolicyTypes { get; }
        IPortfolioRepository Portfolios { get; }
        IPortfolioClientRepository PortfolioClients { get; }
        IQuoteRepository Quotes { get; }
        IQuoteItemRepository QuoteItems { get; }
        IQuoteStatusRepository QuoteStatuses { get; }
        IResidenceTypeRepository ResidenceTypes { get; }
        IResidenceUseRepository ResidenceUses { get; }
        IRiskRepository Risks { get; }
        IRiskItemRepository RiskItems { get; }
        IRoofTypeRepository RoofTypes { get; }
        ISalesTypeRepository SalesTypes { get; }
        ITitleRepository Titles { get; }
        IUserPortfolioRepository UserPortfolios { get; }
        IWallTypeRepository WallTypes { get; }

        Task<int> SaveAsync();
    }
}
