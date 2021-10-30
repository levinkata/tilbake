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
    public class TitleService : ITitleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TitleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(TitleSaveResource resource)
        {
            var title = _mapper.Map<TitleSaveResource, Title>(resource);
            title.Id = Guid.NewGuid();

            _unitOfWork.Titles.Add(title);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Titles.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TitleResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Titles.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(result);
            return resources;
        }

        public async Task<TitleResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Titles.GetByIdAsync(id);
            var resource = _mapper.Map<Title, TitleResource>(result);
            return resource;
        }

        public async void Update(TitleResource resource)
        {
            var title = _mapper.Map<TitleResource, Title>(resource);
            _unitOfWork.Titles.Update(resource.Id, title);

            await _unitOfWork.SaveAsync();
        }
    }
}
