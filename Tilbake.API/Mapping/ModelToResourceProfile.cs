using AutoMapper;
using Tilbake.API.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Klient, KlientResource>();
            CreateMap<Title, TitleResource>();
        }
    }
}
