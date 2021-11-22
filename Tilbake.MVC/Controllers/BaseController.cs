using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tilbake.Core;
using Tilbake.MVC.Areas.Identity;

namespace Tilbake.MVC.Controllers
{
    public class BaseController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;
        public readonly UserManager<ApplicationUser> _userManager;
        public BaseController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }
    }
}
