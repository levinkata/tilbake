﻿using System;
using System.Threading.Tasks;
using Tilbake.Core.Interfaces;

namespace Tilbake.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository Addresses { get; }
        IAllRiskRepository AllRisks { get; }
        IAllRiskSpecifiedRepository AllRiskSpecifieds { get; }
        IApplicationSessionRepository ApplicationSessions { get; }
        IAuditRepository Audits { get; }
        IBankRepository Banks { get; }
        IBankBranchRepository BankBranches { get; }
        IBodyTypeRepository BodyTypes { get; }
        IBuildingRepository Buildings { get; }
        IBuildingConditionRepository BuildingConditions { get; }
        ICarrierRepository Carriers { get; }
        ICityRepository Cities { get; }
        IClaimantRepository Claimants { get; }
        IClaimStatusRepository ClaimStatuses { get; }
        ICustomerRepository Customers { get; }
        ICustomerBulkRepository CustomerBulks { get; }
        IDocumentRepository Documents { get; }
        ICustomerCarrierRepository CustomerCarriers { get; }
        ICustomerRiskRepository CustomerRisks { get; }
        ICustomerTypeRepository CustomerTypes{ get; }
        ICustomerStatusRepository CustomerStatuses { get; }
        ICommissionRateRepository CommissionRates { get; }
        ICompanyRepository Companies { get; }
        IContentRepository Contents { get; }
        ICountryRepository Countries { get; }
        ICoverTypeRepository CoverTypes { get; }
        IDocumentTypeRepository DocumentTypes { get; }
        IDriverRepository Drivers { get; }
        IDriverTypeRepository DriverTypes { get; }
        IEmailAddressRepository EmailAddresses { get; }
        IExcessBuyBackRepository ExcessBuyBacks { get; }
        IFileTemplateRepository FileTemplates { get; }
        IFileTemplateRecordRepository FileTemplateRecords { get; }
        IGenderRepository Genders { get; }
        IHouseRepository Houses { get; }
        IHouseConditionRepository HouseConditions { get; }
        IIdDocumentTypeRepository IdDocumentTypes { get; }
        IIncidentRepository Incidents { get; }
        IInsurerRepository Insurers { get; }
        IInsurerBranchRepository InsurerBranches { get; }        
        IInvoiceRepository Invoices { get; }
        IInvoiceItemRepository InvoiceItems { get; }
        IInvoiceStatusRepository InvoiceStatuses { get; }
        IMaritalStatusRepository MaritalStatuses { get; }
        IMobileNumberRepository MobileNumbers { get; }
        IMotorRepository Motors { get; }
        IMotorCycleTypeRepository MotorCycleTypes { get; }
        IMotorMakeRepository MotorMakes { get; }
        IMotorModelRepository MotorModels { get; }
        IOccupationRepository Occupations { get; }
        IPayeeTypeRepository PayeeTypes { get; }
        IPaymentMethodRepository PaymentMethods { get; }
        IPaymentTypeRepository PaymentTypes { get; }
        IPolicyRepository Policies { get; }
        IPolicyRiskRepository PolicyRisks { get; }
        IPolicyStatusRepository PolicyStatuses { get; }
        IPolicyTypeRepository PolicyTypes { get; }
        IPortfolioRepository Portfolios { get; }
        IPortfolioAdministrationFeeRepository PortfolioAdministrationFees { get; }
        IPortfolioCustomerRepository PortfolioCustomers { get; }
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
        IRelationTypeRepository RelationTypes { get; }
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
        Task<int> SaveAsync();
        Task CompleteAsync();
    }
}
