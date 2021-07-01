using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<TitleResponse> GetByIdAsync(Guid id);
        Task<TitleResponse> AddAsync(Title title);
        Task<TitleResponse> UpdateAsync(Guid id, Title title);
        Task<TitleResponse> DeleteAsync(Guid id);
        Task<TitleResponse> DeleteAsync(Title title);
    }
}