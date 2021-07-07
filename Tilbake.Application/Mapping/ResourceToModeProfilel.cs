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
            CreateMap<PortfolioSaveResource, Portfolio>();
            CreateMap<ClientSaveResource, Client>();
            CreateMap<ClientTypeSaveResource, ClientType>();
            CreateMap<CountrySaveResource, Country>();
            CreateMap<GenderSaveResource, Gender>();
            CreateMap<MaritalStatusSaveResource, MaritalStatus>();
            CreateMap<OccupationSaveResource, Occupation>();
            CreateMap<TitleSaveResource, Title>();
        }
    }
}
