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
    public class PaymentMethodService : IPaymentMethodService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentMethodService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PaymentMethodSaveResource resource)
        {
            var paymentMethod = _mapper.Map<PaymentMethodSaveResource, PaymentMethod>(resource);
            paymentMethod.Id = Guid.NewGuid();

            _unitOfWork.PaymentMethods.Add(paymentMethod);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PaymentMethods.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PaymentMethodResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PaymentMethods.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<PaymentMethod>, IEnumerable<PaymentMethodResource>>(result);

            return resources;
        }

        public async Task<PaymentMethodResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PaymentMethods.GetByIdAsync(id);
            var resources = _mapper.Map<PaymentMethod, PaymentMethodResource>(result);
            return resources;
        }

        public async void Update(PaymentMethodResource resource)
        {
            var paymentMethod = _mapper.Map<PaymentMethodResource, PaymentMethod>(resource);
            _unitOfWork.PaymentMethods.Update(resource.Id, paymentMethod);

            await _unitOfWork.SaveAsync();
        }
    }
}
