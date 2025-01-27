using Domain;
using Infrastructure.Service.CategoryService;
using Infrastructure.Service.CommentService;
using Infrastructure.Service.PostService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebUI.Controllers;

public class CommentController(ICommentService service, IPostService postService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var comments = await service.GetAll();
        return View(comments);
    }
    private async Task PopulatePostsAsync()
    {
        var posts = await postService.GetAll();
        ViewBag.Posts = new SelectList(posts, "Id", "Title");
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        await PopulatePostsAsync();
        return View(new Comment());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Comment comment)
    {
        if (!ModelState.IsValid)
        {
            await PopulatePostsAsync();
            return View(comment);
        }

        comment.CreatedDate = DateTime.UtcNow;
        await service.Create(comment);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var comment = await service.GetById(id);
        if (comment == null)
        {
            return NotFound();
        }
        await PopulatePostsAsync();
        return View(comment);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Comment comment)
    {
        if (!ModelState.IsValid)
        {
            await PopulatePostsAsync();
            return View(comment);
        }

        await service.Update(comment);
        return RedirectToAction("Index");
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await service.Delete(id);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var comment = await service.GetById(id);
        if (comment == null)
        {
            return NotFound();
        }

        return View(comment);
    }
}