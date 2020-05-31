using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class FileUploadRepository : IFileUploadRepository
    {
        public async Task<IEnumerable<byte>> FileUpload(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            long size = file.Length;
            if (size > 0)
            {
                using var memoryStream = new MemoryStream();
                await file.CopyToAsync(memoryStream).ConfigureAwait(true);
                return memoryStream.ToArray();
            }
            return null;
        }
    }
}
