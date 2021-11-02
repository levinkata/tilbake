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

            _unitOfWork.InsurerBranches.Add(insurerBranch);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.InsurerBranches.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InsurerBranchResource>> GetAllAsync()
        {
            var result = await _unitOfWork.InsurerBranches.GetAsync(
                                            null,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.City,
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<InsurerBranchResource>> GetByInsurerIdAsync(Guid insurerId)
        {
            var result = await _unitOfWork.InsurerBranches.GetAsync(
                                            e => e.InsurerId == insurerId,
                                            e => e.OrderBy(r => r.Name),
                                            e => e.City,
                                            e => e.Insurer);

            var resources = _mapper.Map<IEnumerable<InsurerBranch>, IEnumerable<InsurerBranchResource>>(result);
            return resources;
        }

        public async Task<InsurerBranchResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.InsurerBranches.GetAsync(
                                            e => e.Id == id,
                                            null,
                                            e => e.City,
                                            e => e.Insurer);

            var resource = _mapper.Map<InsurerBranch, InsurerBranchResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(InsurerBranchResource resource)
        {
            var insurerBranch = _mapper.Map<InsurerBranchResource, InsurerBranch>(resource);
            insurerBranch.DateModified = DateTime.Now;
            _unitOfWork.InsurerBranches.Update(resource.Id, insurerBranch);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<InsurerBranchResource> GetByNameAsync(string name)
        {
            var result = await _unitOfWork.InsurerBranches.GetAsync(
                                e => e.Name == name,
                                null,
                                e => e.City,
                                e => e.Insurer);

            var resource = _mapper.Map<InsurerBranch, InsurerBranchResource>(result.FirstOrDefault());
            return resource;
        }
    }
}