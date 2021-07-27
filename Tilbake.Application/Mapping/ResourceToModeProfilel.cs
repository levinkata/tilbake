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
            CreateMap<GenderSaveResource, Gender>();
            CreateMap<HouseSaveResource, House>();
            CreateMap<HouseConditionSaveResource, HouseCondition>();
            CreateMap<InsurerSaveResource, Insurer>();
            CreateMap<InvoiceStatusSaveResource, InvoiceStatus>();
            CreateMap<InvoiceSaveResource, Invoice>();
            CreateMap<MaritalStatusSaveResource, MaritalStatus>();
            CreateMap<MotorSaveResource, Motor>();
            CreateMap<MotorMakeSaveResource, MotorMake>();
            CreateMap<MotorModelSaveResource, MotorModel>();
            CreateMap<MotorUseSaveResource, MotorUse>();
            CreateMap<OccupationSaveResource, Occupation>();
            CreateMap<PolicyStatusSaveResource, PolicyStatus>();
            CreateMap<PortfolioSaveResource, Portfolio>();
            CreateMap<QuoteSaveResource, Quote>();
            CreateMap<QuoteStatusSaveResource, QuoteStatus>();
            CreateMap<PolicyTypeSaveResource, PolicyType>();
            CreateMap<RiskSaveResource, Risk>();
            CreateMap<RiskItemSaveResource, RiskItem>();
            CreateMap<ResidenceTypeSaveResource, ResidenceType>();
            CreateMap<ResidenceUseSaveResource, ResidenceUse>();
            CreateMap<RoofTypeSaveResource, RoofType>();
            CreateMap<SalesTypeSaveResource, SalesType>();
            CreateMap<TitleSaveResource, Title>();
            CreateMap<WallTypeSaveResource, WallType>();
        }
    }
}
