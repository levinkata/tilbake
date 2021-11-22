using AutoMapper;
using Tilbake.Core.Models;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Occupation, OccupationViewModel>().ReverseMap();
        }
    }
}
