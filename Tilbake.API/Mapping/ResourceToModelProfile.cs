using AutoMapper;
using Tilbake.API.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveTitleResource, Title>();
        }
    }
}
