using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class FileTemplateRepository : Repository<FileTemplate>, IFileTemplateRepository
    {
        public FileTemplateRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
