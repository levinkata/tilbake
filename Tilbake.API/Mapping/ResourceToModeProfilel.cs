using AutoMapper;
using Tilbake.API.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Mapping
{
    public class ResourceToModeProfilel : Profile
    {
        public ResourceToModeProfilel()
        {
            CreateMap<BankSaveResource, Bank>();
            CreateMap<BankBranchSaveResource, BankBranch>();
            CreateMap<CarrierSaveResource, Carrier>();
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
