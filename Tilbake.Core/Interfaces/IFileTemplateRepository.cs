using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IFileTemplateRepository : IRepository<FileTemplate>
    {
        Task<IEnumerable<FileTemplate>> GetByPortfolioId(Guid portfolioId);
    }
}
