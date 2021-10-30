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

        public async void Add(PortfolioAdministrationFeeSaveResource resource)
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
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PortfolioAdministrationFees.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(PortfolioAdministrationFeeResource resource)
        {
            var portfolioAdministrationFee = _mapper.Map<PortfolioAdministrationFeeResource, PortfolioAdministrationFee>(resource);
            _unitOfWork.PortfolioAdministrationFees.Delete(portfolioAdministrationFee);

            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.Insurer.Name),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async Task<PortfolioAdministrationFeeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetFirstOrDefaultAsync(
                                                                r => r.Id == id,
                                                                r => r.Insurer);
            var resource = _mapper.Map<PortfolioAdministrationFee, PortfolioAdministrationFeeResource>(result);
            return resource;
        }

        public async Task<IEnumerable<PortfolioAdministrationFeeResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioAdministrationFees.GetAllAsync(
                                            e => e.PortfolioId == portfolioId,
                                            e => e.OrderBy(r => r.Insurer.Name),
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<PortfolioAdministrationFee>, IEnumerable<PortfolioAdministrationFeeResource>>(result);
            return resources;
        }

        public async void Update(PortfolioAdministrationFeeResource resource)
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

            await _unitOfWork.SaveAsync();
        }
    }
}
