using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

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
