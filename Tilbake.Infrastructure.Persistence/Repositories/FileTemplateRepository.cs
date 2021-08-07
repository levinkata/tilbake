using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class FileTemplateRepository : Repository<FileTemplate>, IFileTemplateRepository
    {
        public FileTemplateRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
