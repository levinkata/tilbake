using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class AuditService : IAuditService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Audits.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(AuditResource resource)
        {
            var audit = _mapper.Map<AuditResource, Audit>(resource);
            await _unitOfWork.Audits.DeleteAsync(audit);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AuditResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Audits.GetAllAsync();

            var resources = _mapper.Map<IEnumerable<Audit>, IEnumerable<AuditResource>>(result);

            return resources;
        }

        public async Task<AuditResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Audits.GetByIdAsync(id);
            var resources = _mapper.Map<Audit, AuditResource>(result);

            return resources;
        }
    }
}
