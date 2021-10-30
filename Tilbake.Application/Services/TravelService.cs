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
    public class TravelService : ITravelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TravelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(TravelSaveResource resource)
        {
            var travel = _mapper.Map<TravelSaveResource, Travel>(resource);
            travel.Id = Guid.NewGuid();
            travel.DateAdded = DateTime.Now;

            _unitOfWork.Travels.Add(travel);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Travels.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TravelResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Travels.FindAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.PortfolioClient.Client.LastName),
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);
            
            var resources = _mapper.Map<IEnumerable<Travel>, IEnumerable<TravelResource>>(result);
            return resources;
        }

        public async Task<TravelResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Travels.GetByIdAsync(
                                            r => r.Id == id,
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);

            var resource = _mapper.Map<Travel, TravelResource>(result);
            return resource;
        }

        public async void Update(TravelResource resource)
        {
            var travel = _mapper.Map<TravelResource, Travel>(resource);
            travel.DateModified = DateTime.Now;

            _unitOfWork.Travels.Update(resource.Id, travel);
            await _unitOfWork.SaveAsync();
        }
    }
}
