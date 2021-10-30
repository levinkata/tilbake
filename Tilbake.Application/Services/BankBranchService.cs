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

        public async void Add(BankBranchSaveResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchSaveResource, BankBranch>(resource);
            bankBranch.Id = Guid.NewGuid();
            bankBranch.DateAdded = DateTime.Now;

            _unitOfWork.BankBranches.Add(bankBranch);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.BankBranches.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            _unitOfWork.BankBranches.Delete(bankBranch);
            await _unitOfWork.SaveAsync();
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

        public async void Update(BankBranchResource resource)
        {
            var bankBranch = _mapper.Map<BankBranchResource, BankBranch>(resource);
            bankBranch.DateModified = DateTime.Now;
            _unitOfWork.BankBranches.Update(resource.Id, bankBranch);

            await _unitOfWork.SaveAsync();
        }
    }
}