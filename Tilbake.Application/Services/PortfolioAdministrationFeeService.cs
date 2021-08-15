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
    public class PortfolioAdministrationFeeService : IPortfolioAdministrationFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioAdministrationFeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PortfolioAdministrationFeeSaveResource resource)
        {
            var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeSaveResource, PortfolioAdministrationFee>(resource);
            portfolioAdministrationFee.Id = Guid.NewGuid();
            portfolioAdministrationFee.DateAdded = DateTime.Now;

            await _unitOfWork.PortfolioAdministrationFees.AddAsync(portfolioAdministrationFee);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioAdministrationFees.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PortfolioAdministrationFeeResource resource)
        {
            var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeResource, PortfolioAdministrationFee>(resource);
            await _unitOfWork.PortfolioAdministrationFees.DeleteAsync(portfolioAdministrationFee);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.Insurer));

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async Task<PortfolioAdministrationFeeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetByIdAsync(id);
            var resource = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeResource>(result);

            return resource;
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAllAsync(
                                            e => e.PortfolioId == portfolioId,
                                            e => e.OrderBy(r => r.Insurer),
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(PortfolioAdministrationFeeResource resource)
        {
            var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeResource, PortfolioAdministrationFee>(resource);
            portfolioAdministrationFee.DateModified = DateTime.Now;

            await _unitOfWork.PortfolioAdministrationFees.UpdateAsync(resource.Id, portfolioAdministrationFee);

            return await _unitOfWork.SaveAsync();
        }
    }
}
