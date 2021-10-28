using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

namespace Tilbake.Application.Services
{
    public class ClientDocumentService : IClientDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientDocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(ClientDocumentSaveResource resource)
        {
            var file = resource.File;

            var basePath = Path.Combine(Directory.GetCurrentDirectory() + Constants.ClientFolder);
            bool basePathExists = Directory.Exists(basePath);
            if (!basePathExists) Directory.CreateDirectory(basePath);

            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var filePath = Path.Combine(basePath, file.FileName);
            var extension = Path.GetExtension(file.FileName);

            if (!File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var clientDocument = _mapper.Map<ClientDocumentSaveResource, ClientDocument>(resource);
                clientDocument.Id = Guid.NewGuid();
                clientDocument.FileType = file.ContentType;
                clientDocument.Extension = extension;
                clientDocument.Name = fileName;
                clientDocument.DocumentDate = DateTime.Now;
                clientDocument.DocumentPath = filePath;
                clientDocument.DateAdded = DateTime.Now;

                _unitOfWork.ClientDocuments.Add(clientDocument);
            }
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            var result = await _unitOfWork.ClientDocuments.GetByIdAsync(id);

            if (File.Exists(result.DocumentPath))
            {
                File.Delete(result.DocumentPath);
            }
            _unitOfWork.ClientDocuments.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(ClientDocumentResource resource)
        {
            if (File.Exists(resource.DocumentPath))
            {
                File.Delete(resource.DocumentPath);
            }

            var clientDocument = _mapper.Map<ClientDocumentResource, ClientDocument>(resource);
            _unitOfWork.ClientDocuments.Delete(clientDocument);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientDocumentResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientDocuments.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ClientDocument>, IEnumerable<ClientDocumentResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<ClientDocumentResource>> GetByClientIdAsync(Guid clientId)
        {
            var result = await _unitOfWork.ClientDocuments.GetAllAsync(
                                                            e => e.ClientId == clientId,
                                                            e => e.OrderBy(p => p.Name),
                                                            e => e.DocumentType,
                                                            e => e.Client);

            var resources = _mapper.Map<IEnumerable<ClientDocument>, IEnumerable< ClientDocumentResource>>(result);
            return resources;
        }

        public async Task<ClientDocumentResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientDocuments.GetByIdAsync(id);
            var resource = _mapper.Map<ClientDocument, ClientDocumentResource>(result);

            return resource;
        }

        public async void Update(ClientDocumentResource resource)
        {
            var clientDocument = _mapper.Map<ClientDocumentResource, ClientDocument>(resource);
            _unitOfWork.ClientDocuments.Update(resource.Id, clientDocument);

            await _unitOfWork.SaveAsync();
        }
    }
}
