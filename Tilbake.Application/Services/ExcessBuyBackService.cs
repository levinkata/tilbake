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
    public class ExcessBuyBackService : IExcessBuyBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExcessBuyBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ExcessBuyBackSaveResource resource)
        {
            var excessBuyBack = _mapper.Map<ExcessBuyBackSaveResource, ExcessBuyBack>(resource);
            excessBuyBack.Id = Guid.NewGuid();
            excessBuyBack.DateAdded = DateTime.Now;

            await _unitOfWork.ExcessBuyBacks.AddAsync(excessBuyBack);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ExcessBuyBacks.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ExcessBuyBackResource resource)
        {
            var excessBuyBack = _mapper.Map<ExcessBuyBackResource, ExcessBuyBack>(resource);
            await _unitOfWork.ExcessBuyBacks.DeleteAsync(excessBuyBack);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ExcessBuyBackResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ExcessBuyBacks.GetAllAsync(
                                                        null,
                                                        r => r.OrderBy(n => n.Motor.RegNumber),
                                                        r => r.Motor,
                                                        r => r.ParentPolicy);

            var resources = _mapper.Map<IEnumerable<ExcessBuyBack>, IEnumerable<ExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<ExcessBuyBackResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ExcessBuyBacks.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Motor,
                                                        r => r.ParentPolicy);

            var resource = _mapper.Map<ExcessBuyBack, ExcessBuyBackResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ExcessBuyBackResource resource)
        {
            var excessBuyBack = _mapper.Map<ExcessBuyBackResource, ExcessBuyBack>(resource);
            await _unitOfWork.ExcessBuyBacks.UpdateAsync(resource.Id, excessBuyBack);

            return await _unitOfWork.SaveAsync();
        }
    }
}
