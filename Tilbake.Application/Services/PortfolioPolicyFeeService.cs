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
    public class PortfolioPolicyFeeService : IPortfolioPolicyFeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioPolicyFeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PortfolioPolicyFeeSaveResource resource)
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

            _unitOfWork.PortfolioPolicyFees.Add(portfolioPolicyFee);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PortfolioPolicyFees.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(PortfolioPolicyFeeResource resource)
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
            _unitOfWork.PortfolioPolicyFees.Update(resource.Id, portfolioPolicyFee);

            await _unitOfWork.SaveAsync();
        }
    }
}
