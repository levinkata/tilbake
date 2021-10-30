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
    public class ExcessBuyBackService : IExcessBuyBackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExcessBuyBackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(ExcessBuyBackSaveResource resource)
        {
            var excessBuyBack = _mapper.Map<ExcessBuyBackSaveResource, ExcessBuyBack>(resource);
            excessBuyBack.Id = Guid.NewGuid();
            excessBuyBack.DateAdded = DateTime.Now;

            _unitOfWork.ExcessBuyBacks.Add(excessBuyBack);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.ExcessBuyBacks.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ExcessBuyBackResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ExcessBuyBacks.FindAllAsync(
                                                        null,
                                                        r => r.OrderBy(n => n.Motor.RegNumber),
                                                        r => r.Motor,
                                                        r => r.ParentPolicy);

            var resources = _mapper.Map<IEnumerable<ExcessBuyBack>, IEnumerable<ExcessBuyBackResource>>(result);
            return resources;
        }

        public async Task<ExcessBuyBackResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ExcessBuyBacks.GetByIdAsync(
                                                        r => r.Id == id,
                                                        r => r.Motor,
                                                        r => r.ParentPolicy);

            var resource = _mapper.Map<ExcessBuyBack, ExcessBuyBackResource>(result);
            return resource;
        }

        public async void Update(ExcessBuyBackResource resource)
        {
            var excessBuyBack = _mapper.Map<ExcessBuyBackResource, ExcessBuyBack>(resource);
            _unitOfWork.ExcessBuyBacks.Update(resource.Id, excessBuyBack);

            await _unitOfWork.SaveAsync();
        }
    }
}
