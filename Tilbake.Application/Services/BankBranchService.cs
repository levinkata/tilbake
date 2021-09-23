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
            bankBranch.DateAdded = DateTime.Now;

            await _unitOfWork.BankBranches.AddAsync(bankBranch);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.BankBranches.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            await _unitOfWork.BankBranches.DeleteAsync(bankBranch);
            return await  _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BankBranchResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BankBranches.GetAllAsync(
                                            null,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.Bank);

            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<BankBranchResource>> GetByBankIdAsync(Guid bankId)
        {
            var result = await _unitOfWork.BankBranches.GetAllAsync(
                                            e => e.BankId == bankId,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.Bank);

            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        public async Task<BankBranchResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetFirstOrDefaultAsync(
                                            e => e.Id == id,
                                            e => e.Bank);
                                            
            var resource = _mapper.Map<BankBranch, BankBranchResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            bankBranch.DateModified = DateTime.Now;
            await _unitOfWork.BankBranches.UpdateAsync(resource.Id, bankBranch);

            return await _unitOfWork.SaveAsync();
        }
    }
}