using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

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

            await _unitOfWork.Travels.AddAsync(travel);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Travels.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(TravelResource resource)
        {
            var travel = _mapper.Map<TravelResource, Travel>(resource);
            await _unitOfWork.Travels.DeleteAsync(travel);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TravelResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Travels.GetAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.PortfolioClient.Client.LastName),
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);
            
            var resources = _mapper.Map<IEnumerable<Travel>, IEnumerable<TravelResource>>(result);
            return resources;
        }

        public async Task<TravelResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Travels.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.PortfolioClient,
                                            r => r.PortfolioClient.Client);

            var resource = _mapper.Map<Travel, TravelResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(TravelResource resource)
        {
            var travel = _mapper.Map<TravelResource, Travel>(resource);
            travel.DateModified = DateTime.Now;

            await _unitOfWork.Travels.UpdateAsync(resource.Id, travel);
            return await _unitOfWork.SaveAsync();
        }
    }
}
