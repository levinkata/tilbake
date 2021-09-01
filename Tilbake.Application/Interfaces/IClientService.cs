using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResource>> GetAllAsync();
        Task<ClientResource> GetByIdAsync(Guid id);
        Task<ClientResource> GetByIdNumberAsync(string idNumber);
        Task<ClientResource> GetByPolicyIdAsync(Guid policyId);
        Task<IEnumerable<ClientResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<ClientResource> GetByClientIdAsync(Guid portfolioId, Guid clientId);
        Task<int> ImportBulkAsync(Guid portfolioId, Guid fileTemplateId, FileType fileType,
                            string delimiter, IFormFile uploadFile, int startRow);
        Task<int> AddAsync(ClientSaveResource resource);
        Task<int> AddRangeAsync(List<ClientSaveResource> resources);
        Task<int> UpdateAsync(ClientResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientResource resource);
        Task<int> DeleteRangeAsync(List<ClientResource> resources);
    }
}