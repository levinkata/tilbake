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
    public class SalesTypeService : ISalesTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(SalesTypeSaveResource resource)
        {
            var salesType = _mapper.Map<SalesTypeSaveResource, SalesType>(resource);
            salesType.Id = Guid.NewGuid();

            _unitOfWork.SalesTypes.Add(salesType);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.SalesTypes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<SalesTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.SalesTypes.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<SalesType>, IEnumerable<SalesTypeResource>>(result);

            return resources;
        }

        public async Task<SalesTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.SalesTypes.GetByIdAsync(id);
            var resource = _mapper.Map<SalesType, SalesTypeResource>(result);
            return resource;
        }

        public async void Update(SalesTypeResource resource)
        {
            var salesType = _mapper.Map<SalesTypeResource, SalesType>(resource);
            _unitOfWork.SalesTypes.Update(resource.Id, salesType);

            await _unitOfWork.SaveAsync();
        }
    }
}
