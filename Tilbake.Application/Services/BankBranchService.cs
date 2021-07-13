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
    public class BankBranchService : IBankBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankBranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BankBranchSaveResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchSaveResource, BankBranch>(resource);
            bankBranch.Id = Guid.NewGuid();

            await _unitOfWork.BankBranches.AddAsync(bankBranch).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.BankBranches.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            await _unitOfWork.BankBranches.DeleteAsync(bankBranch).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<BankBranchResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.BankBranches.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<BankBranchResource>> GetByBankId(Guid bankId)
        {
            var result = await Task.Run(() => _unitOfWork.BankBranches.GetByBankId(bankId)).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);

            return resources;
        }

        public async Task<BankBranchResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetByIdAsync(id).ConfigureAwait(true);
            var resource = _mapper.Map<BankBranch, BankBranchResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            await _unitOfWork.BankBranches.UpdateAsync(resource.Id, bankBranch).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}