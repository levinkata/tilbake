﻿using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ReceivableDocumentRepository : Repository<ReceivableDocument>, IReceivableDocumentRepository
    {
        public ReceivableDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}