using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class TaxService : ITaxService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaxService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(TaxSaveResource resource)
        {
            var tax = _mapper.Map<TaxSaveResource, Tax>(resource);
            tax.Id = Guid.NewGuid();
            tax.DateAdded = DateTime.Now;

            await _unitOfWork.Taxes.AddAsync(tax);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Taxes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(TaxResource resource)
        {
            var tax = _mapper.Map<TaxResource, Tax>(resource);
            await _unitOfWork.Taxes.DeleteAsync(tax);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TaxResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Taxes.GetAllAsync(
                                        null,
                                        r => r.OrderByDescending(n => n.TaxDate));

            var resources = _mapper.Map<IEnumerable<Tax>, IEnumerable<TaxResource>>(result);
            return resources;
        }

        public async Task<TaxResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Taxes.GetByIdAsync(id);
            var resources = _mapper.Map<Tax, TaxResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(TaxResource resource)
        {
            var tax = _mapper.Map<TaxResource, Tax>(resource);
            await _unitOfWork.Taxes.UpdateAsync(resource.Id, tax);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}