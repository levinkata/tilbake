﻿using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RiskItemRepository : Repository<RiskItem>, IRiskItemRepository
    {
        public RiskItemRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
