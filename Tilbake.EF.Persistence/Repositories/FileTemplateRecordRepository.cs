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
    public class FileTemplateRecordRepository : Repository<FileTemplateRecord>, IFileTemplateRecordRepository
    {
        public FileTemplateRecordRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<FileTemplateRecord>> GetByFileTemplateId(Guid fileTemplateId)
        {
            return await _context.FileTemplateRecords
                                .Where(r => r.FileTemplateId == fileTemplateId)
                                .OrderBy(n => n.TableName)
                                .Include(r => r.FileTemplate).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<FileTemplateRecord>> GetTableFileTemplate(Guid fileTemplateId, string tableName)
        {
            return await _context.FileTemplateRecords
                                .Where(r => r.FileTemplateId == fileTemplateId &&
                                            r.TableName == tableName)
                                .OrderBy(n => n.FieldName)
                                .Include(r => r.FileTemplate).AsNoTracking().ToListAsync();
        }
    }
}
