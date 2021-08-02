using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;

namespace Tilbake.MVC.ViewComponents
{
    public class FileTemplatesViewComponent : ViewComponent
    {
        private readonly IFileTemplateService _fileTemplateService;

        public FileTemplatesViewComponent(IFileTemplateService fileTemplateService)
        {
            _fileTemplateService = fileTemplateService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid portfolioId)
        {
            ViewBag.PortfolioId = portfolioId;
            return View(await Task.Run(() => _fileTemplateService.GetByPortfolioIdAsync(portfolioId)));
        }
    }
}
