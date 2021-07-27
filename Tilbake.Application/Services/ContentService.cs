﻿using AutoMapper;
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

            await _unitOfWork.Contents.AddAsync(content).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Contents.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(ContentResource resource)
        {
            var content = _mapper.Map<ContentResource, Content>(resource);
            await _unitOfWork.Contents.DeleteAsync(content).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<ContentResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Contents.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Content>, IEnumerable<ContentResource>>(result);

            return resources;
        }

        public async Task<ContentResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Contents.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Content, ContentResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ContentResource resource)
        {
            var content = _mapper.Map<ContentResource, Content>(resource);
            await _unitOfWork.Contents.UpdateAsync(resource.Id, content).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
