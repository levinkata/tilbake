using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Infrastructure.Persistence.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TilbakeDbContext _context;

        public UnitOfWork(TilbakeDbContext context)
        {
            _context = context;

            AllRisks = new AllRiskRepository(_context);
            Audits = new AuditRepository(_context);
            Banks = new BankRepository(_context);
            BankBranches = new BankBranchRepository(_context);
            BodyTypes = new BodyTypeRepository(_context);
            Clients = new ClientRepository(_context);
            ClientCarriers = new ClientCarrierRepository(_context);
            ClientDocuments = new ClientDocumentRepository(_context);
            ClientRisks = new ClientRiskRepository(_context);
            ClientTypes = new ClientTypeRepository(_context);
            Carriers = new CarrierRepository(_context);
            Cities = new CityRepository(_context);
            Contents = new ContentRepository(_context);
            Countries = new CountryRepository(_context);
            CoverTypes = new CoverTypeRepository(_context);
            DocumentTypes = new DocumentTypeRepository(_context);
            DriverTypes = new DriverTypeRepository(_context);
            FileTemplates = new FileTemplateRepository(_context);
            FileTemplateRecords = new FileTemplateRecordRepository(_context);
            Genders = new GenderRepository(_context);
            Houses = new HouseRepository(_context);
            HouseConditions = new HouseConditionRepository(_context);
            Insurers = new InsurerRepository(_context);
            Invoices = new InvoiceRepository(_context);
            InvoiceItems = new InvoiceItemRepository(_context);
            InvoiceStatuses = new InvoiceStatusRepository(_context);
            MaritalStatuses = new MaritalStatusRepository(_context);
            Motors = new MotorRepository(_context);
            MotorMakes = new MotorMakeRepository(_context);
            MotorModels = new MotorModelRepository(_context);
            MotorUses = new MotorUseRepository(_context);
            Occupations = new OccupationRepository(_context);
            PaymentMethods = new PaymentMethodRepository(_context);
            Policies = new PolicyRepository(_context);
            PolicyRisks = new PolicyRiskRepository(_context);
            PolicyStatuses = new PolicyStatusRepository(_context);
            PolicyTypes = new PolicyTypeRepository(_context);
            Portfolios = new PortfolioRepository(_context);
            PortfolioClients = new PortfolioClientRepository(_context);
            ResidenceTypes = new ResidenceTypeRepository(_context);
            ResidenceUses = new ResidenceUseRepository(_context);
            Quotes = new QuoteRepository(_context);
            QuoteItems = new QuoteItemRepository(_context);
            QuoteStatuses = new QuoteStatusRepository(_context);
            Risks = new RiskRepository(_context);
            RiskItems = new RiskItemRepository(_context);
            RoofTypes = new RoofTypeRepository(_context);
            SalesTypes = new SalesTypeRepository(_context);
            Titles = new TitleRepository(_context);
            Taxes = new TaxRepository(_context);
            UserPortfolios = new UserPortfolioRepository(_context);
            WallTypes = new WallTypeRepository(_context);

        }

        public IAllRiskRepository AllRisks { get; private set; }
        public IAuditRepository Audits { get; private set; }
        public IBankRepository Banks { get; private set; }
        public IBankBranchRepository BankBranches { get; private set; }
        public IBodyTypeRepository BodyTypes { get; private set; }
        public ICarrierRepository Carriers { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IClientRiskRepository ClientRisks { get; private set; }
        public IClientDocumentRepository ClientDocuments { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IClientCarrierRepository ClientCarriers { get; private set; }
        public IClientTypeRepository ClientTypes { get; private set; }
        public IContentRepository Contents { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public ICoverTypeRepository CoverTypes { get; private set; }
        public IDocumentTypeRepository DocumentTypes { get; private set; }
        public IDriverTypeRepository DriverTypes { get; private set; }
        public IFileTemplateRepository FileTemplates { get; private set; }
        public IFileTemplateRecordRepository FileTemplateRecords { get; private set; }
        public IGenderRepository Genders { get; private set; }
        public IHouseRepository Houses { get; private set; }
        public IHouseConditionRepository HouseConditions { get; private set; }
        public IInsurerRepository Insurers { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IInvoiceItemRepository InvoiceItems { get; private set; }
        public IInvoiceStatusRepository InvoiceStatuses { get; private set; }
        public IMaritalStatusRepository MaritalStatuses { get; private set; }
        public IMotorRepository Motors { get; private set; }
        public IMotorMakeRepository MotorMakes { get; private set; }
        public IMotorModelRepository MotorModels { get; private set; }
        public IMotorUseRepository MotorUses { get; private set; }
        public IOccupationRepository Occupations { get; private set; }
        public IPaymentMethodRepository PaymentMethods { get; private set; }
        public IPolicyRepository Policies { get; private set; }
        public IPolicyRiskRepository PolicyRisks { get; private set; }
        public IPolicyStatusRepository PolicyStatuses { get; private set; }
        public IPolicyTypeRepository PolicyTypes { get; private set; }
        public IPortfolioRepository Portfolios { get; private set; }
        public IPortfolioClientRepository PortfolioClients { get; private set; }
        public IQuoteRepository Quotes { get; private set; }
        public IQuoteItemRepository QuoteItems { get; private set; }
        public IQuoteStatusRepository QuoteStatuses { get; private set; }
        public IRiskRepository Risks { get; private set; }
        public IRiskItemRepository RiskItems { get; private set; }
        public IResidenceTypeRepository ResidenceTypes { get; private set; }
        public IResidenceUseRepository ResidenceUses { get; private set; }
        public IRoofTypeRepository RoofTypes { get; private set; }
        public ISalesTypeRepository SalesTypes { get; private set; }
        public ITaxRepository Taxes { get; private set; }
        public ITitleRepository Titles { get; private set; }
        public IUserPortfolioRepository UserPortfolios { get; private set; }
        public IWallTypeRepository WallTypes { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            // _context.Dispose();
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
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
    }
}
