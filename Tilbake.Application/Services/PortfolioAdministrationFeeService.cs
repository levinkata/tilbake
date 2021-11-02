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
            if (portfolioAdministrationFee.IsFeeFixed)
            {
                portfolioAdministrationFee.Rate = 0;
            }
            else
            {
                portfolioAdministrationFee.Fee = 0;
            }

            _unitOfWork.PortfolioAdministrationFees.Add(portfolioAdministrationFee);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.PortfolioAdministrationFees.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAsync(
                                            null,
                                            r => r.OrderBy(p => p.Insurer.Name),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async Task<PortfolioAdministrationFeeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAsync(
                                                                r => r.Id == id, null,
                                                                r => r.Insurer);
            var resource = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAsync(
                                            e => e.PortfolioId == portfolioId,
                                            e => e.OrderBy(r => r.Insurer.Name),
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(PortfolioAdministrationFeeResource resource)
        {
            var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeResource, PortfolioAdministrationFee>(resource);
            portfolioAdministrationFee.DateModified = DateTime.Now;
            if (portfolioAdministrationFee.IsFeeFixed)
            {
                portfolioAdministrationFee.Rate = 0;
            }
            else
            {
                portfolioAdministrationFee.Fee = 0;
            }

            _unitOfWork.PortfolioAdministrationFees.Update(resource.Id, portfolioAdministrationFee);

            return await _unitOfWork.SaveAsync();
        }
    }
}
