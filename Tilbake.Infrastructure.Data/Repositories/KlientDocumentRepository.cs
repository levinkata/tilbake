using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class KlientDocumentRepository : IKlientDocumentRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KlientDocumentRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid klientId, KlientDocument klientDocument, List<IFormFile> DocumentFiles)
        {
            if (klientDocument == null)
            {
                throw new ArgumentNullException(nameof(klientDocument));
            }

            if (DocumentFiles == null)
            {
                throw new ArgumentNullException(nameof(DocumentFiles));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                int numOfFiles = DocumentFiles.Count;
                int version = 0;
                string DocumentName = klientDocument.Name;

                await Task.Run(async () =>
                {
                    if (numOfFiles > 1)
                    {
                        version = 1;
                    }

                    klientDocument.ID = Guid.NewGuid();
                    klientDocument.KlientID = klientId;

                    foreach (var formFile in DocumentFiles)
                    {
                        if (version > 0)
                        {
                            klientDocument.Name = DocumentName + "-" + version;
                            version++;
                        }
                        else
                            klientDocument.Name = DocumentName;

                        long size = formFile.Length;
                        if (size > 0)
                        {
                            using var memoryStream = new MemoryStream();
                            await formFile.CopyToAsync(memoryStream).ConfigureAwait(true);
                            klientDocument.Document.AddRange(memoryStream.ToArray());
                        }
                    }
                    await _context.KlientDocuments.AddAsync((KlientDocument)klientDocument).ConfigureAwait(true);

                }).ConfigureAwait(true);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            KlientDocument klientDocument = await _context.KlientDocuments.FindAsync(id).ConfigureAwait(true);
            _context.KlientDocuments.Remove((KlientDocument)klientDocument);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<KlientDocument>> GetAllAsync(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.KlientDocuments
                                                .Include(b => b.Klient)
                                                .Include(b => b.DocumentType)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<KlientDocument> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.KlientDocuments
                                                .Include(b => b.Klient)
                                                .Include(b => b.DocumentType)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(KlientDocument klientDocument)
        {
            if (klientDocument == null)
            {
                throw new ArgumentNullException(nameof(klientDocument));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.KlientDocuments.Update((KlientDocument)klientDocument);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
