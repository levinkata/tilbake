using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<AspnetUserPortfolio, AspnetUserPortfolioResource>()
                    .ForMember(dest => dest.PortfolioName, opt => opt.MapFrom(src => src.Portfolio.Name)).ReverseMap();

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
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name)).ReverseMap();

            CreateMap<ClientRisk, ClientRiskResource>().ReverseMap();
            CreateMap<ClientType, ClientTypeResource>().ReverseMap();
            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<CoverType, CoverTypeResource>().ReverseMap();
            CreateMap<DocumentType, DocumentTypeResource>().ReverseMap();
            CreateMap<DriverType, DriverTypeResource>().ReverseMap();
            CreateMap<Gender, GenderResource>().ReverseMap();
            CreateMap<Insurer, InsurerResource>().ReverseMap();
            CreateMap<Invoice, InvoiceResource>().ReverseMap();
            CreateMap<InvoiceStatus, InvoiceStatusResource>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusResource>().ReverseMap();
            CreateMap<Motor, MotorResource>().ReverseMap();
            CreateMap<MotorMake, MotorMakeResource>().ReverseMap();
            CreateMap<MotorModel, MotorModelResource>().ReverseMap();
            CreateMap<MotorUse, MotorUseResource>().ReverseMap();
            CreateMap<Occupation, OccupationResource>().ReverseMap();
            CreateMap<PolicyStatus, PolicyStatusResource>().ReverseMap();
            CreateMap<PolicyType, PolicyTypeResource>().ReverseMap();

            CreateMap<Portfolio, PortfolioResource>()
                    .ForMember(dest => dest.TotalClients, opt => opt.MapFrom(src => src.PortfolioClients.Count)).ReverseMap();
            
            CreateMap<PortfolioClient, PortfolioClientResource>().ReverseMap();

            CreateMap<Quote, QuoteResource>()
                .ForMember(dest => dest.QuoteStatus, opt => opt.MapFrom(src => src.QuoteStatus.Name)).ReverseMap();

            CreateMap<QuoteStatus, QuoteStatusResource>().ReverseMap();
            CreateMap<Risk, RiskResource>().ReverseMap();
            CreateMap<SalesType, SalesTypeResource>().ReverseMap();
            CreateMap<Title, TitleResource>().ReverseMap();
        }
    }
}
