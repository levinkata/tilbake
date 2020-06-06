using Microsoft.AspNetCore.Http;

namespace Tilbake.Application.ViewModels
{
    public class FileUpLoadViewModel
    {
        public UploadFileParamsViewModel FileParams { get; set; }
        public IFormFile File { get; set; }
    }
}
