using System;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Interfaces;
using Tilbake.EF.Persistence.Context;
using Tilbake.EF.Persistence.Repositories;

namespace Tilbake.EF.Persistence
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TilbakeDbContext _context;
        private bool disposed = false;

        public UnitOfWork(TilbakeDbContext context)
        {
            _context = context;

            Addresses = new AddressRepository(_context);
            AllRisks = new AllRiskRepository(_context);
            AllRiskSpecifieds = new AllRiskSpecifiedRepository(_context);
            Audits = new AuditRepository(_context);
            Banks = new BankRepository(_context);
            BankBranches = new BankBranchRepository(_context);
            BodyTypes = new BodyTypeRepository(_context);
            Buildings = new BuildingRepository(_context);
            BuildingConditions = new BuildingConditionRepository(_context);
            Carriers = new CarrierRepository(_context);
            Cities = new CityRepository(_context);
            Claimants = new ClaimantRepository(_context);
            ClaimStatuses = new ClaimStatusRepository(_context);
            Clients = new ClientRepository(_context);
            ClientBulks = new ClientBulkRepository(_context);
            ClientCarriers = new ClientCarrierRepository(_context);
            ClientDocuments = new ClientDocumentRepository(_context);
            ClientRisks = new ClientRiskRepository(_context);
            ClientStatuses = new ClientStatusRepository(_context);
            ClientTypes = new ClientTypeRepository(_context);
            CommissionRates = new CommissionRateRepository(_context);
            Contents = new ContentRepository(_context);
            Countries = new CountryRepository(_context);
            CoverTypes = new CoverTypeRepository(_context);
            DocumentTypes = new DocumentTypeRepository(_context);
            DriverTypes = new DriverTypeRepository(_context);
            EmailAddresses = new EmailAddressRepository(_context);
            ExcessBuyBacks = new ExcessBuyBackRepository(_context);
            FileTemplates = new FileTemplateRepository(_context);
            FileTemplateRecords = new FileTemplateRecordRepository(_context);
            Genders = new GenderRepository(_context);
            Houses = new HouseRepository(_context);
            HouseConditions = new HouseConditionRepository(_context);
            IdDocumentTypes = new IdDocumentTypeRepository(_context);
            Incidents = new IncidentRepository(_context);
            Insurers = new InsurerRepository(_context);
            InsurerBranches = new InsurerBranchRepository(_context);
            Invoices = new InvoiceRepository(_context);
            InvoiceItems = new InvoiceItemRepository(_context);
            InvoiceStatuses = new InvoiceStatusRepository(_context);
            MaritalStatuses = new MaritalStatusRepository(_context);
            MobileNumbers = new MobileNumberRepository(_context);
            Motors = new MotorRepository(_context);
            MotorCycleTypes = new MotorCycleTypeRepository(_context);
            MotorMakes = new MotorMakeRepository(_context);
            MotorModels = new MotorModelRepository(_context);
            Occupations = new OccupationRepository(_context);
            PayeeTypes = new PayeeTypeRepository(_context);
            PaymentMethods = new PaymentMethodRepository(_context);
            PaymentTypes = new PaymentTypeRepository(_context);
            Policies = new PolicyRepository(_context);
            PolicyRisks = new PolicyRiskRepository(_context);
            PolicyStatuses = new PolicyStatusRepository(_context);
            PolicyTypes = new PolicyTypeRepository(_context);
            Portfolios = new PortfolioRepository(_context);
            PortfolioAdministrationFees = new PortfolioAdministrationFeeRepository(_context);
            PortfolioClients = new PortfolioClientRepository(_context);
            PortfolioExcessBuyBacks = new PortfolioExcessBuyBackRepository(_context);
            PortfolioPolicyFees = new PortfolioPolicyFeeRepository(_context);
            Premiums = new PremiumRepository(_context);
            Quotes = new QuoteRepository(_context);
            QuoteItems = new QuoteItemRepository(_context);
            QuoteStatuses = new QuoteStatusRepository(_context);
            RatingMotors = new RatingMotorRepository(_context);
            RatingMotorDiscounts = new RatingMotorDiscountRepository(_context);
            RatingMotorExcesses = new RatingMotorExcessRepository(_context);
            RatingMotorPremiums = new RatingMotorPremiumRepository(_context);
            Receivables = new ReceivableRepository(_context);
            ReceivableDocuments = new ReceivableDocumentRepository(_context);
            ReceivableInvoices = new ReceivableInvoiceRepository(_context);
            ReceivableQuotes = new ReceivableQuoteRepository(_context);
            RelationTypes = new RelationTypeRepository(_context);
            ResidenceTypes = new ResidenceTypeRepository(_context);
            ResidenceUses = new ResidenceUseRepository(_context);
            Risks = new RiskRepository(_context);
            RiskItems = new RiskItemRepository(_context);
            RoofTypes = new RoofTypeRepository(_context);
            SalesTypes = new SalesTypeRepository(_context);
            Titles = new TitleRepository(_context);
            Taxes = new TaxRepository(_context);
            Travels = new TravelRepository(_context);
            TravelBeneficiaries = new TravelBeneficiaryRepository(_context);
            UserPortfolios = new UserPortfolioRepository(_context);
            WallTypes = new WallTypeRepository(_context);
        }

        public IAddressRepository Addresses { get; private set; }
        public IAllRiskRepository AllRisks { get; private set; }
        public IAllRiskSpecifiedRepository AllRiskSpecifieds { get; private set; }
        public IAuditRepository Audits { get; private set; }
        public IBankRepository Banks { get; private set; }
        public IBankBranchRepository BankBranches { get; private set; }
        public IBodyTypeRepository BodyTypes { get; private set; }
        public IBuildingRepository Buildings { get; private set; }
        public IBuildingConditionRepository BuildingConditions { get; private set; }
        public ICarrierRepository Carriers { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IClaimantRepository Claimants { get; private set; }
        public IClaimStatusRepository ClaimStatuses { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IClientBulkRepository ClientBulks { get; private set; }
        public IClientCarrierRepository ClientCarriers { get; private set; }
        public IClientDocumentRepository ClientDocuments { get; private set; }
        public IClientRiskRepository ClientRisks { get; private set; }
        public IClientStatusRepository ClientStatuses { get; private set; }
        public IClientTypeRepository ClientTypes { get; private set; }
        public ICommissionRateRepository CommissionRates { get; private set; }
        public IContentRepository Contents { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public ICoverTypeRepository CoverTypes { get; private set; }
        public IDocumentTypeRepository DocumentTypes { get; private set; }
        public IDriverTypeRepository DriverTypes { get; private set; }
        public IEmailAddressRepository EmailAddresses { get; private set; }
        public IExcessBuyBackRepository ExcessBuyBacks { get; private set; }
        public IFileTemplateRepository FileTemplates { get; private set; }
        public IFileTemplateRecordRepository FileTemplateRecords { get; private set; }
        public IGenderRepository Genders { get; private set; }
        public IHouseRepository Houses { get; private set; }
        public IHouseConditionRepository HouseConditions { get; private set; }
        public IIdDocumentTypeRepository IdDocumentTypes { get; private set; }
        public IIncidentRepository Incidents { get; private set; }
        public IInsurerRepository Insurers { get; private set; }
        public IInsurerBranchRepository InsurerBranches { get; private set; }        
        public IInvoiceRepository Invoices { get; private set; }
        public IInvoiceItemRepository InvoiceItems { get; private set; }
        public IInvoiceStatusRepository InvoiceStatuses { get; private set; }
        public IMaritalStatusRepository MaritalStatuses { get; private set; }
        public IMobileNumberRepository MobileNumbers { get; private set; }
        public IMotorRepository Motors { get; private set; }
        public IMotorCycleTypeRepository MotorCycleTypes { get; private set; }
        public IMotorMakeRepository MotorMakes { get; private set; }
        public IMotorModelRepository MotorModels { get; private set; }
        public IOccupationRepository Occupations { get; private set; }
        public IPayeeTypeRepository PayeeTypes { get; private set; }
        public IPaymentMethodRepository PaymentMethods { get; private set; }
        public IPaymentTypeRepository PaymentTypes { get; private set; }
        public IPolicyRepository Policies { get; private set; }
        public IPolicyRiskRepository PolicyRisks { get; private set; }
        public IPolicyStatusRepository PolicyStatuses { get; private set; }
        public IPolicyTypeRepository PolicyTypes { get; private set; }
        public IPortfolioRepository Portfolios { get; private set; }
        public IPortfolioAdministrationFeeRepository PortfolioAdministrationFees { get; private set; }
        public IPortfolioClientRepository PortfolioClients { get; private set; }
        public IPortfolioExcessBuyBackRepository PortfolioExcessBuyBacks { get; private set; }
        public IPortfolioPolicyFeeRepository PortfolioPolicyFees { get; private set; }
        public IPremiumRepository Premiums { get; private set; }
        public IQuoteRepository Quotes { get; private set; }
        public IQuoteItemRepository QuoteItems { get; private set; }
        public IQuoteStatusRepository QuoteStatuses { get; private set; }
        public IRatingMotorRepository RatingMotors { get; private set; }
        public IRatingMotorDiscountRepository RatingMotorDiscounts { get; private set; }
        public IRatingMotorExcessRepository RatingMotorExcesses { get; private set; }
        public IRatingMotorPremiumRepository RatingMotorPremiums { get; private set; }
        public IRiskRepository Risks { get; private set; }
        public IRiskItemRepository RiskItems { get; private set; }
        public IReceivableRepository Receivables { get; private set; }
        public IReceivableDocumentRepository ReceivableDocuments { get; private set; }
        public IReceivableInvoiceRepository ReceivableInvoices { get; private set; }
        public IReceivableQuoteRepository ReceivableQuotes { get; private set; }
        public IRelationTypeRepository RelationTypes { get; private set; }
        public IResidenceTypeRepository ResidenceTypes { get; private set; }
        public IResidenceUseRepository ResidenceUses { get; private set; }
        public IRoofTypeRepository RoofTypes { get; private set; }
        public ISalesTypeRepository SalesTypes { get; private set; }
        public ITaxRepository Taxes { get; private set; }
        public ITitleRepository Titles { get; private set; }
        public ITravelRepository Travels { get; private set; }
        public ITravelBeneficiaryRepository TravelBeneficiaries { get; private set; }
        public IUserPortfolioRepository UserPortfolios { get; private set; }
        public IWallTypeRepository WallTypes { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
