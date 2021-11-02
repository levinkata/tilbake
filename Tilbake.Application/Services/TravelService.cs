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

        public async Task<int> AddAsync(TravelSaveResource resource)
        {
            var travel = _mapper.Map<TravelSaveResource, Travel>(resource);
            travel.Id = Guid.NewGuid();
            travel.DateAdded = DateTime.Now;

            _unitOfWork.Travels.Add(travel);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Travels.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TravelResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Travels.GetAsync(
                                            null,
                                            r => r.OrderBy(p => p.PortfolioClient.Client.LastName),
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);
            
            var resources = _mapper.Map<IEnumerable<Travel>, IEnumerable<TravelResource>>(result);
            return resources;
        }

        public async Task<TravelResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Travels.GetAsync(
                                            r => r.Id == id, null,
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);

            var resource = _mapper.Map<Travel, TravelResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(TravelResource resource)
        {
            var travel = _mapper.Map<TravelResource, Travel>(resource);
            travel.DateModified = DateTime.Now;

            _unitOfWork.Travels.Update(resource.Id, travel);
            return await _unitOfWork.SaveAsync();
        }
    }
}
