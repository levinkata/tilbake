using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers;
public class GendersController : Controller
{
    private readonly IGenderService _genderService;

    public GendersController(IGenderService genderService)
    {
        _genderService = genderService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _genderService.GetAllAsync());
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _genderService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }

    // GET: Genders/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Genders/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(GenderSaveResource resource)
    {
        if (ModelState.IsValid)
        {
            await _genderService.AddAsync(resource);
            return RedirectToAction(nameof(Index));
        }
        return View(resource);
    }

    // GET: Genders/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _genderService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }
        return View(resource);
    }

    // POST: Genders/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid? id, GenderResource resource)
    {
        if (id != resource.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _genderService.UpdateAsync(resource);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(resource);
    }

    // GET: Genders/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _genderService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }

    // POST: Genders/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _genderService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
