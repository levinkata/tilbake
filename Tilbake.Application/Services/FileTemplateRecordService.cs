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
    public class FileTemplateRecordService : IFileTemplateRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileTemplateRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(FileTemplateRecordSaveResource resource)
        {
            var fileTemplateRecord = _mapper.Map<FileTemplateRecordSaveResource, FileTemplateRecord>(resource);
            fileTemplateRecord.Id = Guid.NewGuid();

            await _unitOfWork.FileTemplateRecords.AddAsync(fileTemplateRecord);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.FileTemplateRecords.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(FileTemplateRecordResource resource)
        {
            var fileTemplateRecord = _mapper.Map<FileTemplateRecordResource, FileTemplateRecord>(resource);
            await _unitOfWork.FileTemplateRecords.DeleteAsync(fileTemplateRecord);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<FileTemplateRecordResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.FileTemplateRecords.GetAllAsync());

            var resources = _mapper.Map<IEnumerable<FileTemplateRecord>, IEnumerable<FileTemplateRecordResource>>(result);

            return resources;
        }

        public async Task<IEnumerable<FileTemplateRecordResource>> GetByFileTemplateIdAsync(Guid fileTemplateId)
        {
            var result = await _unitOfWork.FileTemplateRecords.GetAllAsync(
                                                            e => e.FileTemplateId == fileTemplateId,
                                                            e => e.OrderBy(n => n.TableName));

            var resources = _mapper.Map<IEnumerable<FileTemplateRecord>, IEnumerable<FileTemplateRecordResource>>(result);

            return resources;
        }

        public async Task<FileTemplateRecordResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.FileTemplateRecords.GetByIdAsync(id);
            var resources = _mapper.Map<FileTemplateRecord, FileTemplateRecordResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(FileTemplateRecordResource resource)
        {
            var fileTemplateRecord = _mapper.Map<FileTemplateRecordResource, FileTemplateRecord>(resource);
            await _unitOfWork.FileTemplateRecords.UpdateAsync(resource.Id, fileTemplateRecord);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
