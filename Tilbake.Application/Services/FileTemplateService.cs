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
    public class FileTemplateService : IFileTemplateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileTemplateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(FileTemplateSaveResource resource)
        {
            var fileTemplate = _mapper.Map<FileTemplateSaveResource, FileTemplate>(resource);
            fileTemplate.Id = Guid.NewGuid();
            await _unitOfWork.FileTemplates.AddAsync(fileTemplate);

            var fileTemplateId = fileTemplate.Id;

            await PopulateFileTemplateRecord(fileTemplateId);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.FileTemplates.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(FileTemplateResource resource)
        {
            var fileTemplate = _mapper.Map<FileTemplateResource, FileTemplate>(resource);
            await _unitOfWork.FileTemplates.DeleteAsync(fileTemplate);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<FileTemplateResource>> GetAllAsync()
        {
            var result = await _unitOfWork.FileTemplates.GetAllAsync(
                                                            null,
                                                            e => e.OrderBy(n => n.Name),
                                                            e => e.FileTemplateRecords);

            var resources = _mapper.Map<IEnumerable<FileTemplate>, IEnumerable<FileTemplateResource>>(result);

            return resources;
        }

        public async Task<FileTemplateResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.FileTemplates.GetFirstOrDefaultAsync(
                                                        e => e.Id == id,
                                                        e => e.Portfolio);

            var resources = _mapper.Map<FileTemplate, FileTemplateResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(FileTemplateResource resource)
        {
            var fileTemplate = _mapper.Map<FileTemplateResource, FileTemplate>(resource);
            await _unitOfWork.FileTemplates.UpdateAsync(resource.Id, fileTemplate);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task PopulateFileTemplateRecord(Guid fileTemplateId)
        {
            var fileTemplateRecords = new List<FileTemplateRecord>
            {
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Title",FieldLabel="Title",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="ClientType",FieldLabel="Client Type",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="BirthDate",FieldLabel="Birth Date",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Gender",FieldLabel="Gender",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Phone",FieldLabel="Phone",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Mobile",FieldLabel="Mobile",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Country",FieldLabel="Country",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Email",FieldLabel="Email",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="MaritalStatus",FieldLabel="Marital Status",Position=null,ColumnLength=0,IsKey=false},
                new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Client",TableLabel="Client",FieldName="Occupation",FieldLabel="Occupation",Position=null,ColumnLength=0,IsKey=false},

               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Policy",TableLabel="Policy",FieldName="PolicyNumber",FieldLabel="Policy Number",Position=null,ColumnLength=0,IsKey=false},

               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="IdNumber",FieldLabel="ID Number",Position=null,ColumnLength=0,IsKey=true},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="PolicyNumber",FieldLabel="Policy Number",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="FirstName",FieldLabel="First Name",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="LastName",FieldLabel="Last Name",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Premium",TableLabel="Premium",FieldName="Amount",FieldLabel="Premium",Position=null,ColumnLength=0,IsKey=false},

               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ClaimNumber",FieldLabel="Claim Number",Position=null,ColumnLength=0,IsKey=true},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReportDate",FieldLabel="Report Date",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="IncidentDate",FieldLabel="Incident Date",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="RegisterDate",FieldLabel="Register Date",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReserveInsured",FieldLabel="Reserve Insured",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="ReserveThirdParty",FieldLabel="Reserve Third Party",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim",FieldName="Excess",FieldLabel="Excess",Position=null,ColumnLength=0,IsKey=false},
               new FileTemplateRecord {Id=Guid.NewGuid(),FileTemplateId=fileTemplateId,TableName="Claim",TableLabel="Claim", FieldName="RecoverFromThirdParty",FieldLabel="Recover From Third Party",Position=null,ColumnLength=0,IsKey=false}
            };

            await _unitOfWork.FileTemplateRecords.AddRangeAsync(fileTemplateRecords);
        }

        public async Task<IEnumerable<FileTemplateResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.FileTemplates.GetAllAsync(
                                                            e => e.PortfolioId == portfolioId,
                                                            e => e.OrderBy(n => n.Name),
                                                            e => e.FileTemplateRecords);

            var resources = _mapper.Map<IEnumerable<FileTemplate>, IEnumerable<FileTemplateResource>>(result);

            return resources;
        }
    }
}
