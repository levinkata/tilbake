using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IResidenceTypeService
    {
        Task<ResidenceTypesViewModel> GetAllAsync();
        Task<ResidenceTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(ResidenceTypeViewModel model);
        Task<int> UpdateAsync(ResidenceTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}