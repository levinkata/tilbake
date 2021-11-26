using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class TitlesController : BaseController
    {
        public TitlesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            var result = await _unitOfWork.Titles.GetAll(r => r.OrderBy(n => n.Name));
            var titles = from m in result
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(titles);
        }        

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Titles.GetById(id);
            var model = _mapper.Map<Title, TitleViewModel>(result);
            return View(model);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TitleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var title = _mapper.Map<TitleViewModel, Title>(model);
                title.Id = Guid.NewGuid();
                title.DateAdded = DateTime.Now;

                await _unitOfWork.Titles.Add(title);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Titles.GetById(id);
            var model = _mapper.Map<Title, TitleViewModel>(result);
            return View(model);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, TitleViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var title = _mapper.Map<TitleViewModel, Title>(model);
                title.DateModified = DateTime.Now;

                await _unitOfWork.Titles.Update(title);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Titles.GetById(id);
            var model = _mapper.Map<Title, TitleViewModel>(result);
            return View(model);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Titles.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
