using Microsoft.AspNetCore.Mvc;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.Controllers
{
    public class FileTemplateRecordsController : Controller
    {
        private readonly IFileTemplateService _fileTemplateService;
        private readonly IFileTemplateRecordService _fileTemplateRecordService;

        public FileTemplateRecordsController(IFileTemplateService fileTemplateService,
                                            IFileTemplateRecordService fileTemplateRecordService)
        {
            _fileTemplateService = fileTemplateService;
            _fileTemplateRecordService = fileTemplateRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

