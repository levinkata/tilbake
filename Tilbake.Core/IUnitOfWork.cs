using System;
using System.Threading.Tasks;
using Tilbake.Core.Interfaces;

namespace Tilbake.Core
{
    public interface IUnitOfWork
    {
        IAddressRepository Addresses { get; }
        IAllRiskRepository AllRisks { get; }
        IAllRiskSpecifiedRepository AllRiskSpecifieds { get; }
        IAuditRepository Audits { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBodyTypeRepository BodyTypes { get; }
        IBuildingRepository Buildings { get; }
        IBuildingConditionRepository BuildingConditions { get; }
        ICarrierRepository Carriers { get; }
        ICityRepository Cities { get; }
        IClientRepository Clients { get; }
        IClientBulkRepository ClientBulks { get; }
        IClientDocumentRepository ClientDocuments { get; }
        IClientCarrierRepository ClientCarriers { get; }
        IClientRiskRepository ClientRisks { get; }
        IClientTypeRepository ClientTypes{ get; }
        IClientStatusRepository ClientStatuses { get; }
        ICommissionRateRepository CommissionRates { get; }
        IContentRepository Contents { get; }
        ICountryRepository Countries { get; }
        ICoverTypeRepository CoverTypes { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDriverTypeRepository DriverTypes { get; }
        IEmailAddressRepository EmailAddresses { get; }
        IExcessBuyBackRepository ExcessBuyBacks { get; }
        IFileTemplateRepository FileTemplates { get; }
        IFileTemplateRecordRepository FileTemplateRecords { get; }
        IGenderRepository Genders { get; }
        IHouseRepository Houses { get; }
        IHouseConditionRepository HouseConditions { get; }
        IIdDocumentTypeRepository IdDocumentTypes { get; }
        IInsurerRepository Insurers { get; }
        IInsurerBranchRepository InsurerBranches { get; }        
        IInvoiceRepository Invoices { get; }
        IInvoiceItemRepository InvoiceItems { get; }
        IInvoiceStatusRepository InvoiceStatuses { get; }
        IMaritalStatusRepository MaritalStatuses { get; }
        IMobileNumberRepository MobileNumbers { get; }
        IMotorRepository Motors { get; }
        IMotorMakeRepository MotorMakes { get; }
        IMotorModelRepository MotorModels { get; }
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
        IPortfolioExcessBuyBackRepository PortfolioExcessBuyBacks { get; }
        IPortfolioPolicyFeeRepository PortfolioPolicyFees { get; }
        IPremiumRepository Premiums { get; }
        IQuoteRepository Quotes { get; }
        IQuoteItemRepository QuoteItems { get; }
        IQuoteStatusRepository QuoteStatuses { get; }
        IRatingMotorRepository RatingMotors { get; }
        IRatingMotorDiscountRepository RatingMotorDiscounts { get; }
        IRatingMotorExcessRepository RatingMotorExcesses { get; }
        IRatingMotorPremiumRepository RatingMotorPremiums { get; }
        IReceivableRepository Receivables { get; }
        IReceivableDocumentRepository ReceivableDocuments { get; }
        IReceivableInvoiceRepository ReceivableInvoices { get; }
        IReceivableQuoteRepository ReceivableQuotes { get; }
        IResidenceTypeRepository ResidenceTypes { get; }
        IResidenceUseRepository ResidenceUses { get; }
        IRiskRepository Risks { get; }
        IRiskItemRepository RiskItems { get; }
        IRoofTypeRepository RoofTypes { get; }
        ISalesTypeRepository SalesTypes { get; }
        ITitleRepository Titles { get; }
        IUserPortfolioRepository UserPortfolios { get; }
        ITaxRepository Taxes { get; }
        ITravelRepository Travels { get; }
        ITravelBeneficiaryRepository TravelBeneficiaries { get; }
        IWallTypeRepository WallTypes { get; }

        //Task<int> SaveAsync();
        Task<int> SaveAsync();
        //int SaveAsync();
    }
}
