using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface ILandService
    {
        Task<LandsViewModel> GetAllAsync();
        Task<LandViewModel> GetAsync(Guid id);
        Task<int> AddAsync(LandViewModel model);
        Task<int> UpdateAsync(LandViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
