using Domain;
using Infrastructure.Service.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class CategoryController(ICategoryService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        var categories = await service.GetAllCategory();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        await service.Create(category);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await service.GetById(id);
        if (category == null)
        {
            return NotFound();
        }

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
        if (!ModelState.IsValid)
        {
            return View(category);
        }

        await service.Update(category);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await service.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var category = await service.GetById(id);
        if (category == null)
        {
            return NotFound();
        }
        return View(category);
    }

}