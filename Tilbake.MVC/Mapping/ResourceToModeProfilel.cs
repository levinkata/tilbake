using AutoMapper;
using Tilbake.MVC.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.Mapping
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
