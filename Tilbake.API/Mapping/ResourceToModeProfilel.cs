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
        }
    }
}
