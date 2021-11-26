using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class FileTemplateRepository : Repository<FileTemplate>, IFileTemplateRepository
    {
        public FileTemplateRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<FileTemplate>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.FileTemplates
                                .Where(e => e.PortfolioId == portfolioId)
                                .Include(e => e.FileTemplateRecords)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }
    }
}
