using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tilbake.Core;
using Tilbake.MVC.Areas.Identity;

namespace Tilbake.MVC.Controllers
{
    public class FileTemplateRecordsController : BaseController
    {
        public FileTemplateRecordsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

