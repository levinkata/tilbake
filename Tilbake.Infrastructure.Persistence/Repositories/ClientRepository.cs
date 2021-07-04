using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly TilbakeDbContext _context;

        public ClientRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Client> AddAsync(Client client)
        {
            await _context.Clients.AddAsync(client).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return client;
        }

        public async Task<IEnumerable<Client>> AddRangeAsync(IEnumerable<Client> clients)
        {
            await _context.Clients.AddRangeAsync(clients).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clients;
        }

        public async Task<Client> DeleteAsync(Guid id)
        {
            Client client = await _context.Clients
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (client == null)
            {
                return client;
            }

            await Task.Run(() => _context.Clients.Remove(client)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return client;
        }

        public async Task<Client> DeleteAsync(Client client)
        {
            if (client == null)
            {
                return client;
            }
            
            await Task.Run(() => _context.Clients.Remove(client)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return client;
        }

        public async Task<IEnumerable<Client>> DeleteRangeAsync(IEnumerable<Client> clients)
        {
            if (clients == null)
            {
                return clients;
            }

            await Task.Run(() => _context.Clients.RemoveRange(clients)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return clients;
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            IEnumerable<Client> clients = _context.Clients
                                                .Include(c => c.Carrier)
                                                .Include(y => y.ClientType)
                                                .Include(u => u.Country)
                                                .Include(g => g.Gender)
                                                .Include(m => m.MaritalStatus)
                                                .Include(o => o.Occupation)
                                                .Include(t => t.Title)
                                                .OrderBy(n => n.LastName)
                                                .AsNoTracking();
            return await Task.Run(() => clients).ConfigureAwait(true);
        }

        public async Task<Client> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Clients
                                                .Where(e => e.Id == id)
                                                .Include(c => c.Carrier)
                                                .Include(y => y.ClientType)
                                                .Include(u => u.Country)
                                                .Include(g => g.Gender)
                                                .Include(m => m.MaritalStatus)
                                                .Include(o => o.Occupation)
                                                .Include(t => t.Title)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Client> UpdateAsync(Client client)
        {
            if (client == null)
            {
                return client;
            }
            
            await Task.Run(() => _context.Clients.Update(client)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return client;
        }
    }
}