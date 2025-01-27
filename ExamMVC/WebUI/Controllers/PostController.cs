using Domain;
using Infrastructure.Service.CategoryService;
using Infrastructure.Service.PostService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class PostController(IPostService service, ICategoryService categoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var posts = await service.GetAll();
        return View(posts);
    }

    private async Task PopulateCategoriesAsync()
    {
        var categories = await categoryService.GetAllCategory();
        ViewBag.Categories = new SelectList(categories, "Id", "Name");
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulateCategoriesAsync();
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Post post)
    {

        if (!ModelState.IsValid)
        {
            await PopulateCategoriesAsync();
            return View(post);
        }

        await service.Create(post);
        return RedirectToAction("Index");

    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var post = await service.GetById(id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Post post)
    {
        if (!ModelState.IsValid)
        {
            await PopulateCategoriesAsync();
            return View(post);
        }

        await service.Update(post);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await service.Delete(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var post = await service.GetById(id);  
        if (post == null)
        {
            return NotFound(); 
        }
        return View(post); 
    }

}
