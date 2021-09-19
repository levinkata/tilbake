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
    public class PortfolioPolicyFeeService : IPortfolioPolicyFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioPolicyFeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PortfolioPolicyFeeSaveResource resource)
        {
            var portfolioPolicyFee = _mapper.Map<PortfolioPolicyFeeSaveResource, PortfolioPolicyFee>(resource);
            portfolioPolicyFee.Id = Guid.NewGuid();
            portfolioPolicyFee.DateAdded = DateTime.Now;
            if (portfolioPolicyFee.IsFeeFixed)
            {
                portfolioPolicyFee.Rate = 0;
            } else
            {
                portfolioPolicyFee.Fee = 0;
            }

            await _unitOfWork.PortfolioPolicyFees.AddAsync(portfolioPolicyFee);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioPolicyFees.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PortfolioPolicyFeeResource resource)
        {
            var portfolioPolicyFee = _mapper.Map<PortfolioPolicyFeeResource, PortfolioPolicyFee>(resource);
            await _unitOfWork.PortfolioPolicyFees.DeleteAsync(portfolioPolicyFee);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioPolicyFeeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioPolicyFees.GetAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.Insurer.Name),
                                                r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioPolicyFee>, IEnumerable<PortfolioPolicyFeeResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<PortfolioPolicyFeeResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioPolicyFees.GetAllAsync(
                                            e => e.PortfolioId == portfolioId,
                                            e => e.OrderBy(r => r.Insurer.Name),
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioPolicyFee>, IEnumerable<PortfolioPolicyFeeResource>>(result);
            return resources;
        }

        public async Task<PortfolioPolicyFeeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioPolicyFees.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.Insurer);

            var resource = _mapper.Map<PortfolioPolicyFee, PortfolioPolicyFeeResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(PortfolioPolicyFeeResource resource)
        {
            var portfolioPolicyFee = _mapper.Map<PortfolioPolicyFeeResource, PortfolioPolicyFee>(resource);

            portfolioPolicyFee.DateModified = DateTime.Now;
            if (portfolioPolicyFee.IsFeeFixed)
            {
                portfolioPolicyFee.Rate = 0;
            }
            else
            {
                portfolioPolicyFee.Fee = 0;
            }
            await _unitOfWork.PortfolioPolicyFees.UpdateAsync(resource.Id, portfolioPolicyFee);

            return await _unitOfWork.SaveAsync();
        }
    }
}
