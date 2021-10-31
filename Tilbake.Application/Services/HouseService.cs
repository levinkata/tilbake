using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class HouseService : IHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HouseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(HouseSaveResource resource)
        {
            var house = _mapper.Map<HouseSaveResource, House>(resource);
            house.Id = Guid.NewGuid();
            house.DateAdded = DateTime.Now;

            _unitOfWork.Houses.Add(house);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Houses.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HouseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Houses.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.PhysicalAddress),
                                            r => r.HouseCondition,
                                            r => r.ResidenceType,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resources = _mapper.Map<IEnumerable<House>, IEnumerable<HouseResource>>(result);
            return resources;
        }

        public async Task<HouseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Houses.GetByIdAsync(
                                            r => r.Id == id,
                                            r => r.HouseCondition,
                                            r => r.ResidenceType,
                                            r => r.RoofType,
                                            r => r.WallType);

            var resource = _mapper.Map<House, HouseResource>(result);
            return resource;
        }

        public async void Update(HouseResource resource)
        {
            var house = _mapper.Map<HouseResource, House>(resource);
            _unitOfWork.Houses.Update(resource.Id, house);

            _unitOfWork.SaveAsync();
        }
    }
}
