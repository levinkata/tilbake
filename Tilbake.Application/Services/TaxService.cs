using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

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

        public async void Add(TaxSaveResource resource)
        {
            var tax = _mapper.Map<TaxSaveResource, Tax>(resource);
            tax.Id = Guid.NewGuid();
            tax.DateAdded = DateTime.Now;

            _unitOfWork.Taxes.Add(tax);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Taxes.Delete(id);
            await _unitOfWork.SaveAsync();
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
            var resource = _mapper.Map<Tax, TaxResource>(result);
            return resource;
        }

        public async void Update(TaxResource resource)
        {
            var tax = _mapper.Map<TaxResource, Tax>(resource);
            _unitOfWork.Taxes.Update(resource.Id, tax);

            await _unitOfWork.SaveAsync();
        }
    }
}