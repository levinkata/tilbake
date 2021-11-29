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
