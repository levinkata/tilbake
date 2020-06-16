using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces.Communication;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<TitleViewModel> GetAsync(Guid id);
        Task<TitleResponse> SaveAsync(Title title);
        Task<TitleResponse> UpdateAsync(Guid id, Title title);
        Task<TitleResponse> DeleteAsync(Guid id);
    }
}

