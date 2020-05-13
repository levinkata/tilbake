using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IBodyTypeService
    {
        Task<BodyTypesViewModel> GetAllAsync();
        Task<BodyTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(BodyTypeViewModel model);
        Task<int> UpdateAsync(BodyTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
