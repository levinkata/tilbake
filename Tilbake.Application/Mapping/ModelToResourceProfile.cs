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

            CreateMap<Client, ClientResource>()
                    .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => src.ClientType.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Name))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name)).ReverseMap();

            CreateMap<ClientType, ClientTypeResource>().ReverseMap();
            CreateMap<Country, CountryResource>().ReverseMap();
            CreateMap<Gender, GenderResource>().ReverseMap();
            CreateMap<MaritalStatus, MaritalStatusResource>().ReverseMap();
            CreateMap<Occupation, OccupationResource>().ReverseMap();
            CreateMap<Portfolio, PortfolioResource>()
                    .ForMember(dest => dest.TotalClients, opt => opt.MapFrom(src => src.PortfolioClients.Count)).ReverseMap();
            CreateMap<PortfolioClient, PortfolioClientResource>().ReverseMap();
            CreateMap<Title, TitleResource>().ReverseMap();
        }
    }
}
