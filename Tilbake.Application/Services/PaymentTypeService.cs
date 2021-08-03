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
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PaymentTypeSaveResource resource)
        {
            var paymentType = _mapper.Map<PaymentTypeSaveResource, PaymentType>(resource);
            paymentType.Id = Guid.NewGuid();

            await _unitOfWork.PaymentTypes.AddAsync(paymentType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PaymentTypes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(PaymentTypeResource resource)
        {
            var paymentType = _mapper.Map<PaymentTypeResource, PaymentType>(resource);
            await _unitOfWork.PaymentTypes.DeleteAsync(paymentType);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PaymentTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.PaymentTypes.GetAllAsync(
                                                        null,
                                                        r => r.OrderBy(n => n.Name)));

            var resources = _mapper.Map<IEnumerable<PaymentType>, IEnumerable<PaymentTypeResource>>(result);

            return resources;
        }

        public async Task<PaymentTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
            var resources = _mapper.Map<PaymentType, PaymentTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(PaymentTypeResource resource)
        {
            var paymentType = _mapper.Map<PaymentTypeResource, PaymentType>(resource);
            await _unitOfWork.PaymentTypes.UpdateAsync(resource.Id, paymentType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
