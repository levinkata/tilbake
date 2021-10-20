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
    public class PortfolioExcessBuyBackService : IPortfolioExcessBuyBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioExcessBuyBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PortfolioExcessBuyBackResource> AddAsync(PortfolioExcessBuyBackSaveResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackSaveResource, PortfolioExcessBuyBack>(resource);
            portfolioExcessBuyBack.Id = Guid.NewGuid();
            portfolioExcessBuyBack.DateAdded = DateTime.Now;

            await _unitOfWork.PortfolioExcessBuyBacks.AddAsync(portfolioExcessBuyBack);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackResource>(portfolioExcessBuyBack);
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioExcessBuyBacks.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PortfolioExcessBuyBackResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackResource, PortfolioExcessBuyBack>(resource);
            await _unitOfWork.PortfolioExcessBuyBacks.DeleteAsync(portfolioExcessBuyBack);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.Insurer.Name),
                                                r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<PortfolioExcessBuyBackResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetAllAsync(
                                                e => e.PortfolioId == portfolioId,
                                                e => e.OrderBy(r => r.Insurer.Name),
                                                e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioExcessBuyBack>, IEnumerable<PortfolioExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<PortfolioExcessBuyBackResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioExcessBuyBacks.GetFirstOrDefaultAsync(
                                                r => r.Id == id,
                                                r => r.Insurer);

            var resource = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackResource>(result);
            return resource;
        }

        public async Task<PortfolioExcessBuyBackResource> UpdateAsync(PortfolioExcessBuyBackResource resource)
        {
            var portfolioExcessBuyBack = _mapper.Map<PortfolioExcessBuyBackResource, PortfolioExcessBuyBack>(resource);

            portfolioExcessBuyBack.DateModified = DateTime.Now;
            
            await _unitOfWork.PortfolioExcessBuyBacks.UpdateAsync(resource.Id, portfolioExcessBuyBack);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<PortfolioExcessBuyBack, PortfolioExcessBuyBackResource>(portfolioExcessBuyBack);
            return result;
        }
    }
}
