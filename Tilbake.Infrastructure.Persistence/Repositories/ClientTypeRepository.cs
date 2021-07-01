using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientTypeRepository : IClientTypeRepository
    {
        private readonly TilbakeDbContext _context;

        public ClientTypeRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ClientType> AddAsync(ClientType clientType)
        {
            await _context.ClientTypes.AddAsync(clientType).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientType;
        }

        public async Task<IQueryable<ClientType>> AddRangeAsync(IQueryable<ClientType> clientTypes)
        {
            await _context.ClientTypes.AddRangeAsync(clientTypes).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientTypes;
        }

        public async Task<ClientType> DeleteAsync(Guid id)
        {
            ClientType clientType = await _context.ClientTypes
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (clientType == null)
            {
                return clientType;
            }

            await Task.Run(() => _context.ClientTypes.Remove(clientType)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientType;
        }

        public async Task<ClientType> DeleteAsync(ClientType clientType)
        {
            if (clientType == null)
            {
                return clientType;
            }
            
            await Task.Run(() => _context.ClientTypes.Remove(clientType)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientType;
        }

        public async Task<IQueryable<ClientType>> DeleteRangeAsync(IQueryable<ClientType> clientTypes)
        {
            if (clientTypes == null)
            {
                return clientTypes;
            }

            await Task.Run(() => _context.ClientTypes.RemoveRange(clientTypes)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientTypes;
        }

        public async Task<IQueryable<ClientType>> GetAllAsync()
        {
            IQueryable<ClientType> clientTypes = _context.ClientTypes.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => clientTypes).ConfigureAwait(true);
        }

        public async Task<ClientType> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.ClientTypes
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<ClientType> UpdateAsync(ClientType clientType)
        {
            if (clientType == null)
            {
                return clientType;
            }
            
            await Task.Run(() => _context.ClientTypes.Update(clientType)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clientType;
        }
    }
}