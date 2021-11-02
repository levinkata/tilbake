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

            _unitOfWork.BankBranches.Add(bankBranch);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.BankBranches.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BankBranchResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BankBranches.GetAsync(
                                            null,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.Bank);

            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<BankBranchResource>> GetByBankIdAsync(Guid bankId)
        {
            var result = await _unitOfWork.BankBranches.GetAsync(
                                            e => e.BankId == bankId,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.Bank);

            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        public async Task<BankBranchResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BankBranches.GetAsync(
                                            e => e.Id == id,
                                            null,
                                            e => e.Bank);
                                            
            var resource = _mapper.Map<BankBranch, BankBranchResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            bankBranch.DateModified = DateTime.Now;
            _unitOfWork.BankBranches.Update(resource.Id, bankBranch);

            return await _unitOfWork.SaveAsync();
        }
    }
}