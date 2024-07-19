using AutoMapper;
using Tilbake.Core.Models;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Address, AddressViewModel>()
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City)).ReverseMap();

            CreateMap<AllRisk, AllRiskViewModel>()
                    .ForMember(dest => dest.RiskItem, opt => opt.MapFrom(src => src.RiskItem.Description)).ReverseMap();

            CreateMap<AllRiskSpecified, AllRiskSpecifiedViewModel>()
                    .ForMember(dest => dest.RiskItem, opt => opt.MapFrom(src => src.RiskItem.Description)).ReverseMap();

            CreateMap<AspnetUserPortfolio, AspnetUserPortfolioViewModel>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name)).ReverseMap();

            CreateMap<Audit, AuditViewModel>().ReverseMap();

            CreateMap<Bank, BankViewModel>()
            .ForMember(dest => dest.BankBranches, opt => opt.MapFrom(src => src.BankBranches)).ReverseMap();

            CreateMap<BankBranch, BankBranchViewModel>()
                    .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank)).ReverseMap();

            CreateMap<BodyType, BodyTypeViewModel>().ReverseMap();

            CreateMap<Building, BuildingViewModel>()
                    .ForMember(dest => dest.BuildingCondition, opt => opt.MapFrom(src => src.BuildingCondition.Name))
                    .ForMember(dest => dest.ResidenceUse, opt => opt.MapFrom(src => src.ResidenceUse.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<BuildingCondition, BuildingConditionViewModel>().ReverseMap();
            CreateMap<Carrier, CarrierViewModel>().ReverseMap();
            CreateMap<City, CityViewModel>().ReverseMap();

            CreateMap<Customer, CustomerViewModel>()
                    .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.Addresses))
                    .ForMember(dest => dest.CustomerType, opt => opt.MapFrom(src => src.CustomerType))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                    .ForMember(dest => dest.IdDocumentType, opt => opt.MapFrom(src => src.IdDocumentType))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.EmailAddresses, opt => opt.MapFrom(src => src.EmailAddresses))
                    .ForMember(dest => dest.MobileNumbers, opt => opt.MapFrom(src => src.MobileNumbers))
                    .ForMember(dest => dest.CustomerCarriers, opt => opt.MapFrom(src => src.CustomerCarriers)).ReverseMap();

            CreateMap<CustomerBulk, CustomerBulkViewModel>().ReverseMap();

            CreateMap<CustomerCarrier, CustomerCarrierViewModel>()
                    .ForMember(dest => dest.Carrier, opt => opt.MapFrom(src => src.Carrier)).ReverseMap();

            CreateMap<Document, DocumentViewModel>()
                    //.ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                    .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType)).ReverseMap();

            CreateMap<CustomerRisk, CustomerRiskViewModel>().ReverseMap();
            CreateMap<CustomerType, CustomerTypeViewModel>().ReverseMap();
            CreateMap<CustomerStatus, CustomerStatusViewModel>().ReverseMap();
            CreateMap<CommissionRate, CommissionRateViewModel>().ReverseMap();

            CreateMap<Company, CompanyViewModel>()
                    .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City)).ReverseMap();

            CreateMap<Content, ContentViewModel>()
                    .ForMember(dest => dest.BuildingCondition, opt => opt.MapFrom(src => src.BuildingCondition))
                    .ForMember(dest => dest.ResidenceUse, opt => opt.MapFrom(src => src.ResidenceUse))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType)).ReverseMap();

            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<CoverType, CoverTypeViewModel>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeViewModel>().ReverseMap();
            CreateMap<Driver, DriverViewModel>()
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation)).ReverseMap();

            CreateMap<DriverType, DriverTypeViewModel>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressViewModel>().ReverseMap();

            CreateMap<ExcessBuyBack, ExcessBuyBackViewModel>()
                    .ForMember(dest => dest.Motor, opt => opt.MapFrom(src => src.Motor)).ReverseMap();

            CreateMap<Gender, GenderViewModel>().ReverseMap();

            CreateMap<FileTemplate, FileTemplateViewModel>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name))
                    .ForMember(dest => dest.FileTemplateRecords, opt => opt.MapFrom(src => src.FileTemplateRecords)).ReverseMap();

            CreateMap<FileTemplateRecord, FileTemplateRecordViewModel>()
                    .ForMember(dest => dest.FileTemplateName, opt => opt.MapFrom(src => src.FileTemplate.Name)).ReverseMap();

            CreateMap<House, HouseViewModel>()
                    .ForMember(dest => dest.HouseCondition, opt => opt.MapFrom(src => src.HouseCondition.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<HouseCondition, HouseConditionViewModel>().ReverseMap();
            CreateMap<IdDocumentType, IdDocumentTypeViewModel>().ReverseMap();

            CreateMap<Insurer, InsurerViewModel>()
                .ForMember(dest => dest.InsurerBranches, opt => opt.MapFrom(src => src.InsurerBranches)).ReverseMap();

            CreateMap<InsurerBranch, InsurerBranchViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name)).ReverseMap();

            CreateMap<Invoice, InvoiceViewModel>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Policy.PortfolioCustomer.Customer.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Policy.PortfolioCustomer.Customer.LastName))
                .ForMember(dest => dest.InvoiceStatus, opt => opt.MapFrom(src => src.InvoiceStatus))
                .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(src => src.InvoiceItems)).ReverseMap();

            CreateMap<InvoiceItem, InvoiceItemViewModel>()
                .ForMember(dest => dest.PolicyRisk, opt => opt.MapFrom(src => src.PolicyRisk)).ReverseMap();

            CreateMap<InvoiceStatus, InvoiceStatusViewModel>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusViewModel>().ReverseMap();
            CreateMap<MobileNumber, MobileNumberViewModel>().ReverseMap();

            CreateMap<Motor, MotorViewModel>()
                .ForMember(dest => dest.BodyType, opt => opt.MapFrom(src => src.BodyType.Name))
                .ForMember(dest => dest.DriverType, opt => opt.MapFrom(src => src.DriverType.Name))
                .ForMember(dest => dest.MotorMake, opt => opt.MapFrom(src => src.MotorModel.MotorMake.Name))
                .ForMember(dest => dest.MotorModel, opt => opt.MapFrom(src => src.MotorModel.Name))
                .ReverseMap();

            CreateMap<MotorMake, MotorMakeViewModel>().ReverseMap();
            CreateMap<MotorModel, MotorModelViewModel>().ReverseMap();
            CreateMap<Occupation, OccupationViewModel>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodViewModel>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeViewModel>().ReverseMap();

            CreateMap<Policy, PolicyViewModel>()
                .ForMember(dest => dest.BankAccount, opt => opt.MapFrom(src => src.CustomerBankAccount.BankAccount.AccountNumber))
                .ForMember(dest => dest.InsurerName, opt => opt.MapFrom(src => src.InsurerBranch.Insurer.Name))
                .ForMember(dest => dest.InsurerBranch, opt => opt.MapFrom(src => src.InsurerBranch))
                .ForMember(dest => dest.PortfolioCustomer, opt => opt.MapFrom(src => src.PortfolioCustomer))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PolicyStatus, opt => opt.MapFrom(src => src.PolicyStatus))
                .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType))
                .ForMember(dest => dest.SalesType, opt => opt.MapFrom(src => src.SalesType)).ReverseMap();

            CreateMap<PolicyRisk, PolicyRiskViewModel>()
                .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType)).ReverseMap();

            CreateMap<PolicyStatus, PolicyStatusViewModel>().ReverseMap();
            CreateMap<PolicyType, PolicyTypeViewModel>().ReverseMap();

            CreateMap<Portfolio, PortfolioViewModel>()
                    .ForMember(dest => dest.TotalCustomers, opt => opt.MapFrom(src => src.PortfolioCustomers.Count)).ReverseMap();

            CreateMap<PortfolioAdministrationFee, PortfolioAdministrationFeeViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<PortfolioCustomer, PortfolioCustomerViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.CustomerStatus, opt => opt.MapFrom(src => src.CustomerStatus))
                .ForMember(dest => dest.Portfolio, opt => opt.MapFrom(src => src.Portfolio)).ReverseMap();

            CreateMap<PortfolioExcessBuyBack, PortfolioExcessBuyBackViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<PortfolioPolicyFee, PortfolioPolicyFeeViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<Premium, PremiumViewModel>().ReverseMap();

            CreateMap<Quote, QuoteViewModel>()
                .ForMember(dest => dest.PortfolioCustomer, opt => opt.MapFrom(src => src.PortfolioCustomer))
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.PortfolioCustomer.Customer))
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.InsurerBranch.Insurer))
                .ForMember(dest => dest.InsurerBranch, opt => opt.MapFrom(src => src.InsurerBranch))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType))
                .ForMember(dest => dest.QuoteStatus, opt => opt.MapFrom(src => src.QuoteStatus))
                .ForMember(dest => dest.QuoteItems, opt => opt.MapFrom(src => src.QuoteItems)).ReverseMap();

            CreateMap<QuoteItem, QuoteItemViewModel>()
                .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType))
                .ForMember(dest => dest.Quote, opt => opt.MapFrom(src => src.Quote)).ReverseMap();

            CreateMap<QuoteStatus, QuoteStatusViewModel>().ReverseMap();

            CreateMap<RatingMotor, RatingMotorViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorDiscount, RatingMotorDiscountViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorExcess, RatingMotorExcessViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorPremium, RatingMotorPremiumViewModel>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<Receivable, ReceivableViewModel>()
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.Name))
                .ForMember(dest => dest.ReceivableInvoices, opt => opt.MapFrom(src => src.ReceivableInvoices))
                .ForMember(dest => dest.ReceivableDocuments, opt => opt.MapFrom(src => src.ReceivableDocuments)).ReverseMap();

            //CreateMap<ReceivableDocument, ReceivableDocumentViewModel>()
            //    .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.Name)).ReverseMap();

            CreateMap<ResidenceType, ResidenceTypeViewModel>().ReverseMap();
            CreateMap<ResidenceUse, ResidenceUseViewModel>().ReverseMap();
            CreateMap<Risk, RiskViewModel>().ReverseMap();
            CreateMap<RiskItem, RiskItemViewModel>().ReverseMap();
            CreateMap<RoofType, RoofTypeViewModel>().ReverseMap();
            CreateMap<SalesType, SalesTypeViewModel>().ReverseMap();
            CreateMap<Tax, TaxViewModel>().ReverseMap();
            CreateMap<Title, TitleViewModel>().ReverseMap();

            CreateMap<Travel, TravelViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.PortfolioCustomer.Customer))
                .ForMember(dest => dest.PortfolioCustomer, opt => opt.MapFrom(src => src.PortfolioCustomer)).ReverseMap();

            CreateMap<TravelBeneficiary, TravelBeneficiaryViewModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Travel, opt => opt.MapFrom(src => src.Travel)).ReverseMap();

            CreateMap<WallType, WallTypeViewModel>().ReverseMap();
        }
    }
}
