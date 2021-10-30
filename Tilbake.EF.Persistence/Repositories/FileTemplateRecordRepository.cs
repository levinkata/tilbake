﻿using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class FileTemplateRecordRepository : Repository<FileTemplateRecord>, IFileTemplateRecordRepository
    {
        public FileTemplateRecordRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}