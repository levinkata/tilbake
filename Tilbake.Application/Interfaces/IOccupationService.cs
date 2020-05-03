using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IOccupationService
    {
        Task<OccupationsViewModel> GetAllAsync();
        Task<OccupationViewModel> GetAsync(Guid id);
        Task<int> AddAsync(OccupationViewModel model);
        Task<int> UpdateAsync(OccupationViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
