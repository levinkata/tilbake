using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<AllRisk, AllRiskResource>()
                    .ForMember(dest => dest.RiskItem, opt => opt.MapFrom(src => src.RiskItem.Description)).ReverseMap();

            CreateMap<AspnetUserPortfolio, AspnetUserPortfolioResource>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name)).ReverseMap();

            CreateMap<Audit, AuditResource>().ReverseMap();
            CreateMap<Bank, BankResource>().ReverseMap();
            CreateMap<BankBranch, BankBranchResource>()
                    .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name)).ReverseMap();

            CreateMap<BodyType, BodyTypeResource>().ReverseMap();
            CreateMap<Carrier, CarrierResource>().ReverseMap();
            CreateMap<City, CityResource>().ReverseMap();

            CreateMap<Client, ClientResource>()
                    .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => src.ClientType.Name)) 
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Name))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name))
                    .ForMember(dest => dest.ClientCarriers, opt => opt.MapFrom(src => src.ClientCarriers)).ReverseMap();

            CreateMap<ClientDocument, ClientDocumentResource>()
                    .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.Name)).ReverseMap();

            CreateMap<ClientRisk, ClientRiskResource>().ReverseMap();
            CreateMap<ClientType, ClientTypeResource>().ReverseMap();

            CreateMap<Content, ContentResource>()
                    .ForMember(dest => dest.ResidenceUse, opt => opt.MapFrom(src => src.ResidenceUse.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<CoverType, CoverTypeResource>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeResource>().ReverseMap();
            CreateMap<DriverType, DriverTypeResource>().ReverseMap();
            CreateMap<Gender, GenderResource>().ReverseMap();

            CreateMap<FileTemplate, FileTemplateResource>()
                .ForMember(dest => dest.FileTemplateRecords, opt => opt.MapFrom(src => src.FileTemplateRecords)).ReverseMap();

            CreateMap<FileTemplateRecord, FileTemplateRecordResource>().ReverseMap();

            CreateMap<House, HouseResource>()
                    .ForMember(dest => dest.HouseCondition, opt => opt.MapFrom(src => src.HouseCondition.Name))
                    .ForMember(dest => dest.ResidenceType, opt => opt.MapFrom(src => src.ResidenceType.Name))
                    .ForMember(dest => dest.RoofType, opt => opt.MapFrom(src => src.RoofType.Name))
                    .ForMember(dest => dest.WallType, opt => opt.MapFrom(src => src.WallType.Name)).ReverseMap();

            CreateMap<HouseCondition, HouseConditionResource>().ReverseMap();
            CreateMap<Insurer, InsurerResource>().ReverseMap();

            CreateMap<Invoice, InvoiceResource>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.Policy.PortfolioClient.Client.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Policy.PortfolioClient.Client.LastName))
                .ForMember(dest => dest.InvoiceStatus, opt => opt.MapFrom(src => src.InvoiceStatus.Name))
                .ForMember(dest => dest.Tax, opt => opt.MapFrom(src => src.Tax.Name))
                .ForMember(dest => dest.InvoiceItems, opt => opt.MapFrom(src => src.InvoiceItems)).ReverseMap();

            CreateMap<InvoiceItem, InvoiceItemResource>()
                .ForMember(dest => dest.PolicyRisk, opt => opt.MapFrom(src => src.PolicyRisk)).ReverseMap();

            CreateMap<InvoiceStatus, InvoiceStatusResource>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusResource>().ReverseMap();

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
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer.Name))
                .ForMember(dest => dest.PaymentMethod, opt => opt.MapFrom(src => src.PaymentMethod.Name))
                .ForMember(dest => dest.PolicyStatus, opt => opt.MapFrom(src => src.PolicyStatus.Name))
                .ForMember(dest => dest.PolicyType, opt => opt.MapFrom(src => src.PolicyType.Name))
                .ForMember(dest => dest.SalesType, opt => opt.MapFrom(src => src.SalesType.Name)).ReverseMap();

            CreateMap<PolicyRisk, PolicyRiskResource>()
            .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType.Name)).ReverseMap();

            CreateMap<PolicyStatus, PolicyStatusResource>().ReverseMap();
            CreateMap<PolicyType, PolicyTypeResource>().ReverseMap();

            CreateMap<Portfolio, PortfolioResource>()
                    .ForMember(dest => dest.TotalClients, opt => opt.MapFrom(src => src.PortfolioClients.Count)).ReverseMap();
            
            CreateMap<PortfolioClient, PortfolioClientResource>().ReverseMap();

            CreateMap<Quote, QuoteResource>()
                .ForMember(dest => dest.Insurer, opt => opt.MapFrom(src => src.Insurer.Name))
                .ForMember(dest => dest.QuoteStatus, opt => opt.MapFrom(src => src.QuoteStatus.Name))
                .ForMember(dest => dest.QuoteItems, opt => opt.MapFrom(src => src.QuoteItems)).ReverseMap();
            
            CreateMap<QuoteItem, QuoteItemResource>()
                .ForMember(dest => dest.CoverType, opt => opt.MapFrom(src => src.CoverType.Name)).ReverseMap();

            CreateMap<QuoteStatus, QuoteStatusResource>().ReverseMap();

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
