using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Address, AddressResource>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City)).ReverseMap();

            CreateMap<AllRisk, AllRiskResource>()
                    .ForMember(dest => dest.RiskItem, opt => opt.MapFrom(src => src.RiskItem.Description)).ReverseMap();

            CreateMap<AspnetUserPortfolio, AspnetUserPortfolioResource>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name)).ReverseMap();

            CreateMap<Audit, AuditResource>().ReverseMap();
            CreateMap<Bank, BankResource>().ReverseMap();

            CreateMap<BankBranch, BankBranchResource>()
                    .ForMember(dest => dest.Bank, opt => opt.MapFrom(src => src.Bank)).ReverseMap();

            CreateMap<BodyType, BodyTypeResource>().ReverseMap();

            CreateMap<Building, BuildingResource>()
                    .ForMember(dest => dest.BuildingCondition, opt => opt.MapFrom(src => src.BuildingCondition.Name))
                    .ForMember(dest => dest.ResidenceUse, opt => opt.MapFrom(src => src.ResidenceUse.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<BuildingCondition, BuildingConditionResource>().ReverseMap();
            CreateMap<Carrier, CarrierResource>().ReverseMap();
            CreateMap<City, CityResource>().ReverseMap();

            CreateMap<Client, ClientResource>()
                    .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => src.ClientType.Name)) 
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                    .ForMember(dest => dest.IdDocumentType, opt => opt.MapFrom(src => src.IdDocumentType.Name))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Name))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name))
                    .ForMember(dest => dest.EmailAddresses, opt => opt.MapFrom(src => src.EmailAddresses))
                    .ForMember(dest => dest.MobileNumbers, opt => opt.MapFrom(src => src.MobileNumbers))
                    .ForMember(dest => dest.ClientCarriers, opt => opt.MapFrom(src => src.ClientCarriers)).ReverseMap();

            CreateMap<ClientBulk, ClientBulkResource>().ReverseMap();

            CreateMap<ClientCarrier, ClientCarrierResource>()
                    .ForMember(dest => dest.Carrier, opt => opt.MapFrom(src => src.Carrier)).ReverseMap();

            CreateMap<ClientDocument, ClientDocumentResource>()
                    .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                    .ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType.Name)).ReverseMap();

            CreateMap<ClientRisk, ClientRiskResource>().ReverseMap();
            CreateMap<ClientType, ClientTypeResource>().ReverseMap();
            CreateMap<CommissionRate, CommissionRateResource>().ReverseMap();

            CreateMap<Content, ContentResource>()
                    .ForMember(dest => dest.BuildingCondition, opt => opt.MapFrom(src => src.BuildingCondition.Name))
                    .ForMember(dest => dest.ResidenceUse, opt => opt.MapFrom(src => src.ResidenceUse.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<CoverType, CoverTypeResource>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeResource>().ReverseMap();
            CreateMap<DriverType, DriverTypeResource>().ReverseMap();
            CreateMap<EmailAddress, EmailAddressResource>().ReverseMap();
            CreateMap<Gender, GenderResource>().ReverseMap();

            CreateMap<FileTemplate, FileTemplateResource>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name))
                    .ForMember(dest => dest.FileTemplateRecords, opt => opt.MapFrom(src => src.FileTemplateRecords)).ReverseMap();

            CreateMap<FileTemplateRecord, FileTemplateRecordResource>()
                    .ForMember(dest => dest.FileTemplateName, opt => opt.MapFrom(src => src.FileTemplate.Name)).ReverseMap();

            CreateMap<House, HouseResource>()
                    .ForMember(dest => dest.HouseCondition, opt => opt.MapFrom(src => src.HouseCondition.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<HouseCondition, HouseConditionResource>().ReverseMap();
            CreateMap<IdDocumentType, IdDocumentTypeResource>().ReverseMap();

            CreateMap<Insurer, InsurerResource>()
                .ForMember(dest => dest.InsurerBranches, opt => opt.MapFrom(src => src.InsurerBranches)).ReverseMap();

            CreateMap<InsurerBranch, InsurerBranchResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name)).ReverseMap();            

            CreateMap<Invoice, InvoiceResource>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Policy.PortfolioClient.Client.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Policy.PortfolioClient.Client.LastName))
                .ForMember(dest => dest.InvoiceStatus, opt => opt.MapFrom(src => src.InvoiceStatus.Name))
                .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(src => src.InvoiceItems)).ReverseMap();

            CreateMap<InvoiceItem, InvoiceItemResource>()
                .ForMember(dest => dest.PolicyRisk, opt => opt.MapFrom(src => src.PolicyRisk)).ReverseMap();

            CreateMap<InvoiceStatus, InvoiceStatusResource>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusResource>().ReverseMap();
            CreateMap<MobileNumber, MobileNumberResource>().ReverseMap();

            CreateMap<Motor, MotorResource>()
                .ForMember(dest => dest.BodyType, opt => opt.MapFrom(src => src.BodyType.Name))
                .ForMember(dest => dest.DriverType, opt => opt.MapFrom(src => src.DriverType.Name))
                .ForMember(dest => dest.MotorMake, opt => opt.MapFrom(src => src.MotorModel.MotorMake.Name))
                .ForMember(dest => dest.MotorModel, opt => opt.MapFrom(src => src.MotorModel.Name))
                .ReverseMap();

            CreateMap<MotorMake, MotorMakeResource>().ReverseMap();
            CreateMap<MotorModel, MotorModelResource>().ReverseMap();
            CreateMap<MotorUse, MotorUseResource>().ReverseMap();
            CreateMap<Occupation, OccupationResource>().ReverseMap();
            CreateMap<PaymentMethod, PaymentMethodResource>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeResource>().ReverseMap();

            CreateMap<Policy, PolicyResource>()
                .ForMember(dest => dest.BankAccount, opt => opt.MapFrom(src => src.ClientBankAccount.BankAccount.AccountNumber))
                .ForMember(dest => dest.InsurerName, opt => opt.MapFrom(src => src.InsurerBranch.Insurer.Name))
                .ForMember(dest => dest.InsurerBranch, opt => opt.MapFrom(src => src.InsurerBranch))
                .ForMember(dest => dest.PortfolioClient, opt => opt.MapFrom(src => src.PortfolioClient))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod))
                .ForMember(dest => dest.PolicyStatus, opt => opt.MapFrom(src => src.PolicyStatus))
                .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType))
                .ForMember(dest => dest.SalesType, opt => opt.MapFrom(src => src.SalesType)).ReverseMap();

            CreateMap<PolicyRisk, PolicyRiskResource>()
                .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType.Name)).ReverseMap();

            CreateMap<PolicyStatus, PolicyStatusResource>().ReverseMap();
            CreateMap<PolicyType, PolicyTypeResource>().ReverseMap();

            CreateMap<Portfolio, PortfolioResource>()
                    .ForMember(dest => dest.TotalClients, opt => opt.MapFrom(src => src.PortfolioClients.Count)).ReverseMap();
            
            CreateMap<PortfolioAdministrationFee, PortfolioAdministrationFeeResource>()
                .ForMember(dest => dest.InsurerName, opt => opt.MapFrom(src => src.Insurer.Name)).ReverseMap();

            CreateMap<PortfolioClient, PortfolioClientResource>()
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.Portfolio, opt => opt.MapFrom(src => src.Portfolio)).ReverseMap();

            CreateMap<PortfolioPolicyFee, PortfolioPolicyFeeResource>()
                .ForMember(dest => dest.InsurerName, opt => opt.MapFrom(src => src.Insurer.Name)).ReverseMap();

            CreateMap<Premium, PremiumResource>().ReverseMap();

            CreateMap<Quote, QuoteResource>()
                .ForMember(dest => dest.PortfolioClient, opt => opt.MapFrom(src => src.PortfolioClient))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.PortfolioClient.Client))
                .ForMember(dest => dest.InsurerBranch, opt => opt.MapFrom(src => src.InsurerBranch))
                .ForMember(dest => dest.QuoteStatus, opt => opt.MapFrom(src => src.QuoteStatus))
                .ForMember(dest => dest.QuoteItems, opt => opt.MapFrom(src => src.QuoteItems)).ReverseMap();
            
            CreateMap<QuoteItem, QuoteItemResource>()
                .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType)).ReverseMap();

            CreateMap<QuoteStatus, QuoteStatusResource>().ReverseMap();

            CreateMap<RatingMotor, RatingMotorResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorDiscount, RatingMotorDiscountResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorExcess, RatingMotorExcessResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<RatingMotorPremium, RatingMotorPremiumResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer)).ReverseMap();

            CreateMap<Receivable, ReceivableResource>()
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.PaymentType.Name))
                .ForMember(dest => dest.ReceivableInvoices, opt => opt.MapFrom(src => src.ReceivableInvoices))
                .ForMember(dest => dest.ReceivableDocuments, opt => opt.MapFrom(src => src.ReceivableDocuments)).ReverseMap();

            CreateMap<ReceivableDocument, ReceivableDocumentResource>()
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.Name)).ReverseMap();

            CreateMap<ResidenceType, ResidenceTypeResource>().ReverseMap();
            CreateMap<ResidenceUse, ResidenceUseResource>().ReverseMap();
            CreateMap<Risk, RiskResource>().ReverseMap();
            CreateMap<RiskItem, RiskItemResource>().ReverseMap();
            CreateMap<RoofType, RoofTypeResource>().ReverseMap();
            CreateMap<SalesType, SalesTypeResource>().ReverseMap();
            CreateMap<Tax, TaxResource>().ReverseMap();
            CreateMap<Title, TitleResource>().ReverseMap();
            CreateMap<WallType, WallTypeResource>().ReverseMap();
        }
    }
}
