using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tilbake.Domain.Interfaces
{
    public interface IFileUploadRepository
    {
        Task<IEnumerable<byte>> FileUpload(IFormFile file);
    }
}
