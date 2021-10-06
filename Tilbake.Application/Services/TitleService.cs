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
    public class TitleService : ITitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TitleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(TitleSaveResource resource)
        {
            var title = _mapper.Map<TitleSaveResource, Title>(resource);
            title.Id = Guid.NewGuid();

            await _unitOfWork.Titles.AddAsync(title);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Titles.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(TitleResource resource)
        {
            var title = _mapper.Map<TitleResource, Title>(resource);
            await _unitOfWork.Titles.DeleteAsync(title);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TitleResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Titles.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(result);

            return resources;
        }

        public async Task<TitleResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Titles.GetByIdAsync(id);
            var resources = _mapper.Map<Title, TitleResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(TitleResource resource)
        {
            var title = _mapper.Map<TitleResource, Title>(resource);
            await _unitOfWork.Titles.UpdateAsync(resource.Id, title);

            return await _unitOfWork.SaveAsync();
        }
    }
}
