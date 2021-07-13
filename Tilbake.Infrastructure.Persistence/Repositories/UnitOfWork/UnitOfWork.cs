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

            Banks = new BankRepository(_context);
            BankBranches = new BankBranchRepository(_context);
            BodyTypes = new BodyTypeRepository(_context);
            Clients = new ClientRepository(_context);
            ClientRisks = new ClientRiskRepository(_context);
            ClientTypes = new ClientTypeRepository(_context);
            Carriers = new CarrierRepository(_context);
            Cities = new CityRepository(_context);
            Countries = new CountryRepository(_context);
            CoverTypes = new CoverTypeRepository(_context);
            DocumentTypes = new DocumentTypeRepository(_context);
            DriverTypes = new DriverTypeRepository(_context);
            Genders = new GenderRepository(_context);
            Insurers = new InsurerRepository(_context);
            Invoices = new InvoiceRepository(_context);
            InvoiceStatuses = new InvoiceStatusRepository(_context);
            MaritalStatuses = new MaritalStatusRepository(_context);
            Motors = new MotorRepository(_context);
            MotorMakes = new MotorMakeRepository(_context);
            MotorModels = new MotorModelRepository(_context);
            MotorUses = new MotorUseRepository(_context);
            Occupations = new OccupationRepository(_context);
            PolicyStatuses = new PolicyStatusRepository(_context);
            PolicyTypes = new PolicyTypeRepository(_context);
            Portfolios = new PortfolioRepository(_context);
            PortfolioClients = new PortfolioClientRepository(_context);
            QuoteStatuses = new QuoteStatusRepository(_context);
            Quotes = new QuoteRepository(_context);
            Risks = new RiskRepository(_context);
            SalesTypes = new SalesTypeRepository(_context);
            Titles = new TitleRepository(_context);
            UserPortfolios = new UserPortfolioRepository(_context);
        }

        public IBankRepository Banks { get; private set; }
        public IBankBranchRepository BankBranches { get; private set; }
        public IBodyTypeRepository BodyTypes { get; private set; }
        public ICarrierRepository Carriers { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IClientRiskRepository ClientRisks { get; private set; }
        public IClientRepository Clients { get; private set; }
        public IClientTypeRepository ClientTypes { get; private set; }
        public ICountryRepository Countries { get; private set; }
        public ICoverTypeRepository CoverTypes { get; private set; }
        public IDocumentTypeRepository DocumentTypes { get; private set; }
        public IDriverTypeRepository DriverTypes { get; private set; }
        public IGenderRepository Genders { get; private set; }
        public IInsurerRepository Insurers { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IInvoiceStatusRepository InvoiceStatuses { get; private set; }
        public IMaritalStatusRepository MaritalStatuses { get; private set; }
        public IMotorRepository Motors { get; private set; }
        public IMotorMakeRepository MotorMakes { get; private set; }
        public IMotorModelRepository MotorModels { get; private set; }
        public IMotorUseRepository MotorUses { get; private set; }
        public IOccupationRepository Occupations { get; private set; }
        public IPolicyStatusRepository PolicyStatuses { get; private set; }
        public IPolicyTypeRepository PolicyTypes { get; private set; }
        public IPortfolioRepository Portfolios { get; private set; }
        public IPortfolioClientRepository PortfolioClients { get; private set; }
        public IQuoteStatusRepository QuoteStatuses { get; private set; }
        public IQuoteRepository Quotes { get; private set; }
        public IRiskRepository Risks { get; private set; }
        public ISalesTypeRepository SalesTypes { get; private set; }
        public ITitleRepository Titles { get; private set; }
        public IUserPortfolioRepository UserPortfolios { get; private set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
