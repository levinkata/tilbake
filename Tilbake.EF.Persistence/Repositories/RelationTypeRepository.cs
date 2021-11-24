using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RelationTypeRepository : Repository<RelationType>, IRelationTypeRepository
    {
        public RelationTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}