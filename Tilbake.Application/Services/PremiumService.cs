using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class PremiumService : IPremiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PremiumService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(PremiumSaveResource resource)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PremiumResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Premiums.FindAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.PremiumDate));

            var resources = _mapper.Map<IEnumerable<Premium>, IEnumerable<PremiumResource>>(result);
            return resources;
        }

        public Task<PremiumResource> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PremiumResource>> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.Premiums.FindAllAsync(
                                                r => r.PolicyId == policyId,
                                                r => r.OrderBy(p => p.PremiumDate));

            var resources = _mapper.Map<IEnumerable<Premium>, IEnumerable<PremiumResource>>(result);

            return resources;
        }

        public void Update(PremiumResource resource)
        {
            throw new NotImplementedException();
        }
    }
}
