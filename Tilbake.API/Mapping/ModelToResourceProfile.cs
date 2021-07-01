using AutoMapper;
using Tilbake.API.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Bank, BankResource>();
            CreateMap<BankBranch, BankBranchResource>()
                    .ForMember(dest => dest.BankName, opt => opt.MapFrom(src => src.Bank.Name));

            CreateMap<Carrier, CarrierResource>();
            CreateMap<Client, ClientResource>()
                    .ForMember(dest => dest.Carrier, opt => opt.MapFrom(src => src.Carrier.Name))
                    .ForMember(dest => dest.ClientType, opt => opt.MapFrom(src => src.ClientType.Name))
                    .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.Name))
                    .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Name))
                    .ForMember(dest => dest.MaritalStatus, opt => opt.MapFrom(src => src.MaritalStatus.Name))
                    .ForMember(dest => dest.Occupation, opt => opt.MapFrom(src => src.Occupation.Name))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title.Name));
                    
            CreateMap<ClientType, ClientTypeResource>();
            CreateMap<Country, CountryResource>();
            CreateMap<Gender, GenderResource>();
            CreateMap<MaritalStatus, MaritalStatusResource>();
            CreateMap<Occupation, OccupationResource>();
            CreateMap<Title, TitleResource>();                                                                                                        
        }
    }
}
