using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers;
public class TitlesController : Controller
{
    private readonly ITitleService _titleService;

    public TitlesController(ITitleService titleService)
    {
        _titleService = titleService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _titleService.GetAllAsync());
    }

    // GET: Titles/Details/5
    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _titleService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }

    // GET: Titles/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Titles/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TitleSaveResource resource)
    {
        if (ModelState.IsValid)
        {
            await _titleService.AddAsync(resource);
            return RedirectToAction(nameof(Index));
        }
        return View(resource);
    }

    // GET: Titles/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _titleService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }
        return View(resource);
    }

    // POST: Titles/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid? id, TitleResource resource)
    {
        if (id != resource.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _titleService.UpdateAsync(resource);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(resource);
    }

    // GET: Titles/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var resource = await _titleService.GetByIdAsync((Guid)id);
        if (resource == null)
        {
            return NotFound();
        }

        return View(resource);
    }

    // POST: Titles/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _titleService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
