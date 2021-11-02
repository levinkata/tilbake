using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class ContentService : IContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ContentSaveResource resource)
        {
            var content = _mapper.Map<ContentSaveResource, Content>(resource);
            content.Id = Guid.NewGuid();

            _unitOfWork.Contents.Add(content);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Contents.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ContentResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Contents.GetAsync(null);

            var resources = _mapper.Map<IEnumerable<Content>, IEnumerable<ContentResource>>(result);
            return resources;
        }

        public async Task<ContentResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Contents.GetByIdAsync(id);
            var resource = _mapper.Map<Content, ContentResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ContentResource resource)
        {
            var content = _mapper.Map<ContentResource, Content>(resource);
            _unitOfWork.Contents.Update(resource.Id, content);

            return await _unitOfWork.SaveAsync();
        }
    }
}
