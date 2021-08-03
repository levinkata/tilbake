using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class FileTemplatesController : Controller
    {
        private readonly IFileTemplateService _fileTemplateService;
        private readonly IPortfolioService _portfolioService;

        public FileTemplatesController(IFileTemplateService fileTemplateService,
                                        IPortfolioService portfolioService)
        {
            _fileTemplateService = fileTemplateService;
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index(Guid portfolioId)
        {
            var resources = await _fileTemplateService.GetByPortfolioIdAsync(portfolioId);
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            FileTemplateSaveResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                FileFormatList = SelectLists.FileFormats(Guid.Empty)
            };

            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FileTemplateSaveResource resource)
        {
            if(ModelState.IsValid)
            {
                await _fileTemplateService.AddAsync(resource);

                return RedirectToAction(nameof(Index), new { portfolioId = resource.PortfolioId });
            }
            return View(resource);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);

            FileTemplateResource resource = new()
            {
                PortfolioId = portfolioId,
                PortfolioName = portfolio.Name,
                FileFormatList = SelectLists.FileFormats(Guid.Empty)
            };

            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FileTemplateResource resource)
        {
            if (ModelState.IsValid)
            {
                await _fileTemplateService.UpdateAsync(resource);

                return RedirectToAction(nameof(Index), new { portfolioId = resource.PortfolioId });
            }
            return View(resource);
        }
    }
}
