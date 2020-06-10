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
    public class DocumentCategoryRepository : IDocumentCategoryRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public DocumentCategoryRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(DocumentCategory documentCategory)
        {
            if (documentCategory == null)
            {
                throw new ArgumentNullException(nameof(documentCategory));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                documentCategory.ID = Guid.NewGuid();
                await context.DocumentCategories.AddAsync((DocumentCategory)documentCategory).ConfigureAwait(true);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            DocumentCategory documentCategory = await context.DocumentCategories.FindAsync(id).ConfigureAwait(true);
            context.DocumentCategories.Remove((DocumentCategory)documentCategory);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<DocumentCategory>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.DocumentCategories
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<DocumentCategory> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.DocumentCategories
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(DocumentCategory documentCategory)
        {
            if (documentCategory == null)
            {
                throw new ArgumentNullException(nameof(documentCategory));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.DocumentCategories.Update((DocumentCategory)documentCategory);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
