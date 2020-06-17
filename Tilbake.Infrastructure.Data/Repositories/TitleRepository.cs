using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class TitleRepository : BaseRepository, ITitleRepository
    {
        public TitleRepository(TilbakeDbContext context) : base(context) { }

        public async Task AddAsync(Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            title.Id = Guid.NewGuid();
            await _context.Titles.AddAsync((Title)title).ConfigureAwait(true);
        }

        public void DeleteAsync(Title title)
        {
            _context.Titles.Remove(title);
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            return await Task.Run(() => _context.Titles
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking()
                                                .ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Title> GetAsync(Guid id)
        {                                   .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
            return await _context.Titles.FindAsync(id).ConfigureAwait(true);
        }

        public void UpdateAsync(Title title)
        {
            _context.Titles.Update(title);
        }
    }
}
