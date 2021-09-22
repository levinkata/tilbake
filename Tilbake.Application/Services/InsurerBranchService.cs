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
    public class InsurerBranchService : IInsurerBranchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsurerBranchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(InsurerBranchSaveResource resource)
        {
            var insurerBranch = _mapper.Map<InsurerBranchSaveResource, InsurerBranch>(resource);
            insurerBranch.Id = Guid.NewGuid();
            insurerBranch.DateAdded = DateTime.Now;

            await _unitOfWork.InsurerBranches.AddAsync(insurerBranch);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.InsurerBranches.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(InsurerBranchResource resource)
        {
            var insurerBranch = _mapper.Map<InsurerBranchResource, InsurerBranch>(resource);
            await _unitOfWork.InsurerBranches.DeleteAsync(insurerBranch);
            return await  _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InsurerBranchResource>> GetAllAsync()
        {
            var result = await _unitOfWork.InsurerBranches.GetAllAsync(
                                            null,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.City);

            var resources = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<InsurerBranchResource>> GetByInsurerIdAsync(Guid insurerId)
        {
            var result = await _unitOfWork.InsurerBranches.GetAllAsync(
                                            e => e.InsurerId == insurerId,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.City);

            var resources = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchResource>>(result);
            return resources;
        }

        public async Task<InsurerBranchResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InsurerBranches.GetFirstOrDefaultAsync(
                                            e => e.Id == id,
                                            e => e.City);

            var resource = _mapper.Map<InsurerBranch, InsurerBranchResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(InsurerBranchResource resource)
        {
            var insurerBranch = _mapper.Map<InsurerBranchResource, InsurerBranch>(resource);
            insurerBranch.DateModified = DateTime.Now;
            await _unitOfWork.InsurerBranches.UpdateAsync(resource.Id, insurerBranch);

            return await _unitOfWork.SaveAsync();
        }
    }
}