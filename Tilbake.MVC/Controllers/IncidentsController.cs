using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    [Authorize]
    public class IncidentsController : BaseController
    {
        public IncidentsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Incidents
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Incidents.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Incident>, IEnumerable<IncidentViewModel>>(result);
            return View(model);
        }

        // GET: Incidents/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Incidents.GetById(id);
            var model = _mapper.Map<Incident, IncidentViewModel>(result);
            return View(model);
        }

        // GET: Incidents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incidents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IncidentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var incident = _mapper.Map<IncidentViewModel, Incident>(model);
                incident.Id = Guid.NewGuid();
                incident.DateAdded = DateTime.Now;

                await _unitOfWork.Incidents.Add(incident);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Incidents/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Incidents.GetById(id);
            var model = _mapper.Map<Incident, IncidentViewModel>(result);
            return View(model);
        }

        // POST: Incidents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, IncidentViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var incident = _mapper.Map<IncidentViewModel, Incident>(model);
                incident.DateModified = DateTime.Now;

                await _unitOfWork.Incidents.Update(incident);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Incidents/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Incidents.GetById(id);
            var model = _mapper.Map<Incident, IncidentViewModel>(result);
            return View(model);
        }

        // POST: Incidents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Incidents.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
