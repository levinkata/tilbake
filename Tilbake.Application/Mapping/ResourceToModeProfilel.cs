using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ResourceToModeProfilel : Profile
    {
        public ResourceToModeProfilel()
        {
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
            CreateMap<CoverTypeSaveResource, CoverType>();
            CreateMap<DocumentTypeSaveResource, DocumentType>();
            CreateMap<DriverTypeSaveResource, DriverType>();
            CreateMap<GenderSaveResource, Gender>();
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
            CreateMap<QuoteItemSaveResource, QuoteItem>();
            CreateMap<QuoteStatusSaveResource, QuoteStatus>();
            CreateMap<PolicyTypeSaveResource, PolicyType>();
            CreateMap<RiskSaveResource, Risk>();
            CreateMap<SalesTypeSaveResource, SalesType>();
            CreateMap<TitleSaveResource, Title>();
        }
    }
}
