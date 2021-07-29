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
    public class BankService : IBankService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BankSaveResource resource)
        {
            var bank = _mapper.Map<BankSaveResource, Bank>(resource);
            bank.Id = Guid.NewGuid();

            await _unitOfWork.Banks.AddAsync(bank);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Banks.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(BankResource resource)
        {
            var bank = _mapper.Map<BankResource, Bank>(resource);
            await _unitOfWork.Banks.DeleteAsync(bank);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<BankResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Banks.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankResource>>(result);

            return resources;
        }

        public async Task<BankResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Banks.GetByIdAsync(id);
            var resources = _mapper.Map<Bank, BankResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(BankResource resource)
        {
            var bank = _mapper.Map<BankResource, Bank>(resource);
            await _unitOfWork.Banks.UpdateAsync(resource.Id, bank);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}