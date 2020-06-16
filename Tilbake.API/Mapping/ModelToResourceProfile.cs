using AutoMapper;
using Tilbake.API.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Title, TitleResource>();
        }
    }
}
