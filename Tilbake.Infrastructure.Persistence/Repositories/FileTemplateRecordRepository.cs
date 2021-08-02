﻿using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class FileTemplateRecordRepository : Repository<FileTemplateRecord>, IFileTemplateRecordRepository
    {
        public FileTemplateRecordRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}