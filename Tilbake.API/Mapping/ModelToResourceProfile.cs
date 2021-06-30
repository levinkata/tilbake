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
        }
    }
}
