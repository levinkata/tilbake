using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ResourceToModeProfilel : Profile
    {
        public ResourceToModeProfilel()
        {
            CreateMap<AllRiskSaveResource, AllRisk>();
            CreateMap<BankSaveResource, Bank>();
            CreateMap<BankBranchSaveResource, BankBranch>();
            CreateMap<BodyTypeSaveResource, BodyType>();
            CreateMap<CarrierSaveResource, Carrier>();
            CreateMap<CitySaveResource, City>();
            CreateMap<ClientSaveResource, Client>();
            CreateMap<ClientTypeSaveResource, ClientType>();
            CreateMap<CountrySaveResource, Country>();
            CreateMap<ClientDocumentSaveResource, ClientDocument>();
            CreateMap<ClientRiskSaveResource, ClientRisk>();
            CreateMap<ContentSaveResource, Content>();
            CreateMap<CoverTypeSaveResource, CoverType>();
            CreateMap<DocumentTypeSaveResource, DocumentType>();
            CreateMap<DriverTypeSaveResource, DriverType>();
            CreateMap<FileTemplateSaveResource, FileTemplate>();
            CreateMap<FileTemplateRecordSaveResource, FileTemplateRecord>();
            CreateMap<GenderSaveResource, Gender>();
            CreateMap<HouseSaveResource, House>();
            CreateMap<HouseConditionSaveResource, HouseCondition>();
            CreateMap<InsurerSaveResource, Insurer>();
            CreateMap<InvoiceSaveResource, Invoice>();
            CreateMap<InvoiceItemSaveResource, InvoiceItem>();
            CreateMap<InvoiceStatusSaveResource, InvoiceStatus>();
            CreateMap<InvoiceSaveResource, Invoice>();
            CreateMap<MaritalStatusSaveResource, MaritalStatus>();
            CreateMap<MotorSaveResource, Motor>();
            CreateMap<MotorMakeSaveResource, MotorMake>();
            CreateMap<MotorModelSaveResource, MotorModel>();
            CreateMap<MotorUseSaveResource, MotorUse>();
            CreateMap<OccupationSaveResource, Occupation>();
            CreateMap<PaymentMethodSaveResource, PaymentMethod>();
            CreateMap<PaymentTypeSaveResource, PaymentType>();
            CreateMap<PolicyStatusSaveResource, PolicyStatus>();
            CreateMap<PortfolioSaveResource, Portfolio>();
            CreateMap<QuoteSaveResource, Quote>();
            CreateMap<QuoteItemSaveResource, QuoteItem>();
            CreateMap<QuoteStatusSaveResource, QuoteStatus>();
            CreateMap<PolicySaveResource, Policy>();
            CreateMap<PolicyRiskSaveResource, PolicyRisk>();
            CreateMap<PolicyTypeSaveResource, PolicyType>();
            CreateMap<RiskSaveResource, Risk>();
            CreateMap<RiskItemSaveResource, RiskItem>();
            CreateMap<ReceivableSaveResource, Receivable>();
            CreateMap<ReceivableDocumentSaveResource, ReceivableDocument>();
            CreateMap<ResidenceTypeSaveResource, ResidenceType>();
            CreateMap<ResidenceUseSaveResource, ResidenceUse>();
            CreateMap<RoofTypeSaveResource, RoofType>();
            CreateMap<SalesTypeSaveResource, SalesType>();
            CreateMap<TitleSaveResource, Title>();
            CreateMap<TaxSaveResource, Tax>();
            CreateMap<WallTypeSaveResource, WallType>();
        }
    }
}
