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
    public class PaymentTypeService : IPaymentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(PaymentTypeSaveResource resource)
        {
            var paymentType = _mapper.Map<PaymentTypeSaveResource, PaymentType>(resource);
            paymentType.Id = Guid.NewGuid();

            _unitOfWork.PaymentTypes.Add(paymentType);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.PaymentTypes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PaymentTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.PaymentTypes.FindAllAsync(
                                                        null,
                                                        r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<PaymentType>, IEnumerable<PaymentTypeResource>>(result);
            return resources;
        }

        public async Task<PaymentTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PaymentTypes.GetByIdAsync(id);
            var resource = _mapper.Map<PaymentType, PaymentTypeResource>(result);

            return resource;
        }

        public async void Update(PaymentTypeResource resource)
        {
            var paymentType = _mapper.Map<PaymentTypeResource, PaymentType>(resource);
            _unitOfWork.PaymentTypes.Update(resource.Id, paymentType);

            await _unitOfWork.SaveAsync();
        }
    }
}
