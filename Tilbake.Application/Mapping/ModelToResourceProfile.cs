using AutoMapper;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Bank, BankResource>().ReverseMap();
            CreateMap<BankBranch, BankBranchResource>()
                    .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name)).ReverseMap();

            CreateMap<Carrier, CarrierResource>().ReverseMap();
            CreateMap<Client, ClientResource>()
            .ForMember(dest => dest.Carrier, opt => opt.MapFrom(src => src.Carrier.Name))
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
            CreateMap<Title, TitleResource>().ReverseMap();
        }
    }
}
