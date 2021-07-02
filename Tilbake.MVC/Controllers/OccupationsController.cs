using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.MVC.Resources;

namespace Tilbake.MVC.Controllers
{
    public class OccupationsController : Controller
    {
        private readonly IOccupationService _occupationService;
        private readonly IMapper _mapper;

        public OccupationsController(IOccupationService occupationService, IMapper mapper)
        {
            _occupationService = occupationService ?? throw new ArgumentNullException(nameof(occupationService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        // GET: Occupations
        public async Task<IActionResult> Index()
        {
            var result = await _occupationService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Occupation>, IEnumerable<OccupationResource>>(result);

            return View(resources);
        }

        // GET: Occupations/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _occupationService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return View(occupationResource);
        }

        // GET: Occupations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OccupationSaveResource occupationSaveResource)
        {
            if (occupationSaveResource == null)
            {
                throw new ArgumentNullException(nameof(occupationSaveResource));
            }

            if (ModelState.IsValid)
            {
                Occupation occupation = _mapper.Map<OccupationSaveResource, Occupation>(occupationSaveResource);
                occupation.Id = Guid.NewGuid();

                var result = await _occupationService.AddAsync(occupation).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(occupationSaveResource);
        }

        // GET: Occupations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _occupationService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return View(occupationResource);
        }

        // POST: Occupations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, OccupationResource occupationResource)
        {
            if (id != occupationResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Occupation occupation = _mapper.Map<OccupationResource, Occupation>(occupationResource);

                var result = await _occupationService.UpdateAsync(id, occupation).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(occupationResource);
        }

        // GET: Occupations/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _occupationService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return View(occupationResource);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _occupationService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            try
            {
                var deleteResult = await _occupationService.DeleteAsync(id).ConfigureAwait(true);
                if (!deleteResult.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
                return View(occupationResource);
            }
        }
    }
}
