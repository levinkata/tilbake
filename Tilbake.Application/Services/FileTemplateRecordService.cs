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
    public class FileTemplateRecordService : IFileTemplateRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileTemplateRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.FileTemplateRecords.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<FileTemplateRecordResource>> GetAllAsync()
        {
            var result = await _unitOfWork.FileTemplateRecords.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.FieldName));

            var resources = _mapper.Map<IEnumerable<FileTemplateRecord>, IEnumerable<FileTemplateRecordResource>>(result);
            return resources;
        }

        public async Task<IEnumerable<FileTemplateRecordResource>> GetByFileTemplateIdAsync(Guid fileTemplateId)
        {
            var result = await _unitOfWork.FileTemplateRecords.GetAsync(
                                                            e => e.FileTemplateId == fileTemplateId,
                                                            e => e.OrderBy(n => n.TableName),
                                                            e => e.FileTemplate);

            var resources = _mapper.Map<IEnumerable<FileTemplateRecord>, IEnumerable<FileTemplateRecordResource>>(result);
            return resources;
        }

        public async Task<FileTemplateRecordResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.FileTemplateRecords.GetAsync(
                                                            e => e.Id == id,
                                                            null,
                                                            e => e.FileTemplate);
            var resource = _mapper.Map<FileTemplateRecord, FileTemplateRecordResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<FileTemplateRecordResource>> GetTableFileTemplate(Guid fileTemplateId, string tableName)
        {
            var results = await _unitOfWork.FileTemplateRecords.GetAsync(
                                                            r => r.FileTemplateId == fileTemplateId &&
                                                            r.TableName == tableName,
                                                            r => r.OrderBy(n => n.FieldName),
                                                            r => r.FileTemplate);

            var resources = _mapper.Map<IEnumerable<FileTemplateRecord>, IEnumerable<FileTemplateRecordResource>>(results);
            return resources;
        }

        public async Task<int> UpdateAsync(FileTemplateRecordResource resource)
        {
            var fileTemplateRecord = _mapper.Map<FileTemplateRecordResource, FileTemplateRecord>(resource);
            _unitOfWork.FileTemplateRecords.Update(resource.Id, fileTemplateRecord);

            return await _unitOfWork.SaveAsync();
        }
    }
}
