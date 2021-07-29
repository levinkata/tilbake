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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(PaymentMethodSaveResource resource)
        {
            var paymentMethod = _mapper.Map<PaymentMethodSaveResource, PaymentMethod>(resource);
            paymentMethod.Id = Guid.NewGuid();

            await _unitOfWork.PaymentMethods.AddAsync(paymentMethod);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PaymentMethods.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(PaymentMethodResource resource)
        {
            var paymentMethod = _mapper.Map<PaymentMethodResource, PaymentMethod>(resource);
            await _unitOfWork.PaymentMethods.DeleteAsync(paymentMethod);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<PaymentMethodResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.PaymentMethods.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(result);

            return resources;
        }

        public async Task<PaymentMethodResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PaymentMethods.GetByIdAsync(id);
            var resources = _mapper.Map<PaymentMethod, PaymentMethodResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(PaymentMethodResource resource)
        {
            var paymentMethod = _mapper.Map<PaymentMethodResource, PaymentMethod>(resource);
            await _unitOfWork.PaymentMethods.UpdateAsync(resource.Id, paymentMethod);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
