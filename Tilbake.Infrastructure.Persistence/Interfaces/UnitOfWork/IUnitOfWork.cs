using System;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        IAllRiskRepository AllRisks { get; }
        IAuditRepository Audits { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBodyTypeRepository BodyTypes { get; }
        IBuildingRepository Buildings { get; }
        ICarrierRepository Carriers { get; }
        ICityRepository Cities { get; }
        IClientRepository Clients { get; }
        IClientBulkRepository ClientBulks { get; }
        IClientDocumentRepository ClientDocuments { get; }
        IClientCarrierRepository ClientCarriers { get; }
        IClientRiskRepository ClientRisks { get; }
        IClientTypeRepository ClientTypes{ get; }
        ICommissionRateRepository CommissionRates { get; }
        IContentRepository Contents { get; }
        ICountryRepository Countries { get; }
        ICoverTypeRepository CoverTypes { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDriverTypeRepository DriverTypes { get; }
        IEmailAddressRepository EmailAddresses { get; }
        IFileTemplateRepository FileTemplates { get; }
        IFileTemplateRecordRepository FileTemplateRecords { get; }
        IGenderRepository Genders { get; }
        IHouseRepository Houses { get; }
        IHouseConditionRepository HouseConditions { get; }
        IIdDocumentTypeRepository IdDocumentTypes { get; }
        IInsurerRepository Insurers { get; }
        IInvoiceRepository Invoices { get; }
        IInvoiceItemRepository InvoiceItems { get; }
        IInvoiceStatusRepository InvoiceStatuses { get; }
        IMaritalStatusRepository MaritalStatuses { get; }
        IMobileNumberRepository MobileNumbers { get; }
        IMotorRepository Motors { get; }
        IMotorMakeRepository MotorMakes { get; }
        IMotorModelRepository MotorModels { get; }
        IMotorUseRepository MotorUses { get; }
        IOccupationRepository Occupations { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPaymentTypeRepository PaymentTypes { get; }
        IPolicyRepository Policies { get; }
        IPolicyRiskRepository PolicyRisks { get; }
        IPolicyStatusRepository PolicyStatuses { get; }
        IPolicyTypeRepository PolicyTypes { get; }
        IPortfolioRepository Portfolios { get; }
        IPortfolioAdministrationFeeRepository PortfolioAdministrationFees { get; }
        IPortfolioClientRepository PortfolioClients { get; }
        IPortfolioPolicyFeeRepository PortfolioPolicyFees { get; }
        IPremiumRepository Premiums { get; }
        IQuoteRepository Quotes { get; }
        IQuoteItemRepository QuoteItems { get; }
        IQuoteStatusRepository QuoteStatuses { get; }
        IReceivableRepository Receivables { get; }
        IReceivableDocumentRepository ReceivableDocuments { get; }
        IReceivableInvoiceRepository ReceivableInvoices { get; }
        IResidenceTypeRepository ResidenceTypes { get; }
        IResidenceUseRepository ResidenceUses { get; }
        IRiskRepository Risks { get; }
        IRiskItemRepository RiskItems { get; }
        IRoofTypeRepository RoofTypes { get; }
        ISalesTypeRepository SalesTypes { get; }
        ITitleRepository Titles { get; }
        IUserPortfolioRepository UserPortfolios { get; }
        ITaxRepository Taxes { get; }
        IWallTypeRepository WallTypes { get; }

        Task<int> SaveAsync();
    }
}
