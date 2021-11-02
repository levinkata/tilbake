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
    public class PortfolioExcessBuyBackService : IPortfolioExcessBuyBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioExcessBuyBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PortfolioExcessBuyBackSaveResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackSaveResource, PortfolioExcessBuyBack>(resource);
            portfolioExcessBuyBack.Id = Guid.NewGuid();
            portfolioExcessBuyBack.DateAdded = DateTime.Now;

            _unitOfWork.PortfolioExcessBuyBacks.Add(portfolioExcessBuyBack);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.PortfolioExcessBuyBacks.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetAsync(
                                                null,
                                                r => r.OrderBy(n => n.Insurer.Name),
                                                r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetAsync(
                                                e => e.PortfolioId == portfolioId,
                                                e => e.OrderBy(r => r.Insurer.Name),
                                                e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<PortfolioExcessBuyBackResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetAsync(
                                                r => r.Id == id, null,
                                                r => r.Insurer);

            var resource = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(PortfolioExcessBuyBackResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackResource, PortfolioExcessBuyBack>(resource);

            portfolioExcessBuyBack.DateModified = DateTime.Now;
            
            _unitOfWork.PortfolioExcessBuyBacks.Update(resource.Id, portfolioExcessBuyBack);
            return await _unitOfWork.SaveAsync();
        }
    }
}
