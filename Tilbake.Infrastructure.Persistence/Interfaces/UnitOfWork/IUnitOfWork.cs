using System;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBodyTypeRepository BodyTypes { get; }
        ICarrierRepository Carriers { get; }
        ICityRepository Cities { get; }
        IClientRepository Clients { get; }
        IClientRiskRepository ClientRisks { get; }
        IClientTypeRepository ClientTypes{ get; }
        ICountryRepository Countries { get; }
        ICoverTypeRepository CoverTypes { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDriverTypeRepository DriverTypes { get; }
        IGenderRepository Genders { get; }
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
        IQuoteStatusRepository QuoteStatuses { get; }
        IQuoteRepository Quotes { get; }
        IRiskRepository Risks { get; }
        ISalesTypeRepository SalesTypes { get; }
        ITitleRepository Titles { get; }
        IUserPortfolioRepository UserPortfolios { get; }

        Task<int> SaveAsync();
    }
}
